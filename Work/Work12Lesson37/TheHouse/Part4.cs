namespace Work12Lesson37.TheHouse
{
    public class Part4 : IPart
    {
        private List<string> poem = new List<string>();
        public List<string> Poem => poem;

        public void AddPart(List<string> args)
        {
            foreach (var arg in args)
            {
                Poem.Add(arg);
            }
            Poem.Add("Вот кот,");
            Poem.Add("Который пугает и ловит синицу,");
            Poem.Add("Которая часто ворует пшеницу,");
            Poem.Add("Которая в темном чулане хранится");
            Poem.Add("В доме,");
            Poem.Add("Который построил Джек.");
            Poem.Add($"{Environment.NewLine}");
        }
    }
}