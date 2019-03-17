using System;
using System.IO;
using System.Drawing;

namespace ImageProcessorAPI.ImageFunctions
{
    public class ResizeImage :iResizeImage
    {
        /// <summary>
        /// Function to resize image based on request 
        /// </summary>
        /// <param name="imageFile">image file in format of base 64 string</param>
        /// <returns>resized image file in format of base 64 string</returns>
        public string ResizeAnImage(string imageFile, int width, int height)
        {
            string resizedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            Image info = null;
            MemoryStream stream = new MemoryStream(imgBytes);
            info = Image.FromStream(stream);
            var smallmemoryStream = new MemoryStream();
            Bitmap tempImage = new Bitmap(info);
            tempImage.SetResolution((float)width, (float)height);
            //tempImage.Save(smallmemoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            tempImage.Save(smallmemoryStream, info.RawFormat);
            resizedImageFile = Convert.ToBase64String(smallmemoryStream.GetBuffer());
            return resizedImageFile;
        }
    }
}
