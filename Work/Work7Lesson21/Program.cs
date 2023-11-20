/*
// * Summary 
BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
Intel Core i7- CPU (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX
| Method         | n  | value | Mean          | Error       | StdDev      |
|--------------- |--- |------ |--------------:|------------:|------------:|
| Fibonacci      | 5  | ?     |     17.902 ns |   0.2266 ns |   0.2120 ns |
| CycleFibonacci | ?  | 5     |      2.025 ns |   0.0228 ns |   0.0213 ns |
| Fibonacci      | 10 | ?     |    221.115 ns |   2.0252 ns |   1.6911 ns |
| CycleFibonacci | ?  | 10    |      4.549 ns |   0.0126 ns |   0.0112 ns |
| Fibonacci      | 20 | ?     | 27,595.233 ns | 351.9241 ns | 329.1900 ns |
| CycleFibonacci | ?  | 20    |      9.890 ns |   0.1646 ns |   0.1540 ns |
 */
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace Work7Lesson21
{
    internal class Program
    {
        static Stopwatch sw = new Stopwatch();
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<TestFibonacci>();
            var test = new TestFibonacci();
            Console.WriteLine();
            Console.WriteLine($"Fibonacci(5) = {test.CycleFibonacci(5)}");
            Console.WriteLine($"Fibonacci(10) = {test.CycleFibonacci(10)}");
            Console.WriteLine($"Fibonacci(20) = {test.CycleFibonacci(20)}");
        }
    }
}
