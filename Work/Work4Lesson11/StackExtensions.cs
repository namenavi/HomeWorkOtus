using System.Collections.Generic;
using System.Diagnostics;

namespace Work4Lesson11
{
    public static partial class StackExtensions
    {
        /// <summary>
        /// Метод расширения Merge, который на вход принимает стек s1, и стек s2.
        /// Все элементы из s2  добавляются в s1 в обратном порядке
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Stack Merge(this Stack first, Stack second)
        {
            if(first == null)
            {
                throw new ArgumentNullException("1-ый экземпляр  стека пустой пустой");
            }

            if(second == null)
            {
                throw new ArgumentNullException("2-ой экземпляр  стека пустой пустой");
            }
            while(second.Size > 0)
            {
                first.Add(second.Pop());
            }
           
            return first;    
        }
        /// <summary>
        /// Метод расширения Merge, который на вход принимает стек s1, и стек s2.
        /// Все элементы из s2  добавляются в s1 в обратном порядке
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static StackDefault Merge(this StackDefault first, StackDefault second)
        {
            if(first == null)
            {
                throw new ArgumentNullException("1-ый экземпляр  стека пустой пустой");
            }

            if(second == null)
            {
                throw new ArgumentNullException("2-ой экземпляр  стека пустой пустой");
            }
            while(second.Size > 0)
            {
                first.Add(second.Pop());
            }

            return first;
        }
    }
}
