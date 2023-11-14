using System.Runtime.InteropServices;

namespace Work4Lesson11
{
    internal class Program
    {
       

        static void Main()
        {
            var s = new Stack("a", "b", "c");
            // size = 3, Top = 'c'
            Console.WriteLine($"Size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();
            // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");
            // size = 3, Top = 'd'
            Console.WriteLine($"Size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            s.Pop();
            s.Pop();

            //size = 0, Top = null
            Console.WriteLine($"Size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");

            var st = new Stack("a", "b", "c");
            st.Merge(new Stack("1", "2", "3"));

            var ss = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            // в стеке s теперь элементы - "a", "b", "c", "3", "2", "1" <- верхний

            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
            Console.WriteLine($"Size = {ss.Size}, Top = {(ss.Top == null ? "null" : ss.Top)}");
            ss.Pop();
        }
    }
}