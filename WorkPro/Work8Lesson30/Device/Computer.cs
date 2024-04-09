namespace Work8Lesson30.Device
{
    /// <summary>
    /// Производный класс Компьютер, наследуется от Устройства
    /// </summary>
    public class Computer : Device, IMyCloneable<Computer>
    {
        public string OperatingSystem { get; set; }

        public Computer(string serialNumber, string operatingSystem)
        {
            SerialNumber = serialNumber;
            OperatingSystem = operatingSystem;
        }

        public override object Clone()
        {
            return MyClone();
        }

        public override Computer MyClone()
        {
            return new Computer(SerialNumber, OperatingSystem);
        }
    }
}
