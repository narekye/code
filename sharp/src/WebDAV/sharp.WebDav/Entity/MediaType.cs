using System.Collections.Generic;

namespace sharp.WebDav.Entity
{
    internal class MediaType
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public int MaxSize { get; set; }
        public int MinSize { get; set; }



        public static List<MediaType> Init()
        {
            var list = new List<MediaType>
            {
                new MediaType { Id = 1 , Extension = ".jpg", MaxSize = 200, MinSize = 50},
                new MediaType { Id = 2,Extension = ".png", MaxSize = 200, MinSize = 50}
            };
            return list;
        }
    }

}
