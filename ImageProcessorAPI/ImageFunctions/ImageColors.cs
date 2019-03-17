using System;
using System.Drawing;
using System.IO;
//using Color = System.Drawing.Color;





namespace ImageProcessorAPI.ImageFunctions
{
    public class ImageColors : iImageColorcs
    {
        /// <summary>
        /// Function to convert image to gray scale 
        /// </summary>
        /// <param name="imageFile">image fine in string base 64</param>
        /// <returns>image file in string base 64</returns>
        public string UpdateImagetoGrayscale(string imageFile)
        { 
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            Image info = null;
            MemoryStream stream = new MemoryStream(imgBytes);
            info = Image.FromStream(stream);
            Bitmap grayscaledImage = new Bitmap(info);
            for (int y = 0; y < grayscaledImage.Height; y++)
            {
                for (int x = 0; x < grayscaledImage.Width; x++)
                {
                    Color c = grayscaledImage.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    int avg = (r + g + b) / 3;
                    grayscaledImage.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            //grayscaledImage.MakeTransparent();
            //grayscaledImage.
            //Bitmap grayscaledImage = ConvertToGrayscale(info);
            MemoryStream smallerStream = new MemoryStream();
            //grayscaledImage.Save(smallerStream, ImageFormat.Jpeg);
            grayscaledImage.Save(smallerStream, info.RawFormat);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }
    }
}
