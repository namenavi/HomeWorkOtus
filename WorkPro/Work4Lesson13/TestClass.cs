using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text.Json;
using Work4Lesson13.CSV;

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
