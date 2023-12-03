using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetEase_clund_music.Model;
using NetEase_clund_music.Tools.apiHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetEase_clund_music.ViewModel
{
    public class QueryResultViewModel:ViewModelBase
    {
        public QueryResultViewModel()
        {
            Page = 0;

            ResultTypeDictionary = new Dictionary<int, int>();

            ResultTypeDictionary.Add(0, 100);
            ResultTypeDictionary.Add(1, 20);
            ResultTypeDictionary.Add(2, 20);

            Songslist = new ObservableCollection<song>();

            songlistPaging = new ObservableCollection<int>();

            ArtistsResult = new ObservableCollection<artist>();

            AlbumsResult = new ObservableCollection<album>();

            QueryArtistCommand = new RelayCommand(async()=> { await GetArtistAsync(); });

            QuerySonglistCommand = new RelayCommand(async()=> { await GetSongsAsync();});

            NextPage = new RelayCommand<string>( (s) => { NextPageAsync(s); });
            BeforePage = new RelayCommand(() => { BeforePageAsync(); });

            InitPaging = new RelayCommand<string>((s) => { InitPagingAsync(s); });
        }

        public void QueryResult(string condition)
        {
            conditionla = condition;
        }

        private string findCount;

        public string FindCount
        {
            get { return findCount; }
            set { findCount = value; RaisePropertyChanged(); }
        }

        public string conditionla { get; set; }

        //private int songlimit;

        //public int SongLimit
        //{
        //    get { return songlimit; }
        //    set { songlimit = value; RaisePropertyChanged(); }
        //}

        //private int artistlimit;

        //public int Artistlimit
        //{
        //    get { return artistlimit; }
        //    set { artistlimit = value; RaisePropertyChanged(); }
        //}

        //private int albumlimit;

        //public int Albumlimit
        //{
        //    get { return albumlimit; }
        //    set { albumlimit = value; RaisePropertyChanged(); }
        //}

        private int page;

        public int Page
        {
            get { return page; }
            set { page = value; RaisePropertyChanged(); }
        }

        private int resultType;

        public int ResultType
        {
            get { return resultType; }
            set { resultType = value; RaisePropertyChanged(); }
        }

        public Dictionary<int,int> ResultTypeDictionary { get; set; }

        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value;RaisePropertyChanged(); }
        }


        private artist bestartistResult;

        public artist BestartistResult
        {
            get { return bestartistResult; }
            set { bestartistResult = value;RaisePropertyChanged(); }
        }


        public RelayCommand QueryArtistCommand { get; set; }
        public RelayCommand QuerySonglistCommand { get; set; }
        public RelayCommand<string> NextPage{ get; set; }
        public RelayCommand BeforePage { get; set; }
        public RelayCommand<string> InitPaging { get; set; }


        private ObservableCollection<song> songslist;

        public ObservableCollection<song> Songslist
        {
            get { return songslist; }
            set { songslist = value;RaisePropertyChanged(); }
        }

        private ObservableCollection<int> songlistPaging;

        public ObservableCollection<int> SonglistPaging
        {
            get { return songlistPaging; }
            set { songlistPaging = value; }
        }


        private ObservableCollection<artist> artistsResult;

        public ObservableCollection<artist> ArtistsResult
        {
            get { return artistsResult; }
            set { artistsResult = value;RaisePropertyChanged(); }
        }

        private ObservableCollection<album> albumsResult;

        public ObservableCollection<album> AlbumsResult
        {
            get { return albumsResult; }
            set { albumsResult = value;RaisePropertyChanged(); }
        }


        public async Task GetSongsAsync()
        {
            Songslist.Clear();

            Music163Helper musicHelper = new Music163Helper();

            (bool,string) reuslt = await musicHelper.GetMusic(conditionla, ResultTypeDictionary[ResultType], Page);

            if (reuslt.Item1)
            {
                SongResult songresult = JsonConvert.DeserializeObject<SongResult>(reuslt.Item2);

                songresult.songs.ForEach(arg =>
                {
                    Songslist.Add(arg);
                });

                FindCount = songresult.songCount.ToString();
            }

            else
            {
                FindCount = reuslt.Item2;
            }
        }

        public Task BeginPaging()
        {
            if(Convert.ToInt32(FindCount) == 0)
            {
                return Task.CompletedTask;
            }

            songlistPaging.Clear();

            PageCount = (Convert.ToInt32(FindCount) % ResultTypeDictionary[ResultType]) == 0 ? Convert.ToInt32(FindCount) / ResultTypeDictionary[ResultType] : (Convert.ToInt32(FindCount) / ResultTypeDictionary[ResultType]) + 1;

            for (int i = 1; i <= PageCount; i++)
            {
                songlistPaging.Add(i);
            }

            Page = 0;

            return Task.CompletedTask;
        }

        public async Task GetArtistAsync()
        {
            ArtistsResult.Clear();

            Music163Helper musicHelper = new Music163Helper();

            var x = ResultTypeDictionary[ResultType];

            (bool, string) reuslt = await musicHelper.GetArtist(conditionla, ResultTypeDictionary[ResultType], Page);

            if (reuslt.Item1)
            {
                ArtistResult songresult = JsonConvert.DeserializeObject<ArtistResult>(reuslt.Item2);

                songresult.artists.ForEach(arg =>
                {
                    ArtistsResult.Add(arg);
                });

                FindCount = songresult.artistCount.ToString();
                BestartistResult = songresult.artists.FirstOrDefault();
            }

            else
            {
                FindCount = reuslt.Item2;
            }
        }

        public async Task GetBestArtistAsync()
        {
            Music163Helper musicHelper = new Music163Helper();

            (bool, string) reuslt = await musicHelper.GetArtist(conditionla);

            if (reuslt.Item1)
            {
                ArtistResult songresult = JsonConvert.DeserializeObject<ArtistResult>(reuslt.Item2);

                BestartistResult = songresult.artists.FirstOrDefault();
            }
            else
            {
                FindCount = reuslt.Item2;
            }
        }

        public async Task GetAlbumAsync()
        {
            AlbumsResult.Clear();

            Music163Helper musicHelper = new Music163Helper();

            (bool, string) reuslt = await musicHelper.GetAlbum(conditionla, ResultTypeDictionary[ResultType], Page);

            if (reuslt.Item1)
            {
                AlbumResult songresult = JsonConvert.DeserializeObject<AlbumResult>(reuslt.Item2);

                songresult.albums.ForEach(arg =>
                {
                    AlbumsResult.Add(arg);
                });

                FindCount = songresult.albumCount.ToString();
            }
            else
            {
                FindCount = reuslt.Item2;
            }
        }

        private async void NextPageAsync(string type)
        {
            if(Convert.ToInt32(FindCount) == 0)
            {
                return;
            }

            PageCount = (Convert.ToInt32(FindCount) % ResultTypeDictionary[ResultType]) == 0 ? Convert.ToInt32(FindCount) / ResultTypeDictionary[ResultType] : (Convert.ToInt32(FindCount) / ResultTypeDictionary[ResultType]) + 1;

            if (Page + 1 <= pageCount)
            {
                Page += 1;
            }
            else
            {
                Page = 0;
            }
            
            if(ResultType == 0)
            {
                await GetSongsAsync();
            }
            else if(ResultType == 1)
            {
                await GetArtistAsync();
            }
            else if(ResultType == 2)
            {
                await GetAlbumAsync();
            }
           
        }

        private async void BeforePageAsync()
        {
            if (Convert.ToInt32(FindCount) == 0)
            {
                return;
            }

            PageCount = (Convert.ToInt32(FindCount) % ResultTypeDictionary[ResultType]) == 0 ? Convert.ToInt32(FindCount) / ResultTypeDictionary[ResultType] : (Convert.ToInt32(FindCount) / ResultTypeDictionary[ResultType]) + 1;

            if (Page - 1 < 0)
            {
                Page = PageCount - 1;
            }
            else
            {
                Page -= 1;
            }

            if (ResultType == 0)
            {
                await GetSongsAsync();
            }
            else if (ResultType == 1)
            {
                await GetArtistAsync();
            }
            else if (ResultType == 2)
            {
                await GetAlbumAsync();
            }
        }

        public async void InitPagingAsync( string type)
        {
            if (type == "单曲")
            {
                await GetSongsAsync();
                await GetBestArtistAsync();
            }
            else if(type == "歌手")
            {
                await GetArtistAsync();
            }
            else if(type == "专辑")
            {
                await GetAlbumAsync();
            }

            await BeginPaging();
         
        }
    }
}
