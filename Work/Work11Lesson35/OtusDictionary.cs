/* Интересная статья хабр https://habr.com/ru/articles/198104/ и еще https://dir.by/developer/csharp/dictionary/inside/
 */
namespace Work11Lesson35
{
    /// <summary>
    ///  Это класс храняющий набор пар "ключ-значение".
    /// </summary>
    /// <typeparam name="TKey">Ключ</typeparam>
    /// <typeparam name="TValue">Значение</typeparam>
    public class OtusDictionary<TKey, TValue>
    {
        /// <summary>
        /// Корзина которая хранит адреса ключей
        /// </summary>
        private int[] _buckets = new int[32];
        /// <summary>
        /// Массив реализует внутреннее хранилище
        /// </summary>
        private Entry[] _entries = new Entry[32];
        /// <summary>
        /// Счетчик записи
        /// </summary>
        private int _counter = 0;
        /// <summary>
        /// Добавление новой пары "ключ-значение".
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(TKey key, TValue value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("Значение не может быть null.");
            }
            if(_counter >= _buckets.Length)
            {
                IncreaseResizeArray();
            }

            int bucketNum = key.GetHashCode() % _entries.Length;

            if(_entries[bucketNum].key.GetHashCode() == key.GetHashCode())
            {
                //TODO: Разобраться как реализовать запись через поле Entry.next Метод для решения коллизий называется метод цепочек
                throw new ArgumentException("Этот ключ занят. Используйте другой.");
            }
            else
            {
                if(_entries[bucketNum].value != null)
                {
                    IncreaseResizeArray();
                }
                var entry = new Entry();
                entry.key = key;
                entry.value = value;
                entry.hashCode = key.GetHashCode();
                entry.next = 0;
                _entries[bucketNum] = entry;
                _buckets[_counter] = bucketNum;
                _counter++;
            }
        }
        /// <summary>
        /// Увеличивает размер массива в 2 раза и пересчитывает хэш ключей в корзине
        /// </summary>
        private void IncreaseResizeArray()
        {
            int[] newBuckets = new int[_buckets.Length * 2];
            Entry[] newEntries = new Entry[_entries.Length * 2];
            foreach(Entry entry in _entries)
            {
                if(entry.key != null)
                {
                    int boocketNum = entry.key.GetHashCode() % newEntries.Length;
                    newEntries[boocketNum] = entry;
                }
            }
            for(int i = 0; i < _buckets.Length; i++)
            {
                newBuckets[i] = _buckets[i];
            }
            _buckets = newBuckets;
            _entries = newEntries;
        }
        /// <summary>
        /// Получение значения по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Возврашает значение</returns>
        public TValue Get(TKey key)
        {
            int bucketNum = key.GetHashCode() % _entries.Length;
            return _entries[bucketNum].value;
        }
        /// <summary>
        /// Возврашает или задает элемент с указанным ключом
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Значение Value</returns>
        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }
        /// <summary>
        /// Элемент "ключ-значение"
        /// </summary>
        private struct Entry
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }
    }
}
