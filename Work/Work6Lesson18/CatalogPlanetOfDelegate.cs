namespace Work6Lesson18
{
    /// <summary>
    /// Класс описывающий каталог планет (версия 2)
    /// </summary>
    public class CatalogPlanetOfDelegate
    {
        List<Planet> _planets;
        Planet _venus;
        Planet _earth;
        Planet _mars;

        public CatalogPlanetOfDelegate()
        {
            _venus = new Planet("Venus", 2, 38025, null);
            _earth = new Planet("Earth", 3, 40075, _venus);
            _mars = new Planet("Mars", 4, 21344, _earth);
            _planets = new List<Planet>()
            {
                _venus, _earth, _mars
            };
        }
        /// <summary>
        /// Возвращает планету, если такова есть в списке
        /// </summary>
        /// <param name="inputValue">Название планеты</param>
        /// <param name="validator">Лямда выражение для проверки  на ошибки</param>
        /// <returns></returns>
        public (int, int, string) GetPlanet(string inputValue, PlanetValidator validator)
        { 
           var exception = validator?.Invoke(inputValue);
            if (exception == null)
            {
                foreach(var item in _planets)
                {
                    if(inputValue == item.Name)
                    {
                        return (item.Number, item.EquatorLength, item.Name);
                    }
                }
                return (0, 0, "Не удалось найти планету.");
            }
            return (0, 0, exception);
        }
    }
}
