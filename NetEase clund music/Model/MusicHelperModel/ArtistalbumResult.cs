using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.Model
{
    public class ArtistalbumResult
    {
        public artist artist { get; set; }

        public List<album> hotAlbums { get; set; }

        public bool more { get; set; }

        public string type { get; set; }
    }
}
