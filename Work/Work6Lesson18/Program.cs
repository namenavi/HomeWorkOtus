namespace Work6Lesson18
{
    internal class Program
    {
        static int _count;
        static void Main(string[] args)
        {
            #region 1 задание
            var ven1 = new { Name = "Venus", Number = 2, EquatorLength = 38025, PreviousPlanet = (object)null };
            var earth = new { Name = "Earth", Number = 3, EquatorLength = 40075, PreviousPlanet = ven1 };
            var mars = new { Name = "Mars", Number = 4, EquatorLength = 21344, PreviousPlanet = earth };
            var ven2 = new { Name = "Venus", Number = 2, EquatorLength = 38025, PreviousPlanet = (object)null };

            Console.WriteLine(
                $"Название: {ven1.Name}\tПорядковый номер от Солнца: {ven1.Number}.\tДлина экватора: {ven1.EquatorLength}." +
                $"Предыдущая планета: {ven1.PreviousPlanet}. Эквивалентна Венере: {ven1.Equals(ven1)}\n" +
                $"\nНазвание: {earth.Name}\tПорядковый номер от Солнца: {earth.Number}.\tДлина экватора: {earth.EquatorLength}." +
                $"Предыдущая планета: {earth.PreviousPlanet}. Эквивалентна Венере: {ven1.Equals(earth)}\n" +
                $"\nНазвание: {mars.Name}\tПорядковый номер от Солнца: {mars.Number}.\tДлина экватора: {mars.EquatorLength}." +
                $"Предыдущая планета: {mars.PreviousPlanet}. Эквивалентна Венере: {ven1.Equals(mars)}\n" +
                $"\nНазвание: {ven2.Name}\tПорядковый номер от Солнца: {ven2.Number}.\tДлина экватора: {ven2.EquatorLength}." +
                $"Предыдущая планета: {ven2.PreviousPlanet}. Эквивалентна Венере: {ven1.Equals(ven2)}\n");
            #endregion

            #region 2 задание
            CatalogPlanet planets = new CatalogPlanet();

            Console.WriteLine(planets.GetPlanet("Earth"));
            Console.WriteLine(planets.GetPlanet("Lemonia"));
            Console.WriteLine(planets.GetPlanet("Mars"));
            Console.WriteLine();
            #endregion

            #region 3 задание
            CatalogPlanetOfDelegate catalogPlanet = new CatalogPlanetOfDelegate();
            Console.WriteLine(catalogPlanet.GetPlanet("Earth", planet => { return CountTransactions(); }));
            Console.WriteLine(catalogPlanet.GetPlanet("Lemonia", planet => { return CountTransactions(); }));
            Console.WriteLine(catalogPlanet.GetPlanet("Mars", planet => { return CountTransactions(); }));
            Console.WriteLine();
            //Задание со звездачкой
            CatalogPlanetOfDelegate catalogPlanet1 = new CatalogPlanetOfDelegate();
            Console.WriteLine(catalogPlanet.GetPlanet("Earth", CountTransactions));
            Console.WriteLine(catalogPlanet.GetPlanet("Lemonia", planet => { return CountTransactions(planet); }));
            Console.WriteLine(catalogPlanet.GetPlanet("Mars", planet => { return CountTransactions(planet); }));
            Console.WriteLine();
            #endregion
        }

        /// <summary>
        /// Проверка количества обращений
        /// </summary>
        /// <returns></returns>
        static string? CountTransactions()
        {
            _count++;

            if(_count > 2)
            {
                _count=0;
                return ("Вы слишком часто спрашиваете.");
            }
            return null;
        }
        /// <summary>
        /// Проверка количества обращений, а также сверка со списком запрещенных планет
        /// </summary>
        /// <param name="planet">Название планеты.</param>
        /// <returns></returns>
        static string? CountTransactions(string planet)
        {
            _count++;

            if(_count > 2)
            {
                _count=0;
                return ("Вы слишком часто спрашиваете.");
            }
            if(planet == "Lemonia")
            {
                return ("Это запретная планета.");
            }
            return null;
        }
    }
}
