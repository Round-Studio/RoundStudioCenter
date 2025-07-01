// ItemBox.cs

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.Item;

public class ItemBox : TemplatedControl
{
    // 定义 Content 属性
    public static readonly StyledProperty<object> ContentProperty =
        ContentControl.ContentProperty.AddOwner<TemplatedControl>();

    public object? Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    // 定义 ContentTemplate 属性（可选）
    public static readonly StyledProperty<IDataTemplate?> ContentTemplateProperty =
        ContentControl.ContentTemplateProperty.AddOwner<ItemBox>();

    public IDataTemplate? ContentTemplate
    {
        get => GetValue(ContentTemplateProperty);
        set => SetValue(ContentTemplateProperty, value);
    }
}