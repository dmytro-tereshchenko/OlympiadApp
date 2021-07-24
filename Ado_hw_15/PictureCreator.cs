using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Ado_hw_15
{
    public static class PictureCreator
    {
        public static byte[] Download(string imagePath)
        {
            Image img = Image.FromFile(imagePath);
            int maxWidth = 300, maxHeight = 300;
            //размеры выбраны произвольно
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);
            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);
            Image mi = new Bitmap(newWidth, newHeight);
            //рисунок в памяти
            Graphics g = Graphics.FromImage(mi);
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();
            //поток для ввода|вывода байт из памяти
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();//выносим в поток все данные
                       //из буфера
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] buf = br.ReadBytes((int)ms.Length);
            return buf;
        }
        public static Image GetImage(string imagePath)
        {
            MemoryStream stream = new MemoryStream(Download(imagePath));
            return Image.FromStream(stream);
        }
    }
}
