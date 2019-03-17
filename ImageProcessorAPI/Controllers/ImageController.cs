using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImageProcessorAPI.Models;
using static System.Net.Mime.MediaTypeNames.Image;
using ImageProcessor.Imaging;
using ImageProcessor.Web;
using ImageProcessor.Imaging.Formats;
using System.IO;
using ImageProcessor;
using System.Drawing;
using Simplicode.Imaging;
using System.Drawing.Imaging;
using ImageProcessorAPI.ImageFunctions;

namespace ImageProcessorAPI.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        
        // GET: api/Image
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image
        /// <summary>
        /// Post request for image processing services
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Image and request</returns>
        [HttpPost]
        public ImageData Post([FromBody]ImageData value)
        {
            var requestedResult = processImageRequest(value);
            return requestedResult;
        }

        [HttpPost("ImageProcess")]
        public ImageDataV2 ImageProcess([FromBody]ImageDataV2 value)
        {
            var result = processImageRequestV2(value);
            return result;
        }

        // PUT: api/Image/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ImageData value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private ImageDataV2 processImageRequestV2(ImageDataV2 imageRequest)
        {
            string processedImage = imageRequest.SourceImageFile;

            if(imageRequest != null && imageRequest.Requests != null)
            {
                foreach(var requestItem in imageRequest.Requests)
                {
                    if(requestItem.Key == "rs" && requestItem.Value)
                    {
                        processedImage = resizeImage(processedImage, imageRequest.Width, imageRequest.Height);
                    }
                    else if(requestItem.Key == "fh" && requestItem.Value)
                    {
                        processedImage = flipImage(processedImage, true, false);
                    }
                    else if(requestItem.Key == "fv" && requestItem.Value)
                    {
                        processedImage = rotateImage(processedImage, false, true);
                    }
                    else if(requestItem.Key == "rl" && requestItem.Value)
                    {
                        processedImage = rotateImage(processedImage, true, false);
                    }
                    else if (requestItem.Key == "rr" && requestItem.Value)
                    {
                        processedImage = rotateImage(processedImage, false, true);
                    }
                    else if(requestItem.Key == "gs" && requestItem.Value)
                    {
                        processedImage = updateGrayscale(processedImage);
                    }
                }
            }

            imageRequest.Image = processedImage;

            return imageRequest;
        }

        /// <summary>
        /// Process image based on HTTP post request
        /// </summary>
        /// <param name="imageRequest">image data from post request body</param>
        /// <returns>process results</returns>
        private ImageData processImageRequest(ImageData imageRequest)
        {
            var imageData = imageRequest;

            if(imageData != null)
            {
                string imageFileBase = imageData.SourceImageFile;
                //check if request need to resize image 
                if (imageData.NeedResize)
                {
                    imageData.ResizedImageFile = resizeImage(imageFileBase, imageRequest.ImageWidth, imageRequest.ImageHeight);
                }

                //check if request need to retate image
                if(imageData.NeedRotateLeft || imageData.NeedRotateRight)
                {
                    if (imageData.NeedRotateLeft)
                    {
                        imageData.RotatedLeftImage = rotateImage(imageFileBase, true, false);
                    }

                    if (imageData.NeedRotateRight)
                    {
                        imageData.RotatedRightImage = rotateImage(imageFileBase, false, true);
                    }
                }

                //check if request need flip image 
                if(imageData.NeedFlipHorizontal || imageData.NeedFlipVertical)
                {
                    if (imageData.NeedFlipHorizontal)
                    {
                        imageData.HorizonallyFlippedImage = flipImage(imageFileBase, true, false);
                    }

                    if (imageData.NeedFlipVertical)
                    {
                        imageData.VerticallyFlippedImage = flipImage(imageFileBase, false, true);
                    }
                }

                //check if request need to update iamge to grayscale
                if (imageData.NeedConvertGrayscale)
                {
                    imageData.GrayscaledImage = updateGrayscale(imageFileBase);
                }
            }

            return imageData;
        }

        /// <summary>
        /// process resize image request
        /// </summary>
        private string resizeImage(string imageFile, int width, int height)
        {
            iResizeImage resizeFunction = new ResizeImage();
           return resizeFunction.ResizeAnImage(imageFile, width, height);
        }

        /// <summary>
        /// process rotate image request
        /// </summary>
        private string rotateImage(string imageFile, bool rotateLeft, bool rotateRight)
        {
            iRotateImage rotateImage = new RotateImage();
            if (rotateLeft)
            {
                return rotateImage.RotateImageLeft(imageFile);
            }
            else if(rotateRight)
            {
                return rotateImage.RotateImageRight(imageFile);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// process rotate image request
        /// </summary>
        private string flipImage(string imageFile, bool flipHorizontal, bool flipVertical)
        {
            iFlipImage flipImage = new FlipImage();
            if (flipHorizontal)
            {
                return flipImage.FlipImageHorizontal(imageFile);
            }
            else if (flipVertical)
            {
                return flipImage.FlipImageVertical(imageFile);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// process update image to grayscale request
        /// </summary>
        private string updateGrayscale(string imageFile)
        {
            ImageColors updateImageColor = new ImageColors();
            return updateImageColor.UpdateImagetoGrayscale(imageFile);
        } 

    }
}
