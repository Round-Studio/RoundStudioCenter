using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls;

public partial class Frame : UserControl
{
    public Frame()
    {
        InitializeComponent();
    }

    public void NavigateTo(Control page)
    {
        this.Opacity = 0;
        this.Margin = new Thickness(0,-100,0,100);
        Task.Run(() =>
        {
            Thread.Sleep(300);
            Dispatcher.UIThread.Invoke(() =>
                this.Margin = new Thickness(0,100,0,-100));
            Thread.Sleep(200);
            Dispatcher.UIThread.InvokeAsync(() =>
                this.Content = page);
            Dispatcher.UIThread.Invoke(()=>this.Opacity = 1);
            Dispatcher.UIThread.Invoke(() =>
                this.Margin = new Thickness(0));
        });
    }
}