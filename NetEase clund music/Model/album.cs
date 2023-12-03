using System.Collections.Generic;

namespace NetEase_clund_music.Model
{
    public class album
    {
        public List<song> songs { get; set; }

        public string name { get; set; }

        public string id { get; set; }

        public string blurPicUrl { get; set; } = string.Empty;

        public string publishTime { get; set; }

        public string company { get; set; }

        public List<artist> artists { get; set; }

        public artist artist { get; set; }

        public string description { get; set; }

        public int size { get; set; }
    }
}
