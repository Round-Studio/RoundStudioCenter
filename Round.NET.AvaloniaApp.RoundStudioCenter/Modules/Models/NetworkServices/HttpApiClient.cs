using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.NetworkServices;

public static class HttpApiClient
{
    private static readonly HttpClient _httpClient = new HttpClient();

    // 泛型方法：发送GET请求并反序列化结果
    public static async Task<T> GetAsync<T>(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"API请求失败: {ex.Message}", ex);
        }
    }

    // 带请求头的版本
    public static async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        foreach (var header in headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }
}