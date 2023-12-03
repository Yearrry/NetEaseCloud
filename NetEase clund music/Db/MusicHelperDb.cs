using NetEase_clund_music.Model;
using NetEase_clund_music.Tools.apiHelper;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NetEase_clund_music.Db
{
    public class MusicHelperDb
    {
        Music163Helper musicHelper = new Music163Helper();

        public async Task<SongResult> GetSongsAsync(string condition,int limit = 20,int page = 0)
        {
            SongResult songresult = new SongResult();

            (bool, string) reuslt = await musicHelper.GetDataAsync(condition,1, limit, page);

            if (reuslt.Item1)
            {
                songresult = JsonConvert.DeserializeObject<SongResult>(reuslt.Item2);

                songresult.code = true;

                //songresult.songs.ForEach(arg =>
                //{
                //    resultCollection.Add(arg);
                //});
            }
            else
            {
                songresult.code = false;
                songresult.error = reuslt.Item2;
            }

            return songresult;
        }

        public async Task<ArtistResult> GetArtistAsync(string condition, int limit = 20, int page = 0)
        {
            ArtistResult artistresult = new ArtistResult();

            (bool, string) reuslt = await musicHelper.GetDataAsync(condition, 100, limit, page);

            if (reuslt.Item1)
            {
                artistresult = JsonConvert.DeserializeObject<ArtistResult>(reuslt.Item2);
                artistresult.code = true;
            }
            else
            {
                artistresult.code = false;
                artistresult.error = reuslt.Item2;
            }
            return artistresult;
        }

        public async Task<AlbumResult> GetAlbumAsync(string condition, int limit = 20, int page = 0)
        {
            AlbumResult albumresult = new AlbumResult();

            (bool, string) reuslt = await musicHelper.GetDataAsync(condition, 10, limit, page);

            if (reuslt.Item1)
            {
                albumresult = JsonConvert.DeserializeObject<AlbumResult>(reuslt.Item2);
                albumresult.code = true;
            }
            else
            {
                albumresult.code = false;
                albumresult.error = reuslt.Item2;
            }

            return albumresult;
        }

        public async Task<ArtistalbumResult> GetArtistalbum(string id,int limit = 100,int page = 0)
        {
            ArtistalbumResult result = new ArtistalbumResult();

            (bool, string) requestResult = await musicHelper.GetArtistAlbumAsync(id, page, limit);

            if (requestResult.Item1)
            {
                result = JsonConvert.DeserializeObject<ArtistalbumResult>(requestResult.Item2);
            }

            return result;
        }

        public async Task<album> GetAlbumById(string id)
        {
            album result = new album();

            (bool, string) requestResult = await musicHelper.GetAlbumDetail(id);

            if (requestResult.Item1)
            {
                result = JsonConvert.DeserializeObject<album>(requestResult.Item2);
            }

            return result;
        }
    }
}
