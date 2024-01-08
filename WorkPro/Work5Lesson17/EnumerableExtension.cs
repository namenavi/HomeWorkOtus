namespace Work5Lesson17
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Обобщённая функция расширения, находящая и возвращающая первый максимальный элемент коллекции
        /// </summary>
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if(collection == null || !collection.Any())
            {
                return null;
            }

            float max = float.MinValue;
            T maxElement = null;

            foreach(var element in collection)
            {
                // Преобразование элемента в число
                float number = convertToNumber(element);

                // Сравнение с текущим максимумом
                if(number > max)
                {
                    max = number;
                    maxElement = element;
                }
            }
            return maxElement;
        }
    }
}
