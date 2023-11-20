/*
// // * Summary *

BenchmarkDotNet v0.13.10, Windows 20 (20.0.44055.3693/42H2/2042Update)
Intel Core i7-22000 CPU 33.40GHz (Ivy Bridge), 100 CPU, 800 logical and 400 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX


| Method         | n  | value | Mean          | Error      | StdDev     | Allocated |
|--------------- |--- |------ |--------------:|-----------:|-----------:|----------:|
| Fibonacci      | 5  | ?     |     17.754 ns |  0.0699 ns |  0.0619 ns |         - |
| CycleFibonacci | ?  | 5     |      2.000 ns |  0.0082 ns |  0.0077 ns |         - |
| Fibonacci      | 10 | ?     |    219.244 ns |  0.3437 ns |  0.3215 ns |         - |
| CycleFibonacci | ?  | 10    |      4.545 ns |  0.0055 ns |  0.0049 ns |         - |
| Fibonacci      | 20 | ?     | 27,299.777 ns | 65.5790 ns | 61.3426 ns |         - |
| CycleFibonacci | ?  | 20    |      9.973 ns |  0.2331 ns |  0.2394 ns |         - |

Fibonacci(5) = 5
Fibonacci(10) = 55
Fibonacci(20) = 6765
 */
using BenchmarkDotNet.Attributes;

namespace Work7Lesson21
{
    [MemoryDiagnoser]
    public class TestFibonacci
    {
        /// <summary>
        ///  Нахождения n-го члена последовательности Фибоначчи по формуле F(n) = F(n-1) + F(n-2) с помощью рекурсивного вызова.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [Benchmark]
        [Arguments(5)]
        [Arguments(10)]
        [Arguments(20)]
        public int Fibonacci(int n)
        {
            if(n == 0 || n == 1)
            {
                return n;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        /// <summary>
        /// Нахождения n-го члена последовательности Фибоначчи по формуле F(n) = F(n-1) + F(n-2) с помощью цикла, в больших числах на много быстрее.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Benchmark]
        [Arguments(5)]
        [Arguments(10)]
        [Arguments(20)]
        public int CycleFibonacci(int value)
        {
            int first = 0;
            int fibonacci = 0;
            if(value < 0)
            {
                int second = -1;
                if(value == -1)
                    fibonacci = second;

                for(int i = value + 1; i < 0; i++)
                {
                    fibonacci = first + second;
                    first = second;
                    second = fibonacci;
                }
                return fibonacci;
            }
            else
            {
                int second = 1;
                if(value == 1)
                    fibonacci = second;

                for(int i = 0; i < value - 1; i++)
                {
                    fibonacci = first + second;
                    first = second;
                    second = fibonacci;
                }
                return fibonacci;
            }
        }
    }
}
