using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Enterprise.Common
{
    public class ImageOp
    {
        #region 生成缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="oImage"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="SaveFilename"></param>
        /// <param name="SavaPath"></param>
        /// <param name="isMapPath"></param>
        public static void SaveToImg(Image oImage, int width, int height, string SaveFilename, string SavaPath, bool isMapPath = false)
        {
            //生成原图
            int oWidth = oImage.Width; //原图宽度
            int oHeight = oImage.Height; //原图高度
            int tWidth = width; //设置缩略图初始宽度
            int tHeight = height; //设置缩略图初始高度
            //按比例计算出缩略图的宽度和高度
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(System.Convert.ToDouble(oHeight) * (System.Convert.ToDouble(tWidth) / System.Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(System.Convert.ToDouble(oWidth) * (System.Convert.ToDouble(tHeight) / System.Convert.ToDouble(oHeight)));
            }

            //生成缩略原图
            Bitmap tImage = new Bitmap(tWidth, tHeight);

            Graphics g = Graphics.FromImage(tImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度

            g.Clear(Color.White); //清空画布并以透明背景色填充
            int kWidth = width - tWidth;
            int kHeight = height - tHeight;
            g.DrawImage(oImage, new Rectangle(kWidth / 2, kHeight / 2, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);

            string UserPath = SavaPath;
            if (!isMapPath)
            {
                UserPath = HttpContext.Current.Server.MapPath(SavaPath);
            }

            if (!Directory.Exists(UserPath))
            {
                Directory.CreateDirectory(UserPath);
            }
            string tFullName = UserPath + SaveFilename;
            try
            {
                //以JPG格式保存图片
                tImage.Save(tFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //释放资源
                oImage.Dispose();
                g.Dispose();
                tImage.Dispose();
            }
            //HttpContext.Current.Response.Write(SaveFilename + "|");
            //HttpContext.Current.Response.StatusCode = 200;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="postedFile">图片文件</param>
        /// <param name="width">生成图片的宽度</param>
        /// <param name="height">生成图片的高度</param>
        /// <param name="SaveFilename">存储文件名</param>
        /// <param name="path">存储路径</param>
        public static void SaveToImg(HttpPostedFileBase postedFile, int width, int height, string SaveFilename, string SavaPath, bool isMapPath = false)
        {
            //生成原图
            Byte[] oFileByte = new byte[postedFile.ContentLength];
            System.IO.Stream oStream = postedFile.InputStream;
            System.Drawing.Image oImage = System.Drawing.Image.FromStream(oStream);
            int oWidth = oImage.Width; //原图宽度
            int oHeight = oImage.Height; //原图高度
            int tWidth = width; //设置缩略图初始宽度
            int tHeight = height; //设置缩略图初始高度
            //按比例计算出缩略图的宽度和高度
            if (oWidth >= oHeight)
            {
                tHeight = (int)Math.Floor(System.Convert.ToDouble(oHeight) * (System.Convert.ToDouble(tWidth) / System.Convert.ToDouble(oWidth)));
            }
            else
            {
                tWidth = (int)Math.Floor(System.Convert.ToDouble(oWidth) * (System.Convert.ToDouble(tHeight) / System.Convert.ToDouble(oHeight)));
            }

            //生成缩略原图
            Bitmap tImage = new Bitmap(tWidth, tHeight);

            Graphics g = Graphics.FromImage(tImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度

            g.Clear(Color.White); //清空画布并以透明背景色填充
            int kWidth = width - tWidth;
            int kHeight = height - tHeight;
            g.DrawImage(oImage, new Rectangle(kWidth / 2, kHeight / 2, tWidth, tHeight), new Rectangle(0, 0, oWidth, oHeight), GraphicsUnit.Pixel);

            string UserPath = SavaPath;
            if (!isMapPath)
            {
                UserPath = HttpContext.Current.Server.MapPath(SavaPath);
            }

            if (!Directory.Exists(UserPath))
            {
                Directory.CreateDirectory(UserPath);
            }
            string tFullName = UserPath + SaveFilename;
            try
            {
                //以JPG格式保存图片
                tImage.Save(tFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //释放资源
                oImage.Dispose();
                g.Dispose();
                tImage.Dispose();
            }
            //HttpContext.Current.Response.Write(SaveFilename + "|");
            //HttpContext.Current.Response.StatusCode = 200;
        }


        #endregion
    }
}
