using Work3Lesson9.Game.Interfece;

namespace Work3Lesson9.Game.Settings
{
    /// <summary>
    /// Класс описывающий настройки для программы
    /// </summary>
    class SettingRandomGame : ISettingRandomGame //Принцип единственной ответственности;
    {
        int _intervalStart;
        int _intervalEnd;
        int _numberTry;
        /// <summary>
        /// Начало диапазона загадоваемого числа
        /// </summary>
        public int IntervalStart { get => _intervalStart; }
        /// <summary>
        /// Конец диапазона загадоваемого числа
        /// </summary>
        public int IntervalEnd { get => _intervalEnd; }
        /// <summary>
        /// Кол-во попыток отгадывания
        /// </summary>
        public int NumberAttempt { get => _numberTry; }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SettingRandomGame"/> с помощью заданных параметров.
        /// </summary>
        /// <param name="intervalStart">Начало диапазона загадоваемого числа</param>
        /// <param name="intervalEnd">Конец диапазона загадоваемого числа</param>
        /// <param name="numberTry">Кол-во попыток отгадывания</param>
        public SettingRandomGame(int intervalStart, int intervalEnd, int numberTry)
        {
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;
            _numberTry = numberTry;
        }
        /// <summary>
        /// Задать новые настройки для игры
        /// </summary>
        /// <param name="intervalStart">Начало диапазона загадоваемого числа</param>
        /// <param name="intervalEnd">Конец диапазона загадоваемого числа</param>
        /// <param name="numberTry">Кол-во попыток отгадывания</param>
        public void NewSettingRandomGame(int intervalStart, int intervalEnd, int numberTry)
        {
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;
            _numberTry = numberTry;
        }
    }
}
