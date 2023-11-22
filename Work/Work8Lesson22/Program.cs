using System.Xml.Linq;

namespace Work8Lesson22
{
    internal class Program
    {
        static BinaryTree tree;
        static int result;
        static void Main(string[] args)
        {
            MainChoice();
        }
        /// <summary>
        /// Выбор пользователя, заполнить тестовыми данными или своими.
        /// </summary>
        static void MainChoice()
        {
            Console.WriteLine("Здраствуйте. Ввести цифру 0 (заполнить свои данные) или 1 (заполнить данные автоматически).");
            while(!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Некоректные данные. Повторите попытку.");
            }

            if(result == 0)
            {
                InputDataAndView();
                SeachSalary();
            }
            else if(result == 1)
            {
                FillData();
                SeachSalary();
            }
            MainChoice();
        }
        /// <summary>
        /// Поиск зарплаты определение дальнейших действий
        /// </summary>
        static void SeachSalary()
        {
            Console.Write("Введите зарплату для поиска сотрудника: ");
            if(int.TryParse(Console.ReadLine(), out int result))
            {
                Console.WriteLine(tree.SearchBySalary(result));
            }
            else
            {
                Console.Write("Некоректные данные для поиска.");
            }

            Console.WriteLine("Ввести цифру 0 (переход к началу программы) или 1 (снова поиск зарплаты).");
            while(!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Некоректные данные. Повторите попытку.");
            }

            if(result == 0)
            {
                MainChoice();
            }
            else if(result == 1)
            {
                SeachSalary();
            }
        }
        /// <summary>
        /// Отработка ввода данных. И отображение введенных данных
        /// </summary>
        static void InputDataAndView()
        {
            tree = new BinaryTree();
            Console.WriteLine("Введите информацию о сотрудниках (имя и зарплата):");
            while(true)
            {
                Console.Write("Имя (выйти из ввода данных нажмите Enter): ");
                string name = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(name))
                    break;
                Console.Write("Зарплата: ");
                if(int.TryParse(Console.ReadLine(), out int result))
                {
                    tree.Add(name, result);
                }
                else
                {
                    Console.Write("Данные не сохранены. Некоректные данные.");
                }
            }
            Console.WriteLine("Информация о сотрудниках в порядке возрастания зарплат:");
            tree.InAscOrder(tree.RootNode);
        }
        /// <summary>
        /// Метод заполнения тестовыми данными
        /// </summary>
        static void FillData()
        {
            tree = new BinaryTree();
            tree.Add("София", 500);
            tree.Add("Артем", 400);
            tree.Add("Амина", 300);
            tree.Add("Ева", 450);
            tree.Add("Екатерина", 350);
            tree.Add("Мухаммад", 50);
            tree.Add("Александр", 800);
            tree.Add("Анна", 550);
            tree.Add("Дарина", 580);
            tree.Add("Давид", 600);
            tree.Add("Михаил", 200);
            tree.Add("Максим", 1000);
            tree.Add("Иван", 5000);
            tree.Add("Роман", 1500);
            tree.Add("Матвей", 150);
            Console.WriteLine("Информация о сотрудниках в порядке возрастания зарплат:");
            tree.InAscOrder(tree.RootNode);
        }
    }
}
