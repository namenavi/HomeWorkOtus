namespace Work13Lesson40
{
    public static class MyExtention
    {
        public static IEnumerable<int> Top(this IEnumerable<int> list, double porcent)
        {
            var procentItem = (double)list.Count() * porcent / 100;
            var elementCountToProc = (int)Math.Ceiling(procentItem);
            return list.OrderByDescending(x =>
            {
                if(1 <= x && x <= 100)
                {
                    return x;
                }
                throw new ArgumentException("Одно или несколько из переданных значений больше 100 или меньше 1");
            }).Take(elementCountToProc);
        }
        public static IEnumerable<T> Top<T, TKey>(this IEnumerable<T> list, double porcent, Func<T, TKey> keySelector)
        {
            var procentItem = (double)list.Count() * porcent / 100;
            var elementCountToProc = (int)Math.Ceiling(procentItem);
            return list.OrderByDescending(keySelector).Take(elementCountToProc);
        }

    }
}
