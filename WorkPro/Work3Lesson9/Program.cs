﻿/*
На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.
Программа рандомно генерирует число, пользователь должен угадать это число. При каждом вводе числа программа пишет больше или меньше отгадываемого.
Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.
В отчёте написать, что именно сделано по каждому принципу.
Приложить ссылку на проект и написать, сколько времени ушло на выполнение задачи.

Принцип единственной ответственности - Весь мой код разделен на классы в которых действия и ответственность у каждого своя например SettingRandomGame и RandomGame ;
Принцип инверсии зависимостей - Абстракции не должны зависеть от деталей. Детали должны зависеть от абстракций. Пример в коде  public RandomGame(ISettingRandomGame settingGame);
Принцип разделения интерфейса - Все интерфейсы разделены на более мелкие модули, каждый по своему функционалу;
Принцип открытости/закрытости - У меня создан интерфейс который позволяет создавать разные реализации игры (объекты открыты для расширения, но закрыты для модификации»), сейчас консоль , можно в будущем создать для WPF ;
Принцип подстановки Барбары Лисков - реализован во многих местах;
 */

using Work3Lesson9.Game;
using Work3Lesson9.Game.Settings;

namespace Work3Lesson9
{
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Параметры</param>
        static void Main(string[] args)
        {
            var setting = new SettingRandomGame(1, 10, 10);
            var game = new RandomGame(setting);
            var consoleGame = new ConsoleGame(game);
            while(true)
            {
                game.CreateRandomNumber();
                consoleGame.StartGame();
                Console.WriteLine("Хотите повторить игру? Введите Y(ДА) / N(Нет)");
                var key = Console.ReadKey().Key;
                if(key == ConsoleKey.N)
                {
                    return;
                }
                Console.Clear();
            }
        }
    }
}
