namespace Work5Lesson17
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new List<string> { "я тут", "я тут опять", "повтор", "повтор тут1", "просто" };

            var longest = strings.GetMax(s => s.Length);
            Console.WriteLine("Самая длинная строка: " + longest);

            var searcher = new FileSearcher();
            searcher.FileFound += Searcher_FileFound;
            searcher.Search(Directory.GetCurrentDirectory());
        }

        private static void Searcher_FileFound(object? sender, FileArgs e)
        {
            Console.WriteLine("Найден файл: " + e.FileName);
            if(e.FileName.Contains(".exe"))
            {
                e.Cancel = true;
            }
        }
    }
}
