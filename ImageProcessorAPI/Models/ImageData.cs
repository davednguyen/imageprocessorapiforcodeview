namespace ImageProcessorAPI.Models
{
    /// <summary>
    /// Properties of data model for an image request
    /// </summary>
    public class ImageData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool NeedResize {get;set;}
        public string ResizedImageFile { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public bool NeedFlipHorizontal { get; set; }
        public string HorizonallyFlippedImage { get; set; }
        public bool NeedFlipVertical { get; set; }
        public string VerticallyFlippedImage { get; set; }
        public bool NeedRotateLeft { get; set; }
        public string RotatedLeftImage { get; set; }
        public bool NeedRotateRight { get; set; }
        public string RotatedRightImage { get; set; }
        public bool NeedConvertGrayscale { get; set; }
        public string GrayscaledImage { get; set; }
        public string SourceImageFile { get; set; }
    }
}
