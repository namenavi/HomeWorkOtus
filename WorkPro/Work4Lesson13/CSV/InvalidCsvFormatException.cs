namespace Work4Lesson13.CSV
{
    public class InvalidCsvFormatException : Exception
    {
        /// <summary>
        /// Исключение формата Csv
        /// </summary>
        /// <param name="message">Сообщение</param>
        public InvalidCsvFormatException(string message)
            : base(message)
        {
        }

        public InvalidCsvFormatException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
