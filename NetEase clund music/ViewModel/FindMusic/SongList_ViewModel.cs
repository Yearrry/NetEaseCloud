using GalaSoft.MvvmLight;
using NetEase_clund_music.Db;
using NetEase_clund_music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEase_clund_music.ViewModel
{
    public class SongList_ViewModel:ViewModelBase
    {
        public SongList_ViewModel()
        {
            local = new localDb();
            ShowSongLists = new List<SongList>();
            ShowSongListnum = new List<int>();
        }
        localDb local;

        private List<SongList> songLists;

        public List<SongList> SongLists
        {
            get { return songLists; }
            set { songLists = value;RaisePropertyChanged(); }
        }

        private List<SongList> showsongLists;

        public List<SongList> ShowSongLists
        {
            get { return showsongLists; }
            set { showsongLists = value; RaisePropertyChanged(); }
        }

        private List<int> songListnum;

        public List<int> SongListnum
        {
            get { return songListnum; }
            set { songListnum = value; RaisePropertyChanged(); }
        }

        private List<int> showsongListnum;

        public List<int> ShowSongListnum
        {
            get { return showsongListnum; }
            set { showsongListnum = value; RaisePropertyChanged(); }
        }

        public void init()
        {
            int count;
            SongLists = local.GetList<SongList>("SongListsTwo");
            SongListnum = new List<int>();
            if (SongLists.Count > 0)
            {
                if (SongLists.Count % 4 == 0)
                {
                    count = SongLists.Count / 4;
                }
                else
                {
                    count = SongLists.Count / 4 + 1;
                }
                for (int i = 1; i < count + 1; i++)
                {
                    SongListnum.Add(i);
                }
            }
            ShowSongListnum = SongListnum.Take(8).ToList();
        }

        public void Query(int limit)
        {
            ShowSongLists.Clear();

            ShowSongLists = SongLists.Skip((limit - 1) * 4).Take(4).ToList();


            ShowSongListnum.Clear();

            if (limit >= 5 && limit < 8)
            {
                ShowSongListnum = SongListnum.Skip(3).Take(6).ToList();
            }
            else if(limit< 5)
            {
                ShowSongListnum = SongListnum.Take(8).ToList();
            }
            else
            {
                if (SongListnum.Count - limit > 8)
                {
                    ShowSongListnum = SongListnum.Skip(limit - 1).Take(6).ToList();
                }
                else if (SongListnum.Count - limit == 8)
                {
                    ShowSongListnum = SongListnum.Skip(limit - 1).Take(8).ToList();
                }
                else if (SongListnum.Count - limit <= 4)
                {
                    ShowSongListnum = SongListnum.Skip(SongListnum.Count - 8).Take(8).ToList();
                    List<int> ShowSong= SongListnum.Skip(SongListnum.Count - 8).Take(8).ToList();
                    ShowSongListnum = ShowSong;
                }
            }
        }
    }
}
