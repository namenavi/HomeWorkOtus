/*
 BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i7-3770 CPU 3.40GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX [AttachedDebugger]
  Job-FIPKKQ : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX

Runtime=.NET 8.0  InvocationCount=3  IterationCount=1000
LaunchCount=10  UnrollFactor=1  WarmupCount=10

| Method          | Mean       | Error   | StdDev    | Median     |
|---------------- |-----------:|--------:|----------:|-----------:|
| JsonSerialize   |   766.9 us | 2.30 us |  68.20 us |   755.2 us |
| JsonDeserialize |   252.9 us | 1.43 us |  42.26 us |   241.7 us |
| CsvSerialize    | 3,655.2 us | 9.97 us | 291.28 us | 3,594.1 us |
| CsvDeserialize  | 1,713.7 us | 4.46 us | 130.24 us | 1,699.9 us |
 */
using BenchmarkDotNet.Running;

namespace Work4Lesson13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new TestClass();
            BenchmarkRunner.Run<TestClass>();
            Console.WriteLine("Good bye!");
        }
    }
}
