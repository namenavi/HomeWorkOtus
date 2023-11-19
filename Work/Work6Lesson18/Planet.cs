namespace Work6Lesson18
{
    /// <summary>
    /// Класс описывающий планету
    /// </summary>
    public class Planet
    {
        public Planet(string name, int number, int equatorLength, Planet previousPlanet)
        {
            Name = name;
            Number = number;
            EquatorLength = equatorLength;
            PreviousPlanet = previousPlanet;
        }
        /// <summary>
        /// Название планеты
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Number { get;  }
        /// <summary>
        /// Длина экватора
        /// </summary>
        public int EquatorLength { get; }
        /// <summary>
        /// Предыдущая планета
        /// </summary>
        public Planet PreviousPlanet { get; }
    }
}
