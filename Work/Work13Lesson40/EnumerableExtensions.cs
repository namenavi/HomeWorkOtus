namespace Work13Lesson40
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> list, double porcent) where T : IComparable<T>
        {
            if(1d >= porcent || porcent >= 100d)
                throw new ArgumentException("Переданное значение больше 100% или меньше 1%");
            var procentItem = (double)list.Count() * porcent / 100;
            var elementCountToProc = (int)Math.Ceiling(procentItem);
            return list.OrderByDescending(x => x).Take(elementCountToProc);
        }
        public static IEnumerable<T> Top<T, TKey>(this IEnumerable<T> list, double porcent, Func<T, TKey> keySelector) where T : IComparable<T>
        {
            return list.Top(porcent).OrderByDescending(keySelector);
        }
    }
}
