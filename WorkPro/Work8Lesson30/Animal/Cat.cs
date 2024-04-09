namespace Work8Lesson30.Animal
{
    /// <summary>
    /// Производный класс Кошка, наследуется от Млекопитающего
    /// </summary>
    public class Cat : Mammal, IMyCloneable<Cat>
    {
        public int NumberOfLives { get; set; } = 9;
        public Cat(string name, bool hasFur, int legs, int numberOfLives) : base(name, hasFur, legs)
        {
            NumberOfLives = numberOfLives;
        }

        public override Cat MyClone()
        {
            return new Cat(Name, HasFur, Legs, NumberOfLives);
        }

    }

}
