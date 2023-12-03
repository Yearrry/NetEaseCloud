using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.Model
{
    public class ArtistResult
    {
        public int artistCount { get; set; }

        public List<artist> artists { get; set; }

        public bool code { get; set; }

        public string error { get; set; }
    }
}
