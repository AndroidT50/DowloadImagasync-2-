
using System.Net;


namespace Dowload_image
{
    internal class Program
    {
        public class ImageDownloader
        {
            public string? remoteUri;
            public string? fileName;

            public event Action<string> ?ImageStarted;
            public event Action<string> ?ImageCompleted;
            
            public async Task Download(string remoteUri, string fileName)
            {
                var myWebClient = new WebClient();
                ImageStarted += NewsStarted;
                ImageStarted?.Invoke(fileName);
                Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
                await Task.Run(() =>
                {
                    myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
               
                });

                Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
                ImageCompleted += NesCompleted;
                ImageCompleted?.Invoke(fileName);
                
              
            }
            private void NesCompleted(string fileName)
            {
                Console.WriteLine($"Скачивание файла {fileName} закончилось");

            }
            private void NewsStarted(string fileName)
            {
                Console.WriteLine($"Скачивание файла {fileName} началось ");

            }

        }
        async static Task Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            
            await imageDownloader.Download("https://images.hdqwalls.com/wallpapers/tenet-movie-8k-a1.jpg", "bigimage.jpg");
            Task task = new Task(() => {

                Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");

            });
            
            task.Start();
            while (Console.ReadKey(true).Key != ConsoleKey.A)
            {
               
                if (task.IsCompleted == true)
                {
                    Console.WriteLine("Изображение загружено");
                }
                else
                {
                    Console.WriteLine("Изображение загружается....");
                }

            }

            Console.WriteLine(task.IsCompletedSuccessfully);
        }
    }
}