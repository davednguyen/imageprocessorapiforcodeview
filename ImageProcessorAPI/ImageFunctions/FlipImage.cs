using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageProcessorAPI.ImageFunctions
{
    /// <summary>
    /// Class function to perfomce flipping image
    /// </summary>
    public class FlipImage : iFlipImage
    {
        /// <summary>
        /// funcation to flip image horitonatlly 
        /// </summary>
        /// <param name="imageFile">image in string base 64</param>
        /// <returns>image in string base 64</returns>
        public string FlipImageHorizontal(string imageFile)
        {
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            Image info = null;
            MemoryStream stream = new MemoryStream(imgBytes);
            info = Image.FromStream(stream);
            MemoryStream smallerStream = new MemoryStream();
            Bitmap flippedImage = new Bitmap(info);
           
            flippedImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            flippedImage.Save(smallerStream, ImageFormat.Bmp);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }

        /// <summary>
        /// funcation to flip image vertically  
        /// </summary>
        /// <param name="imageFile">image in string base 64</param>
        /// <returns>image in string base 64</returns>
        public string FlipImageVertical(string imageFile)
        {
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            Image info = null;
            MemoryStream stream = new MemoryStream(imgBytes);
            info = Image.FromStream(stream);
            MemoryStream smallerStream = new MemoryStream();
            Bitmap flippedImage = new Bitmap(info);
            flippedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            //flippedImage.Save(smallerStream, ImageFormat.Bmp);
            flippedImage.Save(smallerStream, info.RawFormat);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }
    }
}
