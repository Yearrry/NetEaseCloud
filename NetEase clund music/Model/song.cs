using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.Model
{
    public class song
    {
        public string id { get; set; }

        public string name { get; set; }

        public string duration { get; set; }

        public string mvid { get; set; }

        public List<artist> artists { get; set; }

        public album album { get; set; }
    }
}
