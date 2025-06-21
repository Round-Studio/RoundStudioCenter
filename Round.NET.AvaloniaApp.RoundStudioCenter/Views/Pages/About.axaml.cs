using System.Reflection;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages;

public partial class About : UserControl
{
    public About()
    {
        InitializeComponent();
        VersionBox.Text = VersionBox.Text.Replace("Version", Assembly.GetEntryAssembly()?.GetName().Version.ToString());
    }
}