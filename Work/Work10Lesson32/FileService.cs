namespace Work10Lesson32
{
    public static class FileService
    {
        /// <summary>
        /// Запись файлов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dir2"></param>
        /// <returns></returns>
        public static async Task WriteFile(DirectoryInfo dir, DirectoryInfo dir2)
        {
            try
            {
                string filename;
                for(int i = 1; i <= 10; i++)
                {
                    filename = $"file{i}.txt";
                    //создание и перезапись файла
                    using(StreamWriter writer = new StreamWriter($"{dir}\\{filename}", false))
                    {
                        await writer.WriteAsync(filename);
                    }
                    // добавление в файл
                    using(StreamWriter writer = new StreamWriter($"{dir}\\{filename}", true))
                    {
                        await writer.WriteAsync("\t" + DateTime.Now);
                    }
                }

                for(int i = 1; i <= 10; i++)
                {
                    filename = $"file{i}.txt";
                    using(StreamWriter writer = new StreamWriter($"{dir2}\\{filename}", false))
                    {
                        await writer.WriteAsync(filename);
                    }
                    // добавление в файл
                    using(StreamWriter writer = new StreamWriter($"{dir2}\\{filename}", true))
                    {
                        await writer.WriteAsync("\t" + DateTime.Now);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Читение файлов
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dir2"></param>
        /// <returns></returns>
        public static async Task ReadFile(DirectoryInfo dir, DirectoryInfo dir2)
        {
            try
            {
                for(int i = 1; i <= 10; i++)
                {
                    using(StreamReader reader = new StreamReader($"{dir}\\file{i}.txt"))
                    {
                        string text = await reader.ReadToEndAsync();
                        Console.WriteLine($"Текст файла file{i}.txt: {text} + дополнение");
                    }
                }
                Console.WriteLine();

                for(int i = 1; i <= 10; i++)
                {
                    using(StreamReader reader = new StreamReader($"{dir2}\\file{i}.txt"))
                    {
                        string text = await reader.ReadToEndAsync();
                        Console.WriteLine($"Текст файла file{i}.txt: {text} + дополнение");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}