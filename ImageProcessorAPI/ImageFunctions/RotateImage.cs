using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageProcessorAPI.ImageFunctions
{
    /// <summary>
    /// Function class to handle rotate an image base on requests
    /// </summary>
    public class RotateImage : iRotateImage
    {
        /// <summary>
        /// Function to relate image from center to left side 
        /// </summary>
        /// <param name="imageFile">image fine converted as base 64 string</param>
        /// <returns>rotated image file in string 64 base format</returns>
        public string RotateImageLeft(string imageFile)
        {
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            MemoryStream stream = new MemoryStream(imgBytes);
            Image info = Image.FromStream(stream);
            Bitmap rotatedLeftImage = new Bitmap(info);
            rotatedLeftImage.RotateFlip(RotateFlipType.Rotate90FlipX);
            MemoryStream smallerStream = new MemoryStream();
            //rotatedLeftImage.Save(smallerStream, ImageFormat.Jpeg);
            rotatedLeftImage.Save(smallerStream, info.RawFormat);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }

        /// <summary>
        /// Function to rotate an image to the right
        /// </summary>
        /// <param name="imageFile">image fine converted as base 64 string</param>
        /// <returns>rotated image file in string 64 base format</returns>
        public string RotateImageRight(string imageFile)
        {
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            MemoryStream stream = new MemoryStream(imgBytes);
            Image info = Image.FromStream(stream);
            Bitmap rotatedRightImage = new Bitmap(info);
            rotatedRightImage.RotateFlip(RotateFlipType.Rotate90FlipY);
            MemoryStream smallerStream = new MemoryStream();
            //rotatedRightImage.Save(smallerStream, ImageFormat.Bmp);
            rotatedRightImage.Save(smallerStream, info.RawFormat);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }
    }
}
