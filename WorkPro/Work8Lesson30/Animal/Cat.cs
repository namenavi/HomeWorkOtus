namespace Work8Lesson30.Animal
{
    /// <summary>
    /// Производный класс Кошка, наследуется от Млекопитающего
    /// </summary>
    public class Cat : Mammal
    {
        public int NumberOfLives { get; set; } = 9;
        public Cat(string name, bool hasFur, int legs, int numberOfLives) : base(name, hasFur, legs)
        {
            NumberOfLives = numberOfLives;
        }

        public override Animal MyClone()
        {
            return new Cat(Name, HasFur, Legs, NumberOfLives);
        }

    }

}
