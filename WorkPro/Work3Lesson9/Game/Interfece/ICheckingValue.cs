namespace Work3Lesson9.Game.Interfece
{
    /// <summary>
    /// Интерфейс для проверки валидации данных
    /// </summary>
    public interface IChecking
    {
        /// <summary>
        /// Проверить совпадант ли введенное число с сгенерированным значением
        /// </summary>
        /// <param name="value">Проверяемое число</param>
        /// <returns></returns>
        ComparisonResult CheckingValue(int value);
        /// <summary>
        /// Выводится количество оставшихся попыток
        /// </summary>
        /// <returns></returns>
        int CheckAttempt();
    }
}