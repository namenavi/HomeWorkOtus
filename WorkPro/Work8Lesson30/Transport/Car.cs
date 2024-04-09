using Work8Lesson30.Device;

namespace Work8Lesson30.Transport
{
    /// <summary>
    /// Производный класс Автомобиль, наследуется от Транспортного Средства
    /// </summary>
    public class Car : TransportVehicle, IMyCloneable<Car>
    {
        public int NumberOfDoors { get; set; }
        public Car(string model, int numberOfDoors)
        {
            NumberOfDoors = numberOfDoors;
            Model = model;
        }
        public override Car MyClone()
        {
            return new Car(Model, NumberOfDoors);
            // return (TransportVehicle)this.MemberwiseClone(); // или так Поверхностное копирование
        }
        public override object Clone()
        {
            return MyClone();
        }
    }

}
