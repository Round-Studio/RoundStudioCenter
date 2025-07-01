using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using RMCL.Base.Entry.Assets.Center;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Classes.RMCLAssetsCenter;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Download;

public partial class DownloadCenterAssetItem : UserControl
{
    public Action DownloadCompleted;
    public DownloadCenterAssetItem()
    {
        InitializeComponent();
    }

    public int DownloadCount { get; set; } = 0;
    public void Download(AssetInfoEntry.VersionInfo info,string downloadFolder)
    {
        Directory.CreateDirectory(downloadFolder);
        ProgressTextBox.Text = $"正在下载第 0/{info.Files.Count} 个文件：0.00%";
        
        void Completed()
        {
            if (DownloadCount == info.Files.Count) DownloadCompleted.Invoke();
        }

        Task.Run(() =>
        {
            info.Files.ForEach(async x =>
            {
                DownloadService downloadService = new DownloadService();
                downloadService.DownloadFileCompleted += (s, e) => Completed();
                downloadService.DownloadProgressChanged += (s, e) =>
                {
                    Dispatcher.UIThread.Invoke(() =>
                    {
                        DownloadProgress.Value = e.ProgressPercentage;
                        ProgressTextBox.Text = $"正在下载第 {DownloadCount+1}/{info.Files.Count} 个文件：{e.ProgressPercentage:0.00}";
                    });
                };
                await downloadService.DownloadFileTaskAsync($"{RouterIndex.RootUrl}{x.DownloadUrl}", Path.Combine(downloadFolder, x.Name));
            });
        });
    }
}