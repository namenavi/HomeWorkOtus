using System.Collections.Immutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Work12Lesson37.TheHouse
{
    public class Part1 : IPart
    {
        private ImmutableList<string> poem;
        public ImmutableList<string> Poem
        {
            get {  return poem; }
            set { poem = value; }
        }
        public void AddPart(ImmutableList<string> args)
        {
            poem = ImmutableList.Create<string>(args.ToArray<string>());
            poem = poem.Add("Вот дом,").Add("Который построил Джек.").Add($"{Environment.NewLine}");
        }
        public void AddPart()
        {
            Poem = ImmutableList.Create<string>(
                "Вот дом,",
                "Который построил Джек.",
                $"{Environment.NewLine}");
        }
    }
}