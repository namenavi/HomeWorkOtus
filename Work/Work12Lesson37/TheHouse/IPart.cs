using System.Collections.Immutable;

namespace Work12Lesson37.TheHouse
{
    public interface IPart
    {
        ImmutableList<string> Poem { get; set; }
        void AddPart(ImmutableList<string> args);
    }
}