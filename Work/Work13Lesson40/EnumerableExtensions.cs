namespace Work13Lesson40
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Метод расширение принимающий значение Х от 1 до 100 и 
        /// возвращающий заданное количество процентов от выборки 
        /// с округлением количества элементов в большую сторону.
        /// </summary>
        /// <typeparam name="T">Должен реализовать IComparable<T></typeparam>
        /// <param name="list">Коллекция для сравнения</param>
        /// <param name="porcent">КОлличество процентов элементов для возврата</param>
        /// <returns></returns>
        public static IEnumerable<T> Top<T>(this IEnumerable<T> list, double porcent) where T : IComparable<T>
        {
            return list.Top(porcent, x => x);
        }
        /// <summary>
        /// Метод расширение принимающий значение Х от 1 до 100 и 
        /// возвращающий заданное количество процентов от выборки 
        /// с округлением количества элементов в большую сторону, который принимает ещё и поле
        /// , по которому будут отбираться топ Х элементов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">Должен реализовать IComparable<T></typeparam>
        /// <param name="list">Коллекция для сравнения</param>
        /// <param name="porcent">Колличество процентов элементов для возврата</param>
        /// <param name="keySelector">Функция сортировки</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<T> Top<T, TKey>(this IEnumerable<T> list, double porcent, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if(1d > porcent || porcent > 100d)
                throw new ArgumentException("Переданное значение больше 100% или меньше 1%");
            var procentItem = (double)list.Count() * porcent / 100;
            var elementCountToProc = (int)Math.Ceiling(procentItem);
            return list.OrderByDescending(keySelector)
                       .Take(elementCountToProc);
        }
    }
}
