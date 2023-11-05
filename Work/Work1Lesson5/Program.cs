using System;
using System.Reflection;
using System.Text;
namespace Work1Lesson5
{
    
    internal class Program
    {
        static string name;
        static void Main(string[] args)
        {
            Console.WriteLine("Здраствуйте, Вам доступны следуещие команды:");
            CommandHelp();
            LoopProccesing();

        }

        private static void CommandHelp()
        {
            Console.WriteLine($@"{name?.ToString()}
/start - Запускает программу.
/help - Отображает краткую справочную информацию о том, как пользоваться программой.
/info - Предоставляет информацию о версии программы и дате её создания.
/exit - Выходит из программы и закрывает консоль.");
        }

        private static void LoopProccesing()
        {
            while(true)
            {
                var text = InputConsole();
                string[] arr = text.Split(' ');
                switch(arr[0])
                {
                    case "/start":
                        SelectName();
                        break;
                    case "/help":
                        CommandHelp();
                        break;
                    case "/exit":
                        CommandExit();
                        break;
                    case "/echo":
                        if(name != null)
                            CommandEcho(arr);
                        break;
                    case "/info":
                        CommandInfo();
                        break;
                    default:
                        Console.WriteLine($@"{name?.ToString()} Не правильная команда. Повтори попытку.");
                        break;
                }
            }
        }

        private static void CommandInfo()
        {
            Console.WriteLine($@"{name?.ToString()}");
            Console.WriteLine("Версия выполняющейся в данный момент программы: {0}",
                              typeof(Program).Assembly.GetName().Version);
            Console.WriteLine("Дате создания выполняющейся в данный момент программы: {0}",
                              File.GetCreationTime(AppDomain.CurrentDomain.BaseDirectory + System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe"));

        }

        private static void CommandEcho(string[] arr)
        {
            if(arr.Length >= 2)
            {
                StringBuilder sb = new StringBuilder(); 
                for(int i = 1; i < arr.Length; i++)
                {
                    sb.Append(arr[i]);
                } 
                Console.WriteLine(sb.ToString());
            }
        }

        private static void CommandExit()
        {
            Environment.Exit(0);
        }

        private static void SelectName()
        {
            Console.Write("Введите свое имя - ");
            name = InputConsole() + ",";
            Console.WriteLine($@"{name?.ToString()} Добро пожаловать!");
        }

        private static string InputConsole()
        {
            var temp = Console.ReadLine();
            if (temp == null)
            {
                Console.WriteLine($@"{name?.ToString()} Вы не ввели ничего. Повторите ввод.");
                temp = InputConsole();
            }
            return temp;
        }
    }
}