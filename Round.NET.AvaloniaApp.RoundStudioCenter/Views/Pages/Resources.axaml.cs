using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages;

public partial class Resources : UserControl
{
    public Resources(string card)
    {
        InitializeComponent();
        Navigate(card);
    }

    private void Navigate(string card)
    {
        switch (card)
        {
            case "Main":
                break;
            case "RMCL":
                break;
            case "Plugin":
                break;
            case "Resource":
                break;
        }
    }

    private void SearchBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}