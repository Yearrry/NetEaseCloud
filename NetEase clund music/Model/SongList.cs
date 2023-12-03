using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.Model
{
    public class SongList:ViewModelBase
    {
        private SongListType songListType;

        public SongListType SongListType
        {
            get { return songListType; }
            set { songListType = value; RaisePropertyChanged(); }
        }

        private Listmold listmoldg;

        public Listmold Listmoldg
        {
            get { return listmoldg; }
            set { listmoldg = value; }
        }

        private string songListName;

        public string SongListName
        {
            get { return songListName; }
            set { songListName = value; RaisePropertyChanged(); }
        }

        private int listentime;

        public int Listentime
        {
            get { return listentime; }
            set { listentime = value; RaisePropertyChanged(); }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; RaisePropertyChanged(); }
        }

        public int TodayNum { get; set; }
        public string Today { get; set; }

        public SongList()
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            Today = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            TodayNum = Convert.ToInt32(DateTime.Now.Day.ToString("d"));
            songListType = SongListType.Default;
        }
    }
    public enum SongListType
    {
        NoBreak = 1,
        Customize = 2,
        PrivateRadar = 3,
        Default = 4,
        BoutiqueList = 5,
        OfficialList = 6
    }

    public enum Listmold
    {
        //默认
        Default = 1,
        //私人FM
        PersonalFm = 2,
    }
}
