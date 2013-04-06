using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;

namespace HenryLP.DAL.Common
{
    public class Imaginator
    {
        /// <summary>
        /// 在图片上面写文字
        /// </summary>
        /// <param name="source_file">源图片文件路径</param>
        /// <param name="strText">文字</param>
        public static void WriteText(string source_file, string strText)
        {
            Image image = Image.FromFile(source_file);
            System.Drawing.Image newimage = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(newimage);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            Font f = new Font("Arial", 12);
            Brush b = new SolidBrush(Color.Red);
            g.DrawString(strText, f, b, image.Width - 170, image.Height - 30);
            g.Dispose();
            image.Dispose();
            newimage.Save(source_file);
            newimage.Dispose();
        }

        /// <summary>
        /// 在图片上面写文字
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="des_file">目标文件路径</param>
        /// <param name="strText">文字</param>
        public static void WriteText(Stream stream, string des_file, string strText)
        {
            Image image = Image.FromStream(stream);
            System.Drawing.Image newimage = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(newimage);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            Font f = new Font("Arial", 12);
            Brush b = new SolidBrush(Color.Red);
            g.DrawString(strText, f, b, image.Width - 170, image.Height - 20);
            g.Dispose();
            image.Dispose();
            newimage.Save(des_file);
            newimage.Dispose();
        }

        static Image image_logo = null;
        public static void MergerImg_WriteText(string source_file, string source_file2, string strText)
        {
            if (image_logo == null)
            {
                image_logo = Image.FromFile(source_file2);
            }
            Image image = Image.FromFile(source_file);
            System.Drawing.Image newimage = new Bitmap(570, 312, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(newimage);
            g.DrawImage(image, 0, 0, 570, 312);
            Font f = new Font("Arial", 14);
            Brush b = new SolidBrush(Color.Blue);
            g.DrawString(strText, f, b, 400, 290);
            g.DrawImage(image_logo, 280, 200, 266, 114);
            g.Dispose();
            image.Dispose();
            newimage.Save(source_file, ImageFormat.Jpeg);
            newimage.Dispose();
        }

        public static void MergerImg(string source_file, string source_file2)
        {
            Image image = Image.FromFile(source_file);
            if (image_logo == null)
            {
                image_logo = Image.FromFile(source_file2);
            }
            System.Drawing.Image newimage = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(newimage);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            g.DrawImage(image_logo, 80, 110, 133, 57);
            g.Dispose();
            image.Dispose();
            newimage.Save(source_file, ImageFormat.Jpeg);
            newimage.Dispose();
        }

        /// <summary>
        /// 生成并保存缩略图(Image.GetThumbnailImage的实现)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="des_file"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void SaveThumbnail(Stream stream, string des_file, int width, int height)
        {
            Image oImage = Image.FromStream(stream);

            if (oImage.Width < width && oImage.Height < height)
            {
                width = oImage.Width;
                height = oImage.Height;
            }

            int iWidth, iHeight;
            if (oImage.Width > oImage.Height)
            {
                if (oImage.Width > width)
                {
                    iWidth = width;
                    iHeight = (oImage.Height * width) / oImage.Width;
                }
                else
                {
                    iWidth = oImage.Width;
                    iHeight = oImage.Height;
                }
            }
            else
            {
                if (oImage.Height > height)
                {
                    iWidth = (oImage.Width * height) / oImage.Height;
                    iHeight = height;
                }
                else
                {
                    iWidth = oImage.Width;
                    iHeight = oImage.Height;
                }
            }

            Bitmap bitmap = new Bitmap(iWidth, iHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //graphics.SmoothingMode = SmoothingMode.HighQuality;

            try
            {
                graphics.DrawImage(oImage, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(0, 0, oImage.Width, oImage.Height), GraphicsUnit.Pixel);
                bitmap.Save(des_file, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                graphics.Dispose();
                bitmap.Dispose();
                oImage.Dispose();
            }
        }

        public void SaveThumbnail(string source_file, string des_file, int width, int height)
        {

            //source_file = @"C:\Inetpub\wwwroot\House\WebSite1\HousePic\2011\3\8219e9f9-e569-418b-b399-473797784fbf.jpg";
            if (!File.Exists(source_file))
            {
                return;
            }
            //File.Copy(source_file, des_file, true);
            Image oImage = Image.FromFile(source_file, true);

            if (oImage.Width < width && oImage.Height < height)
            {
                return;
            }

            int iWidth, iHeight;
            if (oImage.Width > oImage.Height)
            {
                if (oImage.Width > width)
                {
                    iWidth = width;
                    iHeight = (oImage.Height * width) / oImage.Width;
                }
                else
                {
                    iWidth = oImage.Width;
                    iHeight = oImage.Height;
                }
            }
            else
            {
                if (oImage.Height > height)
                {
                    iWidth = (oImage.Width * height) / oImage.Height;
                    iHeight = height;
                }
                else
                {
                    iWidth = oImage.Width;
                    iHeight = oImage.Height;
                }
            }

            Bitmap bitmap = new Bitmap(iWidth, iHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //graphics.SmoothingMode = SmoothingMode.HighQuality;

            try
            {
                graphics.DrawImage(oImage, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(0, 0, oImage.Width, oImage.Height), GraphicsUnit.Pixel);
                bitmap.Save(des_file, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                graphics.Dispose();
                bitmap.Dispose();
                oImage.Dispose();
            }
        }
    }
}
