using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Entry.Assets.Center;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.AssetsCenter;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Items;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages.ResourcesSubPages;

public partial class AssetsCenterPage : UserControl
{
    public AssetsCenterPage()
    {
        InitializeComponent();
    }
    public void LoadAssets(AssetsIndexItemEntry info)
    {
        NameBox.Text = info.Name;
        ProfileBox.Text = info.Description;
        
        Task.Run(() =>
        {
            GetAssetInfo.GetAssetItemInfo(info).Result.Versions.ForEach(x =>
            {
                Dispatcher.UIThread.Invoke(() =>
                {
                    var it = new VersionItem(x.Version);
                    it.DownloadClick = () =>
                    {
                        Download(x);
                    };
                    ResultBox.Children.Add(it);
                });
            });
        });
    }

    public void Download(AssetInfoEntry.VersionInfo info)
    {
        /*var dow = new DownloadCenterAssetItem();
        var cont = new TaskControl()
        {
            BoxContent = dow,
            TaskName = $"下载 RMCL 资源"
        };
        cont.RunTask();
        dow.Download(info,PathsDictionary.PathDictionary.SkinFolder);
        var uuid1 = TaskManager.AddTask(cont);
        dow.DownloadCompleted = () => TaskManager.DeleteTask(uuid1);*/
    }
}