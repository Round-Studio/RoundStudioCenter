using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using FluentAvalonia.UI.Controls;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Windows;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages;

public partial class MainView : UserControl
{
    private readonly MainWindow _mainWindow;

    public MainView()
    {
        InitializeComponent();
        _mainWindow = new MainWindow();
        AddNewCard("推荐", new FlipView { Height = 350 }, "RecommendsCard");
    }
    public void AddNewCard(string Title, Control Content, string Tag)
    {
        var border = new Border { CornerRadius = new CornerRadius(5) ,Background = new SolidColorBrush(Colors.Transparent, .4),Margin = new Thickness(0,0,0,4)};
        var grid = new Grid { Margin = new Thickness(12)};
        /*
        grid.Children.Add(new Button
        {
            Content = new SymbolIcon
            {
                Symbol = Symbol.Cancel, VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            },
            Width = 32, Height = 32, HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Top, BorderThickness = new Thickness(0), Background = null,
            Margin = new Thickness(2, 0)
        });
        */
        var stackPanel = new StackPanel();
        stackPanel.Children.Add(new Label
            { FontSize = 24, FontWeight = FontWeight.Bold, Margin = new Thickness(0, 0, 0, 4), Content = Title });
        stackPanel.Children.Add(Content);
        stackPanel.Tag = Tag;
        grid.Children.Add(stackPanel);
        border.Child = grid;
        MainScreen.Children.Add(border);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        _mainWindow.Navigate(new Resources("RMCL"));
    }
}