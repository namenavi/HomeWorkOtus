namespace Work8Lesson30.Animal
{
    /// <summary>
    /// Базовый класс Животное
    /// </summary>
    public abstract class Animal : IMyCloneable<Animal>, ICloneable
    {
        public string Name { get; set; }

        public abstract object Clone();

        public abstract Animal MyClone();
    }

}
