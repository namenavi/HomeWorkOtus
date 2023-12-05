using System.Collections.Concurrent;

namespace Work12Lesson37.Librarian
{
    /// <summary>
    /// Класс описывающий коллекцию книг
    /// </summary>
    public class Books
    {
        public Books()
        {
            Task.Run(async () =>
            {
                while(true)
                {
                    ReadBooks();
                    await Task.Delay(1000);
                }
            });
        }
        ConcurrentDictionary<string, int> bookValues = new ConcurrentDictionary<string, int>();
        public bool Add(string key)
        {
            return bookValues.TryAdd(key, 0);
        }
        public void Select()
        {
            foreach(var book in bookValues)
            {
                Console.WriteLine($"{book.Key} - {book.Value}%");
            }
        }
        private void ReadBooks()
        {
            foreach(var book in bookValues)
            {
                if(book.Value == 100)
                {
                    bookValues.TryRemove(book);
                }
                else
                {
                    bookValues[book.Key] = book.Value + 1;
                }
            }
        }
    }
}