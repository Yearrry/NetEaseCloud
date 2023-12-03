using System.Collections.Generic;

namespace NetEase_clund_music.Model
{
    public class AlbumResult
    {
        public List<album> albums { get; set; }

        public int albumCount { get; set; }

        public bool code { get; set; }

        public string error { get; set; }
    }
}
