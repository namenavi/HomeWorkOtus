using System.Net;

namespace Work9Lesson30
{
    internal partial class Program
    {
        public class ImageDownloader
        {
            string fileName ;
            private string url;
            /// <summary>
            /// Откуда будем cкачивать
            /// </summary>
            public string Url { get => url; set => url=value; }
            public bool IsCompleted { get; internal set; }
            /// <summary>
            /// Как назовем файл на диске
            /// </summary>
            public string FileName { get => fileName; set => fileName=value; }

            public ImageDownloader(string filename, string url)
            {
                this.url=url;
                this.fileName = filename;
            }

            /// <summary>
            /// Событие начала скачивания файла
            /// </summary>
            public event  Action<string>? ImageStarted;
            /// <summary>
            /// Событие завершения скачивания файла
            /// </summary>
            public event Action<string>? ImageCompleted;
            /// <summary>
            /// Метод загрузки файла
            /// </summary>
            public async Task DownloadAsync(CancellationToken token)
            {
                Thread.Sleep(1000);///для имитации долгой работы
                if(!token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                {
                    var myWebClient = new WebClient();
                    try
                    {
                        ImageStarted?.Invoke(FileName);
                        await myWebClient.DownloadFileTaskAsync(Url, FileName);
                        IsCompleted = true;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Ошибка при скачивании файла {FileName}: {ex.Message}");
                    }
                    finally
                    {
                        ImageCompleted?.Invoke(FileName);
                    }
                   
                }
                else
                {
                    Console.WriteLine($"Скачивании файла {FileName} отменено.");
                    return;
                }
                 
            }
        }
    }
}
