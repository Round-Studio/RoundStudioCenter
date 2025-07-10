using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Items;

public partial class VersionItem : UserControl
{
    public VersionItem(string version)
    {
        InitializeComponent();
        TitleBox.Text = version;
    }
    
    public Action DownloadClick;

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        DownloadClick.Invoke();
    }
}