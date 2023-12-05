namespace Work12Lesson37.TheHouse
{
    public class Part1 : IPart
    {
        private List<string> poem = new List<string>();
        public List<string> Poem => poem;
        public void AddPart(List<string> args)
        {
            foreach (var arg in args)
            {
                Poem.Add(arg);
            }
            Poem.Add("Вот дом,");
            Poem.Add("Который построил Джек.");
            Poem.Add($"{Environment.NewLine}");
        }
    }
}