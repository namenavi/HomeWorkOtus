namespace Work10Lesson32
{
    public class Program
    {
        private const string _directory = "C:\\Otus\\TestDir1";
        private const string _directory2 = "C:\\Otus\\TestDir2";
        private static void Main(string[] args)
        {
            var dir = new DirectoryInfo(_directory);
            var dir2 = new DirectoryInfo(_directory2);

            if(!dir.Exists)
                dir.Create();

            if(!dir2.Exists)
                dir2.Create();

            FileService.WriteFile(dir, dir2).Wait();
            FileService.ReadFile(dir, dir2).Wait();
            Console.ReadLine();
        }
    }
}