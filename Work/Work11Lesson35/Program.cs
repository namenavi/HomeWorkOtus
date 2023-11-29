/* Интересная статья хабр https://habr.com/ru/articles/198104/ и еще https://dir.by/developer/csharp/dictionary/inside/
 */
namespace Work11Lesson35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> keys = new Dictionary<int, string>();
            var index = keys[8] = "А вот и запись (чтение) индексатора";
            keys[9] = index;
            OtusDictionary<int, string> dictionary = new OtusDictionary<int, string>();
            dictionary.Add(99, "Интересная и запутанная тема.");
            dictionary.Add(33, "Но я понял ее");
            dictionary.Add(33, "Надо работать");
            Console.WriteLine(dictionary.Get(99));
            Console.WriteLine(dictionary.Get(33));
        }
    }
}
