using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Work10Lesson32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dir = new DirectoryInfo("C:\\Otus\\TestDir1");
            var dir2 = new DirectoryInfo("C:\\Otus\\TestDir2");

            if(!dir.Exists)
                dir.Create();
            if(!dir2.Exists)
                dir2.Create();
            WriteFile(dir, dir2);
            ReadFile(dir, dir2);
            Console.ReadLine();
        }
        /// <summary>
        /// Запись файлов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dir2"></param>
        /// <returns></returns>
        static async Task WriteFile(DirectoryInfo dir, DirectoryInfo dir2)
        {
            string filename;
            for(int i = 1; i <= 10; i++)
            {
                filename = $"file{i}.txt";
                using(FileStream fstream1 = File.Create($"{dir}\\{filename}"))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(filename + "\t" + DateTime.Now);//fstream.name нифига не нейм, а путь стрима
                    await fstream1.WriteAsync(buffer, 0, buffer.Length);
                }
            }

            for(int i = 1; i <= 10; i++)
            {
                filename = $"file{i}.txt";
                using(FileStream fstream2 = File.Create($"{dir2}\\{filename}"))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(filename + "\t" + DateTime.Now);
                    await fstream2.WriteAsync(buffer, 0, buffer.Length);

                }
            }
          
        }
        /// <summary>
        /// Читение файлов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dir2"></param>
        /// <returns></returns>
        static async Task ReadFile(DirectoryInfo dir, DirectoryInfo dir2)
        {
            for(int i = 1; i <= 10; i++)
            {
                using(FileStream fileStream = new FileStream($"{dir}\\file{i}.txt", FileMode.Open))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fileStream.Length];
                    // считываем данные
                    await fileStream.ReadAsync(buffer, 0, buffer.Length);
                    string TextFromFile = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"Текст файла file{i}.txt: {TextFromFile} + дополнение");
                }
            }
            Console.WriteLine();

            for(int i = 1; i <= 10; i++)
            {
                using(FileStream fileStream = new FileStream($"{dir2}\\file{i}.txt", FileMode.Open))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fileStream.Length];
                    // считываем данные
                    await fileStream.ReadAsync(buffer, 0, buffer.Length);
                    string TextFromFile = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"Текст файла file{i}.txt: {TextFromFile} + дополнение");
                }
            }
        }
    }
}