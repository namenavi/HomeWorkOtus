namespace Work12Lesson37.TheHouse
{
    public interface IPart
    {
        List<string> Poem { get; }
        void AddPart(List<string> args);
    }
}