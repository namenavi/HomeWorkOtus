namespace Work12Lesson37.TheHouse
{
    public class Part8 : IPart
    {
        private List<string> poem = new List<string>();
        public List<string> Poem => poem;

        public void AddPart(List<string> args)
        {
            foreach (var arg in args)
            {
                Poem.Add(arg);
            }
            Poem.Add("А это ленивый и толстый пастух,");
            Poem.Add("Который бранится с коровницей строгою,");
            Poem.Add("Которая доит корову безрогую,");
            Poem.Add("Лягнувшую старого пса без хвоста,");
            Poem.Add("Который за шиворот треплет кота,");
            Poem.Add("Который пугает и ловит синицу,");
            Poem.Add("Которая часто ворует пшеницу,");
            Poem.Add("Которая в темном чулане хранится");
            Poem.Add("В доме,");
            Poem.Add("Который построил Джек.");
            Poem.Add($"{Environment.NewLine}");
        }
    }
}