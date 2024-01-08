namespace Work5Lesson17
{
    /// <summary>
    /// Класс, содержащий аргументы события FileFound
    /// </summary>
    public class FileArgs : EventArgs
    {
        /// <summary>
        /// Свойство, содержащее имя файла
        /// </summary>
        public string FileName { get; }
        /// <summary>
        /// Свойство, содержащее флаг отмены поиска
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Конструктор, принимающий имя файла
        /// </summary>
        /// <param name="fileName"></param>
        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
