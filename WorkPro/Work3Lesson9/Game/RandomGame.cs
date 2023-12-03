using Work3Lesson9.Game.Interfece;

namespace Work3Lesson9.Game
{
    /// <summary>
    /// Класс игры рандом
    /// </summary>
    class RandomGame : IRandomGame
    {
        ISettingRandomGame _settingGame;
        int _value;
        int _counter;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RandomGame"/> с помощью заданных настроек.
        /// </summary>
        public RandomGame(ISettingRandomGame settingGame)
        {
            _settingGame = settingGame;
        }
        /// <summary>
        /// Сгенерировать рандомное число в заданом диапазоне
        /// </summary>
        public void CreateRandomNumber()
        {
            _counter = 0;
            Random rand = new Random((int)DateTime.Now.Ticks);
            _value = rand.Next(_settingGame.IntervalStart, _settingGame.IntervalEnd);
        }
        /// <summary>
        /// Проверить совпадант ли введенное число с сгенерированным значением
        /// </summary>
        /// <param name="value">Проверяемое число</param>
        /// <returns></returns>
        public ComparisonResult CheckingValue(int value)
        {
            if(_counter == _settingGame.NumberAttempt)
                return ComparisonResult.Exp;
                //throw new ArgumentOutOfRangeException("Достигнут придел кол-ва попыток отгадывания. Вы проиграли.");
            _counter++;
            if (value == _value)
            {
                _counter = _settingGame.NumberAttempt;
                return ComparisonResult.Equals;
            }
            return value < _value ? ComparisonResult.Smaller : ComparisonResult.Bigger;
        }
        /// <summary>
        /// Выводится количество оставшихся попыток
        /// </summary>
        /// <returns></returns>
        public int CheckAttempt()
        {
            return _settingGame.NumberAttempt - _counter;
        }
        /// <summary>
        /// Возвращает настройки заданные при создании класса
        /// </summary>
        /// <returns></returns>
        public ISettingRandomGame GetSetting() 
        {
            return _settingGame;
        }
    }
}
