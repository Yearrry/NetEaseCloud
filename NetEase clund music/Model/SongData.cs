using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.Model
{
    public class SongData:ViewModelBase
    {
        private int songid;

        public int Songid
        {
            get { return songid; }
            set { songid = value;RaisePropertyChanged(); }
        }

        //歌曲名称
        private string songName;

        public string SongName
        {
            get { return songName; }
            set { songName = value; RaisePropertyChanged(); }
        }

        //歌曲位置
        private string songDiskAddress;

        public string SongDiskAddress
        {
            get { return songDiskAddress; }
            set { songDiskAddress = value; RaisePropertyChanged(); }
        }


        //专辑
        public SongList Album { get; set; }

        //歌手
        public Singer Singer_Song { get; set; }

        public string Song_Lyric { get; set; }

        //翻译
        public string LyricTranslate { get; set; }
    }
}
