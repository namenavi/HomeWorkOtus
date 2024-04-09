namespace Work8Lesson30.Device
{
    /// <summary>
    /// Производный класс Ноутбук, наследуется от Компьютера
    /// </summary>
    public class Laptop : Computer, IMyCloneable<Laptop>
    {
        public bool HasTouchScreen { get; set; }
        public Laptop(string serialNumber, string operatingSystem, bool hasTouchScreen) : base(serialNumber, operatingSystem)
        {
            HasTouchScreen = hasTouchScreen;
        }
        public override object Clone()
        {
            return MyClone();
        }

        public override Laptop MyClone()
        {
            return new Laptop(SerialNumber, OperatingSystem, HasTouchScreen);
        }
    }
}
