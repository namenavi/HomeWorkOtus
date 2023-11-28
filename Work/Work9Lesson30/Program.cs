using System.Threading;
using static System.Net.WebRequestMethods;

namespace Work9Lesson30
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            
            List<(string,string)> imageUrls = new List<(string, string)>
            {
             new ("a-picture-of-fireworks-with-a-road-in-the-background_1340-43363.jpg",
                "https://img.freepik.com/free-photo/a-picture-of-fireworks-with-a-road-in-the-background_1340-43363.jpg"),
             new ("Kak-WordPress-Obrabatyvaet-i-hranit-vlozheniya-kartinki.png",
                "https://wp-kama.ru/wp-content/uploads/2020/03/Kak-WordPress-Obrabatyvaet-i-hranit-vlozheniya-kartinki.png") ,
             new ("hranit-vlozheniya-kartinki.png",
                "https://xn--90abhccf7b.xn--p1ai/800/600/https/content.foto.my.mail.ru/inbox/iraida60/Skrinshoty/i-6492.jpg"),
             new ("i-6492.jpg",
                "https://leonov-do.ru/wp-content/uploads/2014/10/Ssilka2.jpg"),
             new ("Ssilka2.jpg",
                "https://storage.theoryandpractice.ru/tnp/uploads/image_unit/000/156/586/image/base_87716f252d.jpg"),
             new ("котик5.jpg",
                "https://lifehacker.ru/wp-content/uploads/2018/12/Kak-fotografirovat-kotikov-19-sovetov-ot-professionala_1544744286.jpg"),
             new ("котик4.jpg",
                "https://st.europaplus.ru/mf/p/236802/news/373/037400/content/4958e76b84a6ff53fbff9da9b922e260.jpg"),
             new ("котик3.jpg",
                "https://www.marimedia.ru/media/news/147038/1318e92b889a15be8777484dcfc83483.jpg"),
             new ("котик2.jpg",
                "https://www.ptichka.ru/data/cache/2018jan/13/57/49869_74018.jpg"),
             new ("котик1.jpg",
                "https://st.volga.news/image/w1300/h900/max/636b68a5-59e1-4800-bafb-01869daee1e2.jpg")
            // Добавьте остальные URL-ы сюда
            };

            List<ImageDownloader> downloaders = imageUrls.Select(url => 
            { 
                var image = new ImageDownloader(url.Item1, url.Item2);
                image.ImageStarted += ImageDownload_ImageStarted;
                image.ImageCompleted += ImageDownload_ImageCompleted;
                return image;
            }).ToList();

            CancellationTokenSource cts = new CancellationTokenSource();

            // Запуск скачивания всех картинок параллельно
            downloaders.Select(downloader =>
            {
                return Task.Run(() => downloader.DownloadAsync(cts.Token));
                 
            }).ToList();

            // Ожидание нажатия клавиши
            while(true)
            {
                Console.WriteLine("Нажмите клавишу A для остановки или любую другую клавишу для проверки статуса скачивания...");
                var key = Console.ReadKey(true);

                if(key.Key == ConsoleKey.A)
                {
                    // Остановка всех задач скачивания
                    cts.Cancel();
                    break;
                }
                else
                {
                    // Вывод состояния загрузки каждой картинки
                    foreach(var downloader in downloaders)
                    {
                        Console.WriteLine($"{downloader.Url}: {(downloader.IsCompleted ? "Загружено" : "В процессе")}");
                    }
                }
            }
            Console.WriteLine("Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
        /// <summary>
        /// Метод отработки события  ImageCompleted
        /// </summary>
        /// <param name="fileName"></param>
        private static void ImageDownload_ImageCompleted(string fileName)
        {
            Console.WriteLine($"Скачивание файла {fileName} закончилось");
        }
        /// <summary>
        /// Метод отработки события  ImageStarted
        /// </summary>
        /// <param name="fileName"></param>
        private static void ImageDownload_ImageStarted(string fileName)
        {
            Console.WriteLine($"Скачивание файла {fileName} началось");
        }
    }
}
