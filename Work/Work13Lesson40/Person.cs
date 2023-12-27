public class Person : IComparable<Person>
{
    public int Age { get; set; }
    public int CompareTo(Person other)
    {
        if(other == null)
            return 1;
        if(Age < other.Age)
        {
            return -1;
        }
        else if(Age > other.Age)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
