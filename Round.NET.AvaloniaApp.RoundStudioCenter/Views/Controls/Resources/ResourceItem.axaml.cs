using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Entry.Assets.Center;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Resources;

public partial class ResourceItem : UserControl
{
    private AssetsIndexItemEntry _assetsIndexItem;
    public Action<AssetsIndexItemEntry> DownloadButtonClicked { get; set; }
    public ResourceItem()
    {
        InitializeComponent();
    }
    private void Button_Click(object? sender, RoutedEventArgs e)
    {
        DownloadButtonClicked.Invoke(_assetsIndexItem);
    }

    public void LoadShow(AssetsIndexItemEntry item)
    {
        _assetsIndexItem = item;
        AssetsName.Text = item.Name;
        AssetsProfile.Text = item.Description;
    }
}