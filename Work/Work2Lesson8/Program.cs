using System.Collections;
using System.Diagnostics;

namespace Work2Lesson8
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            List<int> valuesList = new List<int>();
            ArrayList valuesArrayList = new ArrayList();
            LinkedList<int> valuesLinkedList = new LinkedList<int>();
            Console.WriteLine("Hello, World!");

            sw.Start();
            WriteList(valuesList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на заполнение List: {sw.Elapsed}");

            sw.Restart();
            WriteArrayList(valuesArrayList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на заполнение ArrayList: {sw.Elapsed}");

            sw.Restart();
            WriteLinkedList(valuesLinkedList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на заполнение LinkedList: {sw.Elapsed}");

            sw.Restart();
            var temp1 = SeachList(valuesList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на нахождение {temp1} в List: {sw.Elapsed}");

            sw.Restart();
            var temp2 = SeachArrayList(valuesArrayList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на нахождение {temp2} в ArrayList: {sw.Elapsed}");

            sw.Restart();
            var temp3 = SeachLinkedList(valuesLinkedList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на нахождение {temp3} в LinkedList: {sw.Elapsed}");

            sw.Restart();
            DivisionList(valuesList);
            sw.Stop();
            Console.WriteLine($"Время потраченое деление без остатака в List: {sw.Elapsed}");

            sw.Restart();
            DivisionArrayList(valuesArrayList);
            sw.Stop();
            Console.WriteLine($"Время потраченое деление без остатака в ArrayList: {sw.Elapsed}");

            sw.Restart();
            DivisionLinkedList(valuesLinkedList);
            sw.Stop();
            Console.WriteLine($"Время потраченое на деление без остатака в LinkedList: {sw.Elapsed}");
            Console.ReadLine();
        }

        private static void WriteLinkedList(LinkedList<int> valuesLinkedList)
        {
            for(int i = 1; i < 1000000; i++)
            {
                valuesLinkedList.AddLast(i);
            }
        }

        private static void WriteArrayList(ArrayList valuesArrayList)
        {
            for(int i = 1; i < 1000000; i++)
            {
                valuesArrayList.Add(i);
            }
        }

        private static void WriteList(List<int> valuesList)
        {
            for(int i = 1; i < 1000000; i++)
            {
                valuesList.Add(i);
            }
        }

        private static int SeachLinkedList(LinkedList<int> valuesLinkedList)
        {
            return valuesLinkedList.ElementAt(496753);
        }

        private static string SeachArrayList(ArrayList valuesArrayList)
        {
            return valuesArrayList[496753]?.ToString()!;
        }

        private static int SeachList(List<int> valuesList)
        {
            return valuesList[496753];
        }

        private static void DivisionLinkedList(LinkedList<int> valuesLinkedList)
        {
            Console.WriteLine($"Элементы коллекции LinkedList ");
            foreach(var item in valuesLinkedList)
            {
                if(item%777==0)
                {
                    Console.Write($" {item} ");
                }
            }
            Console.WriteLine($"Конец");
        }

        private static void DivisionArrayList(ArrayList valuesArrayList)
        {
            Console.WriteLine($"Элементы коллекции ArrayList ");
            foreach(int item in valuesArrayList)
            {
                if(item%777==0)
                {
                    Console.Write($" {item} ");
                }
            }
            Console.WriteLine($"Конец");
        }

        private static void DivisionList(List<int> valuesList)
        {
            Console.WriteLine($"Элементы коллекции List ");
            foreach(var item in valuesList)
            {
                if(item%777==0)
                {
                    Console.Write($" {item} ");
                }
            }
            Console.WriteLine($"Конец");
        }
    }
}