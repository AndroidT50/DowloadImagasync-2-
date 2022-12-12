using ConsoleApp19;
using System;
using System.Threading;

namespace Dowload_image
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();

            imageDownloader.ImageStarted += NesStarted;

            imageDownloader.ImageCompleted += NesCompleted;

            imageDownloader.Download("https://images.hdqwalls.com/wallpapers/tenet-movie-8k-a1.jpg", "bigimage.jpg");

            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");

            while (Console.ReadKey(true).Key != ConsoleKey.A || imageDownloader.task.IsCompleted == false)
            {
                Console.Clear();
                Console.WriteLine($"Изображение загружается....");
                Thread.Sleep(1000);
            }
        }
        static void NesStarted(string fileName)
        {
            Console.WriteLine($"Скачивание файла {fileName} началось ");
        }
        static void NesCompleted(string fileName)
        {
            Console.WriteLine($"Скачивание файла {fileName} закончилось");
        }

    }
}