using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.Model
{
    public class SongResult
    {
        public int songCount { get; set; }

        public List<song> songs { get; set; }

        public bool code { get; set; }

        public string error { get; set; }
    }
}
