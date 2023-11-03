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
            Console.WriteLine(@"
/start - Запускает программу.
/help - Отображает краткую справочную информацию о том, как пользоваться программой.
/info - Предоставляет информацию о версии программы и дате её создания.
/exit - Выходит из программы и закрывает консоль.");
        }

        private static void LoopProccesing()
        {
            while(true)
            {
                switch(Console.ReadLine())
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
                    default:

                        break;
                }
            }
        }

        private static void CommandExit()
        {
            Environment.Exit(0);
        }

        private static void SelectName()
        {
            Console.Write("Введите свое имя - ");
            name = InputConsole();

        }

        private static string InputConsole()
        {
            var temp = Console.ReadLine();
            if (temp == null)
            {
                Console.WriteLine("Вы не ввели ничего.Повторите ввод.");
                temp = InputConsole();
            }
            return temp;
        }
    }
}