namespace Work6Lesson18
{   
    /// <summary>
     /// Класс описывающий каталог планет
     /// </summary>
    public class CatalogPlanet
    {
        int _counter;
        List<Planet> _planets;
        Planet _venus;
        Planet _earth;
        Planet _mars;

        public CatalogPlanet()
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
        /// <returns></returns>
        public (int, int, string) GetPlanet(string inputValue)
        {
            _counter++;

            if(_counter > 2)
            {
                _counter = 0;
                return (0, 0, "Вы слишком часто спрашиваете.");
            }
            else if(_counter <= 2)
            {
                foreach(var item in _planets)
                {
                    if(inputValue == item.Name)
                    {
                        return (item.Number, item.EquatorLength, item.Name);
                    }
                }
            }

            return (0, 0, "Не удалось найти планету.");
        }
    }
}
