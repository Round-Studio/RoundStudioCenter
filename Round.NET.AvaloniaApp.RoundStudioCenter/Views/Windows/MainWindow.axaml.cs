using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using FluentAvalonia.UI.Controls;
using System.Diagnostics;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls;
using Round.NET.AvaloniaApp.RoundStudioCenter.Views.Pages;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        var btn = (Button)sender;
        btn.Content = WindowState == WindowState.Maximized
            ? new PathIcon()
            {
                Width = 16,
                Height = 16,
                Margin = new Thickness(0, 3, 0, 0),
                Data = StreamGeometry.Parse(
                    "M832 704H704v128c0 70.692-57.308 128-128 128H192c-70.692 0-128-57.308-128-128V448c0-70.692 57.308-128 128-128h128V192c0-70.692 57.308-128 128-128h384c70.692 0 128 57.308 128 128v384c0 70.692-57.308 128-128 128zM192 384c-35.346 0-64 28.654-64 64v384c0 35.346 28.654 64 64 64h384c35.346 0 64-28.654 64-64V448c0-35.346-28.654-64-64-64H192z m704-192c0-35.346-28.654-64-64-64H448c-35.346 0-64 28.654-64 64v128h192c70.692 0 128 57.308 128 128v192h128c35.346 0 64-28.654 64-64V192z")
            }
            : new PathIcon()
            {
                Margin = new Thickness(0, 1, 0, 0),
                Width = 16,
                Height = 16,
                Data = StreamGeometry.Parse(
                    "M233.301333 128A105.301333 105.301333 0 0 0 128 233.301333v557.397334A105.301333 105.301333 0 0 0 233.301333 896h557.397334A105.301333 105.301333 0 0 0 896 790.698667V233.301333A105.301333 105.301333 0 0 0 790.698667 128H233.301333z m-18.602666 105.301333c0-10.24 8.32-18.602667 18.602666-18.602666h557.397334c10.24 0 18.602667 8.32 18.602666 18.602666v557.397334c0 10.24-8.32 18.602667-18.602666 18.602666H233.301333a18.56 18.56 0 0 1-18.602666-18.602666V233.301333z")
            };
    }

    // 标题栏拖拽逻辑
    private void TitleBar_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }

    private void InputElement_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        var btn = Maxbtn;
        btn.Content = WindowState == WindowState.Maximized
            ? new PathIcon()
            {
                Width = 12,
                Height = 12,
                Margin = new Thickness(0, 3, 0, 0),
                Data = StreamGeometry.Parse(
                    "M832 704H704v128c0 70.692-57.308 128-128 128H192c-70.692 0-128-57.308-128-128V448c0-70.692 57.308-128 128-128h128V192c0-70.692 57.308-128 128-128h384c70.692 0 128 57.308 128 128v384c0 70.692-57.308 128-128 128zM192 384c-35.346 0-64 28.654-64 64v384c0 35.346 28.654 64 64 64h384c35.346 0 64-28.654 64-64V448c0-35.346-28.654-64-64-64H192z m704-192c0-35.346-28.654-64-64-64H448c-35.346 0-64 28.654-64 64v128h192c70.692 0 128 57.308 128 128v192h128c35.346 0 64-28.654 64-64V192z")
            }
            : new PathIcon()
            {
                Margin = new Thickness(0, 1, 0, 0),
                Width = 12,
                Height = 12,
                Data = StreamGeometry.Parse(
                    "M233.301333 128A105.301333 105.301333 0 0 0 128 233.301333v557.397334A105.301333 105.301333 0 0 0 233.301333 896h557.397334A105.301333 105.301333 0 0 0 896 790.698667V233.301333A105.301333 105.301333 0 0 0 790.698667 128H233.301333z m-18.602666 105.301333c0-10.24 8.32-18.602667 18.602666-18.602666h557.397334c10.24 0 18.602667 8.32 18.602666 18.602666v557.397334c0 10.24-8.32 18.602667-18.602666 18.602666H233.301333a18.56 18.56 0 0 1-18.602666-18.602666V233.301333z")
            };
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void NavigationView_OnSelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs e)
    {
        var tag = ((NavigationViewItem)((NavigationView)sender!).SelectedItem!).Tag.ToString();
        switch (tag)
        {
            case "Home":
                MainFrame.NavigateTo(new MainView());
                break;
            case "Apps":
                MainFrame.NavigateTo(new Apps());
                break;
            case "Resources":
                MainFrame.NavigateTo(new Resources());
                break;
            case "Library":
                MainFrame.NavigateTo(new Library());
                break;
            case "AboutUs":
                MainFrame.NavigateTo(new AboutUs());
                break;
            case "Docs":
                //MainFrame.NavigateTo(new Docs());
                // 打开默认浏览器并导航到指定URL
                Process.Start(new ProcessStartInfo("https://gh.roundstudio.top") { UseShellExecute = true });
                break;
            case "Settings":
                MainFrame.NavigateTo(new Settings());
                break;
            case "Accounts":
                MainFrame.NavigateTo(new Accounts());
                break;
            case "About":
                MainFrame.NavigateTo(new About());
                break;
        }
    }
}