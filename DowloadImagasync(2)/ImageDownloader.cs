using System;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public class ImageDownloader
    {
        public Task task;
        public event Action<string> ImageStarted;
        public event Action<string> ImageCompleted;
        public void Download(string remoteUri, string fileName)
        {
            ImageStarted?.Invoke(fileName);
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadFileCompleted += (s, e) => { ImageCompleted?.Invoke(fileName); };
                task = myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            }
        }
    }
}