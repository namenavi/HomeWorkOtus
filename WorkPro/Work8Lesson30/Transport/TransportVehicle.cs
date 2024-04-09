namespace Work8Lesson30.Transport
{
    /// <summary>
    /// Базовый класс Транспортное Средство
    /// </summary>
    public abstract class TransportVehicle : ICloneable
    {
        public string Model { get; set; }

        public abstract object Clone();
        public abstract TransportVehicle MyClone();

    }

}
