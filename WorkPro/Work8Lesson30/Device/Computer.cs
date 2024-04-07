namespace Work8Lesson30.Device
{
    /// <summary>
    /// Производный класс Компьютер, наследуется от Устройства
    /// </summary>
    public class Computer : Device
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

        public override Device MyClone()
        {
            return new Computer(SerialNumber, OperatingSystem);
        }
    }
}
