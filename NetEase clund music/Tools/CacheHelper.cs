using System.IO;
using System.Threading.Tasks;

namespace NetEase_clund_music.Tools
{
    public class CacheHelper
    {
        DirectoryInfo solutionPath;
        DirectoryInfo cache;
        DirectoryInfo musicCache;

        public CacheHelper()
        {
            string  exePath = Directory.GetCurrentDirectory();

            DirectoryInfo upPath = Directory.GetParent(exePath);

            solutionPath = Directory.GetParent(upPath.FullName);

            cache = Directory.CreateDirectory(string.Format("{0}/{1}", solutionPath.FullName, "Cache"));

            musicCache = Directory.CreateDirectory(string.Format("{0}/{1}", cache.FullName, "Music"));
        }

        public Task<(bool,string)> CreateMusicCache(Stream  music,string name)
        {
            if (!Directory.Exists(cache.FullName))
            {
                cache = Directory.CreateDirectory(string.Format("{0}/{1}", solutionPath.FullName, "Cache"));
            }
            else if (!Directory.Exists(string.Format("{0}/{1}", cache.FullName, "Music")))
            {
                musicCache = Directory.CreateDirectory(string.Format("{0}/{1}", cache.FullName, "Music"));
            }

            string newFilename = string.Format("{0}/{1}.mp3", musicCache.FullName, name);

            if (!File.Exists(newFilename))
            {
                using(var br = new BinaryReader(music))
                {
                    var data = br.ReadBytes((int)music.Length);

                    File.WriteAllBytes(newFilename, data);
                }

                return Task.FromResult<(bool, string)>((true, newFilename));
            }
            else
            {
                return Task.FromResult<(bool, string)>((true, newFilename));
            }
        }

        public Task WriteStream(FileStream fileName,Stream readStream)
        {
            byte[] btArray = new byte[512];

            int readSize = readStream.Read(btArray, 0, btArray.Length);

            while(readSize > 0)
            {
                fileName.Write(btArray, 0, readSize);

                readSize = readStream.Read(btArray, 0, btArray.Length);
            }
            return Task.CompletedTask;
        }
    }
}
