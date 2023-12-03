namespace Work3Lesson9.Game.Interfece
{
    /// <summary>
    /// Интерфес описывающий настройки для программы
    /// </summary>
    public interface ISettingRandomGame
    {
        /// <summary>
        /// Конец диапазона загадоваемого числа
        /// </summary>
        int IntervalEnd { get; }
        /// <summary>
        /// Начало диапазона загадоваемого числа
        /// </summary>
        int IntervalStart { get; }
        /// <summary>
        /// Кол-во попыток отгадывания
        /// </summary>
        int NumberAttempt { get; }
        /// <summary>
        /// Задать новые настройки для игры
        /// </summary>
        /// <param name="intervalStart">Начало диапазона загадоваемого числа</param>
        /// <param name="intervalEnd">Конец диапазона загадоваемого числа</param>
        /// <param name="numberTry">Кол-во попыток отгадывания</param>
        void NewSettingRandomGame(int intervalStart, int intervalEnd, int numberTry);
    }
}