namespace Work8Lesson30.Animal
{
    /// <summary>
    /// Производный класс Млекопитающее, наследуется от Животного
    /// </summary>
    public class Mammal : Animal, IMyCloneable<Mammal>
    {
        public bool HasFur { get; set; }
        public int Legs { get; set; }

        public Mammal(string name, bool hasFur, int legs)
        {
            Name = name;
            HasFur = hasFur;
            Legs = legs;
        }

        public override object Clone()
        {
            return MyClone();
        }

        public override Mammal MyClone()
        {
            return new Mammal(Name, HasFur, Legs);
        }
    }

}
