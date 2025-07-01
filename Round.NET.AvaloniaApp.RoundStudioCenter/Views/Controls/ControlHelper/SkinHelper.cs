using System;
using System.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using SkiaSharp;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Views.Controls.ControlHelper;

public static class SkinHelper
{
    public static Bitmap Base64ToBitmap(string base64String)
    {
        if (string.IsNullOrEmpty(base64String))
            throw new ArgumentNullException(nameof(base64String));

        byte[] imageBytes = Convert.FromBase64String(base64String);
        using (var ms = new MemoryStream(imageBytes))
        {
            return new Bitmap(ms);
        }
    }

    public static Bitmap CropAndScaleBitmapOptimized(Bitmap source, PixelRect cropArea, int scaleFactor = 1)
    {
        if (scaleFactor < 1)
            throw new ArgumentOutOfRangeException(nameof(scaleFactor), "Scale factor must be at least 1");

        using (var memoryStream = new MemoryStream())
        {
            source.Save(memoryStream);
            memoryStream.Position = 0;

            using (var original = SKBitmap.Decode(memoryStream))
            {
                if (original == null)
                    throw new InvalidOperationException("Failed to decode image");

                // 检查裁剪区域
                if (cropArea.X < 0 || cropArea.Y < 0 ||
                    cropArea.Right > original.Width ||
                    cropArea.Bottom > original.Height)
                {
                    throw new ArgumentOutOfRangeException(nameof(cropArea), "Invalid crop area");
                }

                // 创建裁剪区域
                var subset = new SKBitmap();
                if (!original.ExtractSubset(subset, new SKRectI(cropArea.X, cropArea.Y,
                        cropArea.Right, cropArea.Bottom)))
                {
                    throw new InvalidOperationException("Failed to crop image");
                }

                // 如果需要缩放
                if (scaleFactor > 1)
                {
                    using (subset)
                    {
                        var scaledWidth = cropArea.Width * scaleFactor;
                        var scaledHeight = cropArea.Height * scaleFactor;

                        // 使用缩放
                        var scaled = new SKBitmap(scaledWidth, scaledHeight);
                        subset.ScalePixels(scaled, SKFilterQuality.None);

                        using (scaled)
                        using (var image = SKImage.FromBitmap(scaled))
                        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                        using (var outStream = new MemoryStream())
                        {
                            data.SaveTo(outStream);
                            outStream.Position = 0;
                            return new Bitmap(outStream);
                        }
                    }
                }
                else
                {
                    // 不需要缩放，直接返回裁剪结果
                    using (subset)
                    using (var image = SKImage.FromBitmap(subset))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                    using (var outStream = new MemoryStream())
                    {
                        data.SaveTo(outStream);
                        outStream.Position = 0;
                        return new Bitmap(outStream);
                    }
                }
            }
        }
    }
}