using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Entry.Assets.Center;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Enums;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.AssetsCenter;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Resources;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages.ResourcesSubPages;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages;

public partial class Resources : UserControl
{
    public Resources()
    {
        InitializeComponent();
        LoadIndex("", AssetsTypeEnum.Skin);
    }
    
    public List<AssetsIndexItemEntry> AssetsIndex { get; set; }

    public AssetsTypeEnum GetType(string id)
    {
        return id switch
        {
            "Plugin" => AssetsTypeEnum.Plugin,
            "Skin" => AssetsTypeEnum.Skin,
            "Code" => AssetsTypeEnum.Code,
        };
    }

    public void LoadIndex(string key,AssetsTypeEnum type)
    {
        LoadingBox.IsVisible = true;
        NullBox.IsVisible = false;
        AssetsList.Children.Clear();
        AssetsList.IsVisible = false;
        
        Task.Run(async () =>
        {
            switch (type)
            {
                case AssetsTypeEnum.Plugin:
                    AssetsIndex = await GetIndex.GetPluginIndex();
                    break;
                case AssetsTypeEnum.Skin:
                    AssetsIndex = await GetIndex.GetSkinIndex();
                    break;
                case AssetsTypeEnum.Code:
                    AssetsIndex = await GetIndex.GetCodeIndex();
                    break;
            }

            var matchingItems = !string.IsNullOrEmpty(key)
                ? AssetsIndex.Where(x => x.Name.Contains(key) || x.Description.Contains(key)).ToList()
                : AssetsIndex;
            matchingItems.ForEach(x => { x.Type = type; });
            UpdateUI(matchingItems);
        });
    }

    public void UpdateUI(List<AssetsIndexItemEntry> ls)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            LoadingBox.IsVisible = true;
            NullBox.IsVisible = false;

            if (ls.Count == 0)
            {
                LoadingBox.IsVisible = false;
                NullBox.IsVisible = true;
                
                return;
            }
            
            ls.ForEach(x =>
            {
                var item = new ResourceItem();
                AssetsList.Children.Add(item);
                /*item.DownloadButtonClicked = entry =>
                {
                    var page = new AssetsCenterPage();
                    Core.Models.Classes.Core.ChildFrame.Show(page);
                    page.LoadAssets(entry);
                };*/
                item.LoadShow(x);
            });
            AssetsList.IsVisible = true;
            LoadingBox.IsVisible = false;
            NullBox.IsVisible = false;
        });
    }

    private void SearchBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var type = GetType(((ComboBoxItem)AssetsType.SelectedItem).Tag.ToString());
        LoadIndex(SearchBox.Text, type);
    }
}