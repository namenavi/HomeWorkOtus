/* Интересная статья хабр https://habr.com/ru/articles/198104/ и еще https://dir.by/developer/csharp/dictionary/inside/
 */
namespace Work11Lesson35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OtusDictionary<int, string> dictionary = new OtusDictionary<int, string>();
                var index = dictionary[8] = "А вот запись (чтение) индексатора";
                dictionary[9] = index;
                dictionary.Add(99, "Интересная и запутанная тема.");
                dictionary.Add(34, "Но я понял ее");
                dictionary.Add(33, "Надо работать");
                Console.WriteLine(dictionary.Get(99));
                Console.WriteLine(dictionary.Get(33));
                Console.WriteLine(dictionary.Get(8));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
