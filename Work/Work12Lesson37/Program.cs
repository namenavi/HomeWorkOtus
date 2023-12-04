using System;

namespace Work12Lesson37
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program1.Start();
        }
    }
    /// <summary>
    /// Постоянный покупатель
    /// </summary>
    static class Program1
    {
        public static void Start()
        {
            var shop = new Shop();
            var customer = new Customer();
            shop.CollectionChanged  += customer.OnItemChanged;
            Console.WriteLine("Для добавления товара нажмите A, для просмотра - V, для удаления - D, для выхода - X:");
            while(true)
            {
                var key = Console.ReadKey().Key;
                Console.WriteLine();

                switch(key)
                {
                    case ConsoleKey.A:
                        shop.Add(new Product());
                        break;

                    case ConsoleKey.D:
                        Console.WriteLine("Введите ID товара для удаления:");
                        if(int.TryParse(Console.ReadLine(), out int itemId))
                        {
                            shop.Remove(itemId);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод. Введите целое число для идентификатора товара.");
                        }
                        break;

                    case ConsoleKey.V:
                        shop.SelectProducts();
                        break;

                    case ConsoleKey.X:
                        return;
                    default:
                        Console.WriteLine($"Неизвестная команда.{Environment.NewLine}Для добавления товара нажмите A, для просмотра - V, для удаления - D, для выхода - X:");
                        break;
                }
            }
        }
    }
}
