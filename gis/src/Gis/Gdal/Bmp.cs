using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gdal1
{
    public class Bmp
    {
        /// <summary>
        /// 双三次插值缩放灰度图像。
        /// </summary>
        /// <param name="image">源图像。</param>
        /// <param name="newWidth">新宽度。</param>
        /// <param name="newHeight">新高度。</param>
        /// <returns>缩放后的图像。</returns>
        public static Bitmap ResizeGrayscaleImage(Bitmap image, int newWidth, int newHeight)
        {
            // 检查源图像格式
            CheckSourceFormat(image);

            // 锁定源图像内存
            BitmapData srcData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, image.PixelFormat);

            // 新建目标图像
            Bitmap dstImage = CreateGrayscaleImage(newWidth, newHeight);
            // 锁定目标图像内存
            BitmapData dstData = dstImage.LockBits(
                new Rectangle(0, 0, newWidth, newHeight),
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            try
            {
                ResizeProcess(srcData, ref dstData);
            }
            finally
            {
                // 解锁图像内存
                dstImage.UnlockBits(dstData);
                image.UnlockBits(srcData);
            }

            return dstImage;
        }

        /// <summary>
        /// 双三次插值处理缩放。
        /// </summary>
        /// <param name="srcData">源图像数据。</param>
        /// <param name="dstData">目标图像数据。</param>
        public static void ResizeProcess(BitmapData srcData, ref BitmapData dstData)
        {
            // 获取源图像数据
            int srcWidth = srcData.Width;
            int srcHeight = srcData.Height;
            int srcStride = srcData.Stride;
            IntPtr srcPtr = srcData.Scan0;

            // 获取目标图像数据
            int dstWidth = dstData.Width;
            int dstHeight = dstData.Height;
            int dstStride = dstData.Stride;
            int dstOffset = dstStride - dstWidth;
            IntPtr dstPtr = dstData.Scan0;

            // 计算比例系数
            double xFactor = (double)srcWidth / dstWidth;
            double yFactor = (double)srcHeight / dstHeight;

            // 将源图像数据复制到托管内存中
            int srcBytes = srcStride * srcHeight;
            byte[] srcGrayData = new byte[srcBytes];
            Marshal.Copy(srcPtr, srcGrayData, 0, srcBytes);
            // 保存目标图像数据
            int dstBytes = dstStride * dstHeight;
            byte[] dstGrayData = new byte[dstBytes];
            int dst = 0;    // 下标

            // 源图像坐标点及系数
            double ox, oy, dx, dy, k1, k2;
            int ox1, oy1, ox2, oy2;
            // 目标图像像素值
            double grayValue;
            // 边界
            int ymax = srcHeight - 1;
            int xmax = srcWidth - 1;

            #region 插值
            for (int y = 0; y < dstHeight; y++)
            {
                // Y坐标
                oy = (double)y * yFactor - 0.5;
                oy1 = (int)oy;
                dy = oy - (double)oy1;

                for (int x = 0; x < dstWidth; x++, dst++)
                {
                    // X坐标
                    ox = (double)x * xFactor - 0.5f;
                    ox1 = (int)ox;
                    dx = ox - (double)ox1;

                    // 像素值归零
                    grayValue = 0;

                    for (int n = -1; n < 3; n++)
                    {
                        // Y系数
                        k1 = BiCubicInterpolator(dy - (double)n);

                        oy2 = oy1 + n;
                        if (oy2 < 0) oy2 = 0;
                        if (oy2 > ymax) oy2 = ymax;

                        for (int m = -1; m < 3; m++)
                        {
                            // X系数
                            k2 = k1 * BiCubicInterpolator((double)m - dx);

                            ox2 = ox1 + m;
                            if (ox2 < 0) ox2 = 0;
                            if (ox2 > xmax) ox2 = xmax;

                            grayValue += k2 * srcGrayData[oy2 * srcStride + ox2];
                        }
                    }
                    dstGrayData[dst] = (byte)Math.Max(0, Math.Min(255, grayValue));
                }
                dst += dstOffset;
            }
            Marshal.Copy(dstGrayData, 0, dstPtr, dstBytes);
            #endregion
        }

        /// <summary>
        /// 双三次插值器。
        /// coefficient is set to -0.5.
        /// </summary>
        /// <param name="x">X Value.</param>
        /// <returns>Bicubic cooefficient.</returns>
        private static double BiCubicInterpolator(double x)
        {
            if (x < 0) x = -x;

            double biCoef = 0;

            if (x <= 1) biCoef = (1.5 * x - 2.5) * x * x + 1;
            else if (x < 2) biCoef = ((-0.5 * x + 2.5) * x - 4) * x + 2;

            return biCoef;
        }

        /// <summary>
        /// 检查格式。
        /// </summary>
        /// <param name="original">图像。</param>
        private static void CheckSourceFormat(Bitmap original)
        {
            //if ((original.PixelFormat != PixelFormat.Format8bppIndexed) ||
            //    (IsGrayscale(original) == false))
            //{
            //    throw new Exception("Source pixel format is not supported.");
            //}
        }

        /// <summary>
        /// 判断位图是不是8位灰度。
        /// </summary>
        /// <param name="original">位图。</param>
        /// <returns>判断结果。</returns>
        public static bool IsGrayscale(Bitmap original)
        {
            bool ret = false;

            // 检查像素格式
            if (original.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ret = true;
                // 检查调色板
                ColorPalette palette = original.Palette;
                Color color;

                for (int i = 0; i < 256; i++)
                {
                    color = palette.Entries[i];
                    if ((color.R != i) || (color.G != i) || (color.B != i))
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 新建8位灰度位图。
        /// </summary>
        /// <param name="width">长。</param>
        /// <param name="height">宽。</param>
        /// <returns>新建8位灰度位图。</returns>
        public static Bitmap CreateGrayscaleImage(int width, int height)
        {
            // 新建图像
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            // 设置灰度图像的调色板
            SetGrayscalePalette(bitmap);

            return bitmap;
        }

        /// <summary>
        /// 设置灰度位图调色板。
        /// </summary>
        /// <param name="original">灰度位图。</param>
        public static void SetGrayscalePalette(Bitmap original)
        {
            // 检查像素格式
            if (original.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new Exception("Source image is not 8 bpp image.");

            // 获取调色板
            ColorPalette palette = original.Palette;
            // init palette
            for (int i = 0; i < 256; i++)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }
            // 设置调色板
            original.Palette = palette;
        }
    }
}
