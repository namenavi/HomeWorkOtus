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
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text.Json;

namespace Work4Lesson13
{
    [SimpleJob(RuntimeMoniker.Net80, 10, 10, 1000, 3)]
    public class TestClass
    {
        public TestClass()
        {
        }
        public void Show()
        {
            Csv();
            Json();
        }

        private void Json()
        {
            JsonSerialize();
            JsonDeserialize();
        }

        private void Csv()
        {
            CsvSerialize();
            CsvDeserialize();
        }

        [Benchmark]
        public void JsonSerialize()
        {
            var tf = F.Get();

            var json = JsonSerializer.Serialize(tf, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("json.json", json);
        }

        [Benchmark]
        public void JsonDeserialize()
        {
            var after = JsonSerializer.Deserialize<TestClass>(File.ReadAllText("json.json"));
        }

        [Benchmark]
        public void CsvSerialize()
        {
            var tf = F.Get();
            using(var stream = new FileStream("csv.csv", FileMode.Create, FileAccess.Write))
            {
                var cs = new CsvSerializer<F>()
                {
                    UseTextQualifier = true,
                };
                cs.Serialize(stream, tf);
            }

            F deserializedData = null;
            using(var stream = new FileStream("csv.csv", FileMode.Open, FileAccess.Read))
            {
                var cs = new CsvSerializer<F>()
                {
                    UseTextQualifier = true,
                };

                deserializedData = cs.Deserialize(stream);
            }
        }

        [Benchmark]
        public void CsvDeserialize()
        {
            F deserializedData = null;
            using(var stream = new FileStream("csv.csv", FileMode.Open, FileAccess.Read))
            {
                var cs = new CsvSerializer<F>()
                {
                    UseTextQualifier = true,
                };

                deserializedData = cs.Deserialize(stream);
            }
        }
    }
}
