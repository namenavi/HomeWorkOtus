namespace Work12Lesson37.Librarian
{
    /// <summary>
    /// Программа Бидлиотекарь
    /// </summary>
    public static class Program2
    {
        public static void Start()
        {
            var book = new Books();
            while(true)
            {
                Console.WriteLine("1 - Добавить книгу; 2 - Вывести список непрочитанного; 3 - Выйти");
                var input = Console.ReadKey(true).KeyChar;
                if(char.IsDigit(input))    //// Можно проверку на число сделать сразу
                {
                    Console.Write(input);

                    Console.WriteLine();

                    switch(input)
                    {
                        case '1':
                            Console.Write("Введите название книги:");
                            var nameBook = Console.ReadLine();
                            book.Add(nameBook);
                            break;
                        case '2':
                            book.Select();
                            break;
                        case '3':
                            return;
                        default:
                            Console.WriteLine($"Неизвестная команда.{Environment.NewLine}Для добавления товара нажмите A, для просмотра - V, для удаления - D, для выхода - X:");
                            break;
                    }
                }
            }
        }
    }
}