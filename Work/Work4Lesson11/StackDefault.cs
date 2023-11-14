namespace Work4Lesson11
{
    public class StackDefault
    {
        List<string> _strings;
        public StackDefault(params string[] strings) 
        {
            _strings = new List<string>();
            foreach(string s in strings)
            {
                _strings.Add(s); 
            }
        }
        /// <summary>
        /// Количество элементов в Стеке
        /// </summary>
        public int Size
        {
            get
            {
                return _strings.Count;
            }
        }
        /// <summary>
        /// Значение верхнего элемента из стека. Если стек пустой - возвращает null.
        /// </summary>
        public string Top
        {
            get
            {
                if(_strings.Count == 0)
                {
                    return null;
                }
                return _strings[_strings.Count-1];
            }
        }
        /// <summary>
        /// Метод  который на вход принимает неограниченное количество параметров типа Stack
        /// и возвращает новый стек с элементами каждого стека в порядке параметров, но сами элементы записаны в обратном порядке
        /// </summary>
        /// <param name="stacks"></param>
        /// <returns></returns>
        public static StackDefault Concat(params StackDefault[] stacks)
        {
            var newStack = new StackDefault();
            foreach(var s in stacks)
            {
                newStack.Merge(s);
            }
            return newStack;
        }
        /// <summary>
        /// Добавить элемент в стек
        /// </summary>
        /// <param name="s"></param>
        public void Add(string s)
        {
            _strings.Add(s);
        }
        public void Clear()
        {
            _strings.Clear();
        }
        /// <summary>
        /// Извлекает верхний элемент и удаляет его из стека. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">При попытке вызова метода Pop у пустого стека - срабатывает исключение с сообщением "Стек пустой"</exception>
        public string Pop()
        {
            if(_strings.Count == 0)
            {
                throw new NullReferenceException("Стек пустой");
            }
            string poopedString = (_strings[_strings.Count - 1]);
            _strings.RemoveAt(_strings.Count - 1);
            return poopedString;
        }
    }
}