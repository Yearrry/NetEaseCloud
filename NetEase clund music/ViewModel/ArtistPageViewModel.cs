using GalaSoft.MvvmLight;
using NetEase_clund_music.Db;
using NetEase_clund_music.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetEase_clund_music.ViewModel
{
    public class ArtistPageViewModel : ViewModelBase
    {
        //判断是否传入一个同样的条件
        string oldConditions = string.Empty;

        //接口Helper
        MusicHelperDb db = new MusicHelperDb();

        public ArtistPageViewModel(string conditions)
        {
            if(conditions == oldConditions)
            {
                return;
            }
            oldConditions = conditions;

            Limit = 12;
            AlbumCollection = new ObservableCollection<album>();
            AlbumCollectionsmall = new ObservableCollection<album>();

            InitArtist(conditions);
        }

        private int limit;

        public int Limit
        {
            get { return limit; }
            set { limit = value; RaisePropertyChanged(); }
        }


        private artist artist;

        public artist Artist
        {
            get { return artist; }
            set { artist = value;RaisePropertyChanged(); }
        }

        private ObservableCollection<album> albumCollection;

        public ObservableCollection<album> AlbumCollection
        {
            get { return albumCollection; }
            set { albumCollection = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<album> albumCollectionsmall;

        public ObservableCollection<album> AlbumCollectionsmall
        {
            get { return albumCollectionsmall; }
            set { albumCollectionsmall = value; RaisePropertyChanged(); }
        }

        public async void InitArtist(string conditions)
        {
            ArtistResult  result =  await db.GetArtistAsync(conditions, 1, 0);

            Artist = result.artists[0];

           await InitAlbum();
        }

        public async Task<ObservableCollection<album>> InitAlbum()
        {
            AlbumCollection.Clear();

            ArtistalbumResult abResult = await db.GetArtistalbum(Artist.id);

            abResult.hotAlbums.ForEach(arg =>
            {
                AlbumCollection.Add(arg);
            });

            Artist.musicSize = abResult.artist.musicSize;

            foreach (album item in AlbumCollection.Take(Limit))
            {
                album album = await db.GetAlbumById(item.id);

                item.songs = album.songs;
                item.description = album.description;

                AlbumCollectionsmall.Add(item);
            }
            return AlbumCollection;
        }

        public async Task AlbumsmallAdd()
        {
           if(AlbumCollectionsmall.Count < AlbumCollection.Count)
            {
                foreach (album item in AlbumCollection.Skip(AlbumCollectionsmall.Count).Take(Limit))
                {
                    if(item.songs.Count == 0)
                    {
                        album album = await db.GetAlbumById(item.id);

                        item.songs = album.songs;
                        item.description = album.description; 
                    }

                   if(AlbumCollectionsmall.Where(t => t.id == item.id).Count() == 0)
                    {
                        AlbumCollectionsmall.Add(item);
                    }
                }
            }
        }

        public void AblumsmallReset()
        {
            if(AlbumCollectionsmall.Count > Limit)
            {
                for (int i = AlbumCollectionsmall.Count - 1; i >= Limit; i--)
                {
                    AlbumCollectionsmall.RemoveAt(i);
                }
            }
        }
    }
}
