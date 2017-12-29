using Enterprise.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace Captchas
{
    public class Captcha
    {
        #region 验证码1.0
        /// <summary>
        /// 获取验证码图
        /// </summary>
        /// <param name="length"></param>
        /// <param name="checkcode"></param>
        /// <returns></returns>
        public byte[] GetImage(int length, out string checkcode)
        {
            checkcode = RandomText.String(length);
            Random random = new Random();

            Font font = new Font("Comic Sans MS", 18, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);
            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Bitmap bitmap = new Bitmap((int)Math.Ceiling((double)(length * 18)), 27, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                ///画图片的背景噪音线
                for (int i = 0; i < 5; i++)
                {
                    int x1 = random.Next(bitmap.Width);
                    int x2 = random.Next(bitmap.Width);
                    int y1 = random.Next(bitmap.Height);
                    int y2 = random.Next(bitmap.Height);
                    graphics.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                graphics.DrawString(checkcode, font, Brushes.Black, new RectangleF(0f, 0f, (float)bitmap.Width, (float)bitmap.Height), stringFormat);

                ///画图片的前景噪音点
                for (int i = 0; i < 20; i++)
                {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);

                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
            }
            bitmap = WaveDistortion(bitmap);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            bitmap.Dispose();

            return ms.ToArray();
        }

        #region 波纹扭曲
        /// <summary>
        /// 波纹扭曲
        /// </summary>
        /// <param name="bitmap">未处理的比特图形</param>
        /// <returns></returns>
        private Bitmap WaveDistortion(Bitmap bitmap)
        {
            Random rnd = new Random();

            var width = bitmap.Width;
            var height = bitmap.Height;

            Bitmap destBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            {
                Color foreColor = Color.FromArgb(rnd.Next(10, 100), rnd.Next(10, 100), rnd.Next(10, 100));
                Color backColor = Color.FromArgb(rnd.Next(200, 250), rnd.Next(200, 250), rnd.Next(200, 250));

                using (Graphics g = Graphics.FromImage(destBmp))
                {
                    g.Clear(backColor);

                    // periods 时间
                    double rand1 = rnd.Next(710000, 1200000) / 10000000.0;
                    double rand2 = rnd.Next(710000, 1200000) / 10000000.0;
                    double rand3 = rnd.Next(710000, 1200000) / 10000000.0;
                    double rand4 = rnd.Next(710000, 1200000) / 10000000.0;

                    // phases  相位
                    double rand5 = rnd.Next(0, 31415926) / 10000000.0;
                    double rand6 = rnd.Next(0, 31415926) / 10000000.0;
                    double rand7 = rnd.Next(0, 31415926) / 10000000.0;
                    double rand8 = rnd.Next(0, 31415926) / 10000000.0;

                    // amplitudes 振幅
                    double rand9 = rnd.Next(330, 420) / 110.0;
                    double rand10 = rnd.Next(330, 450) / 110.0;
                    double amplitudesFactor = rnd.Next(5, 6) / 12.0;//振幅小点防止出界
                    double center = width / 2.0;

                    //wave distortion 波纹扭曲
                    BitmapData destData = destBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, destBmp.PixelFormat);
                    BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                    for (var x = 0; x < width; x++)
                    {
                        for (var y = 0; y < height; y++)
                        {
                            var sx = x + (Math.Sin(x * rand1 + rand5)
                                        + Math.Sin(y * rand2 + rand6)) * rand9 - width / 2 + center + 1;
                            var sy = y + (Math.Sin(x * rand3 + rand7)
                                        + Math.Sin(y * rand4 + rand8)) * rand10 * amplitudesFactor;

                            int color, color_x, color_y, color_xy;
                            Color overColor = Color.Empty;

                            if (sx < 0 || sy < 0 || sx >= width - 1 || sy >= height - 1)
                            {
                                continue;
                            }
                            else
                            {
                                color = BitmapDataColorAt(srcData, (int)sx, (int)sy).B;
                                color_x = BitmapDataColorAt(srcData, (int)(sx + 1), (int)sy).B;
                                color_y = BitmapDataColorAt(srcData, (int)sx, (int)(sy + 1)).B;
                                color_xy = BitmapDataColorAt(srcData, (int)(sx + 1), (int)(sy + 1)).B;
                            }

                            if (color == 255 && color_x == 255 && color_y == 255 && color_xy == 255)
                            {
                                continue;
                            }
                            else if (color == 0 && color_x == 0 && color_y == 0 && color_xy == 0)
                            {
                                overColor = Color.FromArgb(foreColor.R, foreColor.G, foreColor.B);
                            }

                            else
                            {
                                double frsx = sx - Math.Floor(sx);
                                double frsy = sy - Math.Floor(sy);
                                double frsx1 = 1 - frsx;
                                double frsy1 = 1 - frsy;

                                double newColor =
                                     color * frsx1 * frsy1 +
                                     color_x * frsx * frsy1 +
                                     color_y * frsx1 * frsy +
                                     color_xy * frsx * frsy;

                                if (newColor > 255) newColor = 255;
                                newColor = newColor / 255;
                                double newcolor0 = 1 - newColor;

                                int newred = Math.Min((int)(newcolor0 * foreColor.R + newColor * backColor.R), 255);
                                int newgreen = Math.Min((int)(newcolor0 * foreColor.G + newColor * backColor.G), 255);
                                int newblue = Math.Min((int)(newcolor0 * foreColor.B + newColor * backColor.B), 255);
                                overColor = Color.FromArgb(newred, newgreen, newblue);
                            }
                            BitmapDataColorSet(destData, x, y, overColor);
                        }
                    }
                    destBmp.UnlockBits(destData);
                    bitmap.UnlockBits(srcData);
                }
                if (bitmap != null)
                    bitmap.Dispose();
            }
            return destBmp;
        }
        #endregion

        /// <summary>
        /// 获得 BitmapData 指定坐标的颜色信息
        /// </summary>
        /// <param name="srcData">从图像数据获得颜色 必须为 PixelFormat.Format24bppRgb 格式图像数据</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>x,y 坐标的颜色数据</returns>
        /// <remarks>
        /// Format24BppRgb 已知X，Y坐标，像素第一个元素的位置为Scan0+(Y*Stride)+(X*3)。
        /// 这是blue字节的位置，接下来的2个字节分别含有green、red数据。
        /// </remarks>
        private Color BitmapDataColorAt(BitmapData srcData, int x, int y)
        {
            byte[] rgbValues = new byte[3];
            Marshal.Copy((IntPtr)((int)srcData.Scan0 + ((y * srcData.Stride) + (x * 3))), rgbValues, 0, 3);
            return Color.FromArgb(rgbValues[2], rgbValues[1], rgbValues[0]);
        }

        /// <summary>
        /// 设置 BitmapData 指定坐标的颜色信息
        /// </summary>
        /// <param name="destData">设置图像数据的颜色 必须为 PixelFormat.Format24bppRgb 格式图像数据</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color">待设置颜色</param>
        /// <remarks>
        /// Format24BppRgb 已知X，Y坐标，像素第一个元素的位置为Scan0+(Y*Stride)+(X*3)。
        /// 这是blue字节的位置，接下来的2个字节分别含有green、red数据。
        /// </remarks>
        private void BitmapDataColorSet(BitmapData destData, int x, int y, Color color)
        {
            byte[] rgbValues = new byte[3] { color.B, color.G, color.R };
            Marshal.Copy(rgbValues, 0, (IntPtr)((int)destData.Scan0 + ((y * destData.Stride) + (x * 3))), 3);
        }
    }

    public class RandomText
    {
        static readonly string[] source ={"2","3","4","5","6","7","8","9",
            "a","b","c","d","e","f","g","h","j","k","m","n","p","q","r","s","t","u","v","w","x","y","z",
            "A","B","C","D","E","F","G","H","J","K","M","N","P","Q","R","S","T","U","V","W","X","Y","Z"};

        private static Random _random;

        static RandomText()
        {
            _random = new Random(Environment.TickCount);
        }

        public static int Number(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public static string String(int length)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = _random.Next(0, source.Length - 1);
                s.Append(source[index]);
            }

            return s.ToString();
        }

        public static string CharOnly(int length)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int c = _random.Next(97, 123);

                if (_random.Next() % 2 == 0)
                    c -= 32;

                s.Append(Convert.ToChar(c));
            }

            return s.ToString();
        } 

        #endregion


        //#region 验证码2.0
        ///// <summary>
        ///// 生成内存位图
        ///// </summary>
        ///// <param name="Code"></param>
        ///// <returns></returns>
        //public static Bitmap GetCode(out string Code)
        //{
        //    int imgWidth = 80;
        //    int imgHeight = 40;
        //    //获取随机字符
        //    Code = DateTimeHelper.GetCode_Ran(4);
        //    //颜色列表，用于验证码、噪线、噪点 
        //    Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
        //    //字体列表，用于验证码 
        //    string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };

        //    Bitmap bmp = new Bitmap(imgWidth, imgHeight);
        //    Graphics g = Graphics.FromImage(bmp);
        //    g.Clear(Color.White);
        //    Random rnd = new Random();
        //    //画噪线 
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int x1 = rnd.Next(imgWidth);
        //        int y1 = rnd.Next(imgHeight);
        //        int x2 = rnd.Next(imgWidth);
        //        int y2 = rnd.Next(imgHeight);
        //        Color clr = color[rnd.Next(color.Length)];
        //        g.DrawLine(new Pen(clr), x1, y1, x2, y2);
        //    }
        //    //画验证码字符串 
        //    for (int i = 0; i < Code.Length; i++)
        //    {
        //        string fnt = font[rnd.Next(font.Length)];
        //        Font ft = new Font(fnt, 18);
        //        Color clr = color[rnd.Next(color.Length)];
        //        g.DrawString(Code[i].ToString(), ft, new SolidBrush(clr), (float)i * 19, (float)8);
        //    }
        //    //画噪点 
        //    for (int i = 0; i < 100; i++)
        //    {
        //        int x = rnd.Next(bmp.Width);
        //        int y = rnd.Next(bmp.Height);
        //        Color clr = color[rnd.Next(color.Length)];
        //        bmp.SetPixel(x, y, clr);
        //    }
        //    //显式释放资源 
        //    // bmp.Dispose();
        //    g.Dispose();
        //    return bmp;
        //}
        ///// <summary>
        ///// 生成位图，输出到响应流
        ///// </summary>
        ///// <param name="Response"></param>
        ///// <param name="Code"></param>
        //public static void GetCode(HttpResponseBase Response, out string Code)
        //{
        //    Code = string.Empty;
        //    Bitmap bit = GetCode(out Code);

        //    ////清除该页输出缓存，设置该页无缓存 
        //    //Response.Buffer = true;
        //    //Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(0);
        //    //Response.Expires = 0;
        //    //Response.CacheControl = "no-cache";
        //    //Response.AppendHeader("Pragma", "No-Cache");

        //    Response.ClearContent();
        //    bit.Save(Response.OutputStream, ImageFormat.Png);
        //    Response.ContentType = "image/png";

        //    //释放资源
        //    bit.Dispose();
        //}
        //#endregion
    }
}