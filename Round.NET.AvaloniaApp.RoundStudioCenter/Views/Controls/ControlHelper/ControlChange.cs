using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.ControlHelper;

public class ControlChange
{
    public static void ChangeLabelText(Label label, string text, IBrush foreground = null)
    {
        Task.Run(() =>
        {
            Dispatcher.UIThread.Invoke(() => label.Opacity = 0);
            Thread.Sleep(300);
            Dispatcher.UIThread.Invoke(() => label.Content = text);

            // 如果 foreground 为 null，使用默认颜色（白色）
            Dispatcher.UIThread.Invoke(() => label.Foreground = foreground ?? Brushes.White);

            Dispatcher.UIThread.Invoke(() => label.Opacity = 1);
        });
    }
}