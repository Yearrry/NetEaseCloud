using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetEase_clund_music.Tools.apiHelper
{
    public  class Music163Helper
    {
        #region 搜索

        string Geturi = "http://music.163.com/api/search/get/web?csrf_token=hlpretag=&hlposttag=&s={0}&type={1}&offset={2}&total=true&limit={3}";
        string  type = string.Empty;

        /// <summary>
        /// 搜索结果、type=1 单曲   type=10 专辑  type = 100 歌手  type = 1000 歌单  type = 1002 用户  type = 1004 MV  type = 1006 歌词 type = 1009 主播电台
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<(bool, string)> GetDataAsync(string conditions, int type, int limit = 20, int offset = 0)
        {
            using (HttpClient client = new HttpClient())
            {
                var originalresult = await client.GetStringAsync(string.Format(Geturi, conditions, type, offset, limit));

                JObject jbresult = JObject.Parse(originalresult);

                if (jbresult["code"].ToString() == "200")
                {
                    return (true, jbresult["result"].ToString());
                }
                else
                {
                    return (false, string.Format("请求失败 + {0}", string.Format(Geturi, conditions, type, offset, limit)));
                }
            }
        }

        public async Task<(bool, string)> GetMusic(string conditions,int limit = 100,int offset = 0)
        {
            type = "1";

            using(HttpClient client = new HttpClient())
            {
                var originalresult = await client.GetStringAsync(string.Format(Geturi, conditions, type, offset, limit));
               
                JObject jbresult = JObject.Parse(originalresult);

                if(jbresult["code"].ToString() == "200")
                {
                    return (true, jbresult["result"].ToString());
                }
                else
                {
                    return (false, string.Format("请求失败 + {0}", string.Format(Geturi, conditions, type, offset, limit)));
                }
            }
        }

        public async Task<(bool, string)> GetArtist(string conditions, int limit = 20, int offset = 0)
        {
            type = "100";

            using (HttpClient client = new HttpClient())
            {
                var originalresult = await client.GetStringAsync(string.Format(Geturi, conditions, type, offset, limit));

                JObject jbresult = JObject.Parse(originalresult);

                if (jbresult["code"].ToString() == "200")
                {
                    return (true, jbresult["result"].ToString());
                }
                else
                {
                    return (false, string.Format("请求失败 + {0}", string.Format(Geturi, conditions, type, offset, limit)));
                }
            }
        }

        public async Task<(bool, string)> GetAlbum(string conditions, int limit = 20, int offset = 0)
        {
            type = "10";

            using (HttpClient client = new HttpClient())
            {
                var xx = string.Format(Geturi, conditions, type, offset, limit);
                var originalresult = await client.GetStringAsync(string.Format(Geturi, conditions, type, offset, limit));

                JObject jbresult = JObject.Parse(originalresult);

                if (jbresult["code"].ToString() == "200")
                {
                    return (true, jbresult["result"].ToString());
                }
                else
                {
                    return (false, string.Format("请求失败 + {0}", string.Format(Geturi, conditions, type, offset, limit)));
                }
            }
        }

        #endregion

        /// <summary>
        /// 根据歌手ID获取专辑
        /// </summary>
        string getArtistAlbum = "http://music.163.com/api/artist/albums/{0}?id={1}&offset={2}&total=true&limit={3}";

        public async Task<(bool,string)> GetArtistAlbumAsync(string id ,int offset,int limit)
        {
            using(HttpClient client = new HttpClient())
            {
                var x = string.Format(getArtistAlbum, id, id, offset, limit);
                var getResult = await client.GetAsync(string.Format(getArtistAlbum, id, id, offset, limit));

                if (getResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var bestResult = await client.GetStringAsync(string.Format(getArtistAlbum, id, id, offset, limit));

                    JObject jResult = JObject.Parse(bestResult);

                    return (true, jResult.ToString());
                }
                else
                {
                    return (false, string.Format("请求失败 + {0}", string.Format(getArtistAlbum, id, id, offset, limit)));
                }
            }
        }

        /// <summary>
        /// 专辑信息  
        /// </summary>
        /// <link>http://music.163.com/api/album/{0}?ext=true&id={1}&offset=0&total=true&limit=10</link>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        string getAlbumurl = "http://music.163.com/api/album/{0}?ext=true&id={1}&offset={2}&total=true&limit={3}";

        public async Task<(bool, string)> GetAlbumimage(string id, int offset = 0, int limit = 10)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    client.DefaultRequestHeaders.Add("Cookie", "NMTID=00OaF3eQtnDmOeboEUrgdMk9EXHT8AAAAF8-jWUbg");

                    var bestResult = await client.GetStringAsync(string.Format(getAlbumurl, id, id, offset, limit));

                    JObject Jresult = JObject.Parse(bestResult);

                    if (Jresult["code"].ToString() == "200")
                    {
                        return (true, Jresult["album"].ToString());
                    }
                    else
                    {
                        var bsre = await client.GetAsync(string.Format(getAlbumurl, id, id, offset, limit));
                        var xx = bsre.Content.ReadAsStringAsync();

                        JObject towJresult = JObject.Parse(xx.Result);

                        if (towJresult["code"].ToString() == "200")
                        {
                            return (true, towJresult["album"].ToString());
                        }
                        else
                        {
                            return (false, string.Format("请求失败 + uri = {0}", string.Format(getAlbumurl, id, id, offset, limit)));
                        }
                    }
                }
            }
            else
            {
                return (false, "id不存在");
            }
        }

        //根据ID获取专辑详细信息

        string getAlbumDetailurl = "http://music.163.com/api/album/{0}?ext=true&id={1}";

        public async Task<(bool,string)> GetAlbumDetail(string id)
        {
            using(HttpClient client = new HttpClient())
            {
                var Repose = await client.GetStringAsync(string.Format(getAlbumDetailurl, id,id));

                JObject jresult = JObject.Parse(Repose.ToString());

                if (jresult["code"].ToString() == "200")
                {
                    return (true,jresult["album"].ToString());
                }
                else
                {
                    var bsre = await client.GetAsync(string.Format(getAlbumDetailurl, id, id));
                    var xx = bsre.Content.ReadAsStringAsync();

                    JObject towJresult = JObject.Parse(xx.Result);

                    if (towJresult["code"].ToString() == "200")
                    {
                        return (true, towJresult["album"].ToString());
                    }
                    else
                    {
                        return (false, string.Format("请求失败 + url {0}", string.Format(downloadMusic, id)));
                    }
                }
            }
        }

        //根据ID获取MP3
        string downloadMusic = "http://music.163.com/song/media/outer/url?id={0}.mp3";

        public async Task<(bool, string)> GetPalyPath(string id, string name)
        {
            CacheHelper cacheHelper = new CacheHelper();
            (bool, string) result;

            using(HttpClient client = new HttpClient())
            {
                var getHttprequest = await client.GetAsync(string.Format(downloadMusic, id));

                if(getHttprequest.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream resultStream = await getHttprequest.Content.ReadAsStreamAsync();

                    result = await cacheHelper.CreateMusicCache(resultStream, name);
                }
                else
                {
                    result = (false, string.Format("请求失败 + url {0} \r\n  响应码 + {1}  \r\n 失败信息 + {2} ", string.Format(downloadMusic, id),getHttprequest.StatusCode,getHttprequest.Content));
                }

                return result;
            }
        }

    }
}
