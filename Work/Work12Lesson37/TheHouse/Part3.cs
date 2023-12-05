namespace Work12Lesson37.TheHouse
{
    public class Part3 : IPart
    {
        private List<string> poem = new List<string>();
        public List<string> Poem => poem;

        public void AddPart(List<string> args)
        {
            foreach (var arg in args)
            {
                Poem.Add(arg);
            }
            Poem.Add("А это веселая птица-синица,");
            Poem.Add("Которая часто ворует пшеницу,");
            Poem.Add("Которая в темном чулане хранится");
            Poem.Add("В доме,");
            Poem.Add("Который построил Джек.");
            Poem.Add($"{Environment.NewLine}");
        }
    }
}