using GalaSoft.MvvmLight;
using NetEase_clund_music.Commom.CommomControl;
using NetEase_clund_music.Db;
using NetEase_clund_music.Model;

namespace NetEase_clund_music.ViewModel
{
    public class PersonalFmViewModel: ViewModelBase
    {
        public PersonalFmViewModel()
        {
            //获取当前播放的音乐
            PlayingSong = MainViewModel.ChangePalySong();

            //初始化歌词控件
            lyricContent = new LyricControl();
            //加载歌词
            lyricContent.LoadLyric(playingSong.Song_Lyric);

        }

        localDb db = new localDb();

        private SongData playingSong;

        public SongData PlayingSong
        {
            get { return playingSong; }
            set { playingSong = value; RaisePropertyChanged(); }
        }

        public static LyricControl lyricContent { get; set; }

        #region Command



        #endregion

        
    }
}
