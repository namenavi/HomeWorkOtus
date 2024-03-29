﻿using System.Diagnostics;

namespace Work7Lesson28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 100_000; // 1_000_000 или 10_000_000
            int[] array = new int[size];
            Random random = new Random();
            for(int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 100); 
            }

            // Вычисляем сумму элементов массива обычным способом
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int sum = 0;
            for(int i = 0; i < size; i++)
            {
                sum += array[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"Обычное вычисление суммы: {sum}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");

            // Вычисляем сумму элементов массива параллельным способом с использованием Thread
            stopwatch.Restart();
            var _lock = new object();
            int sumParallel = 0;
            int numTask = 8; // Количество потоков, можно изменить в зависимости от количества ядер процессора
            int chunkSize = size / numTask; // Размер части массива, которую обрабатывает каждый поток
            Task[] tasks = new Task[numTask];
            for(int i = 0; i < numTask; i++)
            {
                int start = i * chunkSize; 
                int end = (i + 1) * chunkSize; 
                tasks[i] = Task.Run(() =>
                {
                    int partialSum = 0;
                    for(int j = start; j < end; j++)
                    {
                        partialSum += array[j];
                    }

                    lock(_lock)
                    {
                        sumParallel += partialSum;
                    }
                });
            }
            Task.WaitAll(tasks); // Ждем, пока все потоки завершат свою работу
            stopwatch.Stop();
            Console.WriteLine($"Параллельное вычисление суммы с использованием Thread: {sumParallel}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");

            // Вычисляем сумму элементов массива параллельным способом с использованием LINQ
            stopwatch.Restart();
            int sumLinq = array.AsParallel().Sum(); 
            stopwatch.Stop();
            Console.WriteLine($"Параллельное вычисление суммы с использованием LINQ: {sumLinq}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
