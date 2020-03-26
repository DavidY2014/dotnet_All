using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.DotNetFramework.Extension
{
    public class PictureHelper
    {
        /// <summary>
        /// 图片压缩
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        public static void ImageChangeSize(string oldPath,string newPath,
            int newWidth,int newHeight)
        {
            System.Drawing.Image sourceImg = System.Drawing.Image.FromFile(oldPath);
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(sourceImg, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0,
                sourceImg.Width, sourceImg.Height), GraphicsUnit.Pixel);
            sourceImg.Dispose();
            g.Dispose();
            bitmap.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
        }

    }
}
