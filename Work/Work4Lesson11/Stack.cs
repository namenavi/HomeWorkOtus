namespace Work4Lesson11
{
    public class Stack
    {
        int _count;
        StackItem _top;
        public Stack(params string[] strings)
        {
            
            foreach(string s in strings)
            {
                _top = new StackItem(_top, s);
                _count++;
            }
        }
        /// <summary>
        /// Количество элементов в Стеке
        /// </summary>
        public int Size
        {
            get
            {
                return _count;
            }
        }
        /// <summary>
        /// Значение верхнего элемента из стека. Если стек пустой - возвращает null.
        /// </summary>
        public string Top
        {
            get
            {
                if(_count == 0)
                {
                    return null;
                }
                return _top.Item;
            }
        }
        /// <summary>
        /// Метод  который на вход принимает неограниченное количество параметров типа Stack
        /// и возвращает новый стек с элементами каждого стека в порядке параметров, но сами элементы записаны в обратном порядке
        /// </summary>
        /// <param name="stacks"></param>
        /// <returns></returns>
        public static Stack Concat(params Stack[] stacks)
        {
            var newStack = new Stack();
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
            _top = new StackItem(_top, s);
            _count++;
        }
        public void Clear()
        {
            _top = null;
            _count = 0;
        }
        /// <summary>
        /// Извлекает верхний элемент и удаляет его из стека. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">При попытке вызова метода Pop у пустого стека - срабатывает исключение с сообщением "Стек пустой"</exception>
        public string Pop()
        {
            if(_count == 0)
            {
                throw new NullReferenceException("Стек пустой");
            }
            string result = _top.Item;
            _top = _top.Parent;
            _count--;
            return result;
        }
        /// <summary>
        /// Класс описывающий элемент стека
        /// </summary>
        class StackItem
        {
            public readonly StackItem Parent;
            public readonly string Item;

            public StackItem(StackItem parent, string item)
            {
                this.Parent = parent;
                this.Item = item;
            }
        }
    }
}