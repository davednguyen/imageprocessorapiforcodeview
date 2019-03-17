using System.Collections.Generic;

namespace ImageProcessorAPI.Models
{
    public class ImageDataV2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SourceImageFile { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<string,bool> Requests { get; set; }
        public string Image { get; set; }
    }
}
