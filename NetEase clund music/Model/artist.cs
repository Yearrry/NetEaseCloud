using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace NetEase_clund_music.Model
{
    public class artist :ViewModelBase
    {
        public string id { get; set; }

        public string name { get; set; }

        public string picUrl { get; set; }

        public List<string> alias { get; set; }

        private int musicsize;

        public int musicSize
        {
            get { return musicsize; }
            set { musicsize = value;RaisePropertyChanged(); }
        }


        public int albumSize { get; set; }

        public int mvSize { get; set; }

    }
}
