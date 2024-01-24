using System.Diagnostics;

namespace Work6Lesson23
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = CountSpacesAsync("file1.txt");
            var task2 = CountSpacesAsync("file2.txt");
            var task3 = CountSpacesAsync("file3.txt");

            await Task.WhenAll(task1, task2, task3);

            stopwatch.Stop();

            Console.WriteLine($"Количество пробелов в file1.txt: {task1.Result}");
            Console.WriteLine($"Количество пробелов в file2.txt: {task2.Result}");
            Console.WriteLine($"Количество пробелов в file3.txt: {task3.Result}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");


            stopwatch.Restart();

            var task4 = CountSpacesInFolderAsync("SecretPath");
            await task4;

            stopwatch.Stop();

            Console.WriteLine($"Количество пробелов во всех файлах в папке folder: {task4.Result}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        /// <summary>
        /// Функция, которая возвращает количество пробелов в файле
        /// </summary>
        /// <param name="filePath">Путь к папке</param>
        /// <returns></returns>
        static async Task<int> CountSpacesAsync(string filePath)
        {
            var content = await File.ReadAllTextAsync(filePath);
            var spaces = content.Count(c => c == ' ');
            return spaces;
        }

        /// <summary>
        /// Функция, которая принимает путь к папке и возвращает общее количество пробелов во всех файлах в ней
        /// </summary>
        /// <param name="folderPath">Путь к папке</param>
        /// <returns></returns>
        static async Task<int> CountSpacesInFolderAsync(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);
            var tasks = files.Select(file => CountSpacesAsync(file)).ToArray();
            await Task.WhenAll(tasks);
            var totalSpaces = tasks.Sum(t => t.Result);
            return totalSpaces;
        }
    }
}
