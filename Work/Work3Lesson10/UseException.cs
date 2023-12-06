namespace Work3Lesson10
{
    public class UseException : Exception
    {
        /// <summary>
        /// Рализовано собственное исключение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public UseException(string? message) : base(message)
        {
        }
    }
}