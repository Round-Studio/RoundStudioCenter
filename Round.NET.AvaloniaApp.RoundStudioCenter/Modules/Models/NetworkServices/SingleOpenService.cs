using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.NetworkServices
{
    public class SingleInstanceChecker : IDisposable
    {
        private const int Port = 1136;
        private const string MulticastAddress = "239.0.0.1"; // 本地多播地址
        private UdpClient _udpClient;
        private bool _isListening;
        private bool _isInstanceRunning;
        private string _instanceId = Guid.NewGuid().ToString();
        private Task _listeningTask;
        private CancellationTokenSource _cts;

        // 等待响应的时间（毫秒）
        private const int ResponseTimeout = 1000;

        public bool IsAnotherInstanceRunning => _isInstanceRunning;

        public SingleInstanceChecker()
        {
            InitializeUdpListener();
        }

        private void InitializeUdpListener()
        {
            try
            {
                _udpClient = new UdpClient();
                _udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                _udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, Port));
                _udpClient.JoinMulticastGroup(IPAddress.Parse(MulticastAddress));

                _cts = new CancellationTokenSource();
                _isListening = true;
                _listeningTask = ListenForMessagesAsync(_cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"初始化UDP监听失败: {ex.Message}");
                _isListening = false;
            }
        }

        public async Task<bool> CheckForOtherInstancesAsync()
        {
            try
            {
                // 发送检测请求
                var requestData = new
                {
                    id = _instanceId,
                    type = "InstanceCheck",
                    timestamp = DateTime.UtcNow
                };

                string jsonRequest = JsonSerializer.Serialize(requestData);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonRequest);

                var endPoint = new IPEndPoint(IPAddress.Parse(MulticastAddress), Port);
                await _udpClient.SendAsync(bytes, bytes.Length, endPoint);

                // 等待一段时间看是否有响应
                await Task.Delay(ResponseTimeout);

                return _isInstanceRunning;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"检测其他实例时出错: {ex.Message}");
                return true; // 出错时保守起见认为有其他实例
            }
        }

        private async Task ListenForMessagesAsync(CancellationToken cancellationToken)
        {
            while (_isListening && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = await _udpClient.ReceiveAsync(cancellationToken);
                    string jsonData = Encoding.UTF8.GetString(result.Buffer);

                    ProcessReceivedJson(jsonData);
                }
                catch (OperationCanceledException)
                {
                    // 正常取消
                    break;
                }
                catch (ObjectDisposedException)
                {
                    // UDP客户端已关闭，正常退出
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"接收消息时出错: {ex.Message}");
                }
            }
        }

        private void ProcessReceivedJson(string jsonData)
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(jsonData);
                var root = doc.RootElement;

                if (root.TryGetProperty("type", out var typeProperty) && 
                    root.TryGetProperty("id", out var idProperty))
                {
                    string messageType = typeProperty.GetString();
                    string instanceId = idProperty.GetString();

                    if (messageType == "InstanceCheck" && instanceId != _instanceId)
                    {
                        // 收到其他实例的检测请求，发送响应
                        var responseData = new
                        {
                            id = _instanceId,
                            type = "InstanceResponse",
                            timestamp = DateTime.UtcNow
                        };

                        string jsonResponse = JsonSerializer.Serialize(responseData);
                        byte[] bytes = Encoding.UTF8.GetBytes(jsonResponse);

                        var endPoint = new IPEndPoint(IPAddress.Parse(MulticastAddress), Port);
                        _ = _udpClient.SendAsync(bytes, bytes.Length, endPoint); // 不等待

                        // 标记为有其他实例正在运行
                        _isInstanceRunning = true;
                    }
                    else if (messageType == "InstanceResponse" && instanceId != _instanceId)
                    {
                        // 收到其他实例的响应，标记为有其他实例正在运行
                        _isInstanceRunning = true;
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"解析JSON失败: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _isListening = false;
            _cts?.Cancel();
            try
            {
                _udpClient?.DropMulticastGroup(IPAddress.Parse(MulticastAddress));
                _udpClient?.Close();
                _udpClient?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"释放资源时出错: {ex.Message}");
            }
        }
    }
}