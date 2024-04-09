namespace Work8Lesson30.Transport
{
    /// <summary>
    /// Производный класс Грузовик, наследуется от Автомобиля
    /// </summary>
    public class Truck : Car, IMyCloneable<Truck>
    {
        public Truck(string model, int numberOfDoors, int loadCapacity) : base(model, numberOfDoors)
        {
            LoadCapacity = loadCapacity;
        }

        public int LoadCapacity { get; set; }

        public override Truck MyClone()
        {
            return new Truck(Model, NumberOfDoors, LoadCapacity);
        }
    }

}
