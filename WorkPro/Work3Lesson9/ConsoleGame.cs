using Work3Lesson9.Game;
using Work3Lesson9.Game.Interfece;

namespace Work3Lesson9
{
    /// <summary>
    /// Игра рандом для консоли
    /// </summary>
    public class ConsoleGame : IGame
    {
        private readonly IRandomGame game;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ConsoleGame"/> с помощью заданной игры.
        /// </summary>
        public ConsoleGame(IRandomGame game)
        {
            this.game = game;
        }
        /// <summary>
        /// Запускает основной цикл программы для игры через консоль
        /// </summary>
        public void StartGame()
        {
            var setting = game.GetSetting();
            Console.WriteLine($"Компьютер загодал число от {setting.IntervalStart} до {setting.IntervalEnd}. У вас осталось попыткок - {game.CheckAttempt()} .");
            ComparisonResult result;
            int number = 0;
            while(game.CheckAttempt() != 0)
            {
                Console.WriteLine();
                Console.WriteLine($"У вас осталось попыткок - {game.CheckAttempt()} .");
                Console.Write($"Введите предпологаемое число:");
                if(int.TryParse(Console.ReadLine(), out number))
                {
                    result = game.CheckingValue(number);
                    switch(result)
                    {
                        case ComparisonResult.Equals:
                            Console.WriteLine($"Поздравляю число {number} это то самое загаданное число. Вы победили компьютер.");
                            Console.WriteLine();
                            return;
                        case ComparisonResult.Bigger:
                            Console.WriteLine($"К сожелению число {number} больше загаданного числа");
                            break;
                        case ComparisonResult.Smaller:
                            Console.WriteLine($"К сожелению число {number} меньше загаданного числа");
                            break;
                        case ComparisonResult.Exp:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат данных повторите ввод.");
                }
            }
            Console.WriteLine("К сожелению Вы проиграли компьютеру");
        }
    }
}
