/*
Вывод: Преимущества IMyCloneable в том, что он обеспечивает типобезопасное клонирование и может быть адаптирован для конкретного класса. 
Недостаток в том, что это пользовательский интерфейс, который требует дополнительной реализации. 
ICloneable является стандартным интерфейсом .NET, что делает его узнаваемым, но он не обеспечивает типобезопасность и возвращает object, что может потребовать приведения типов.
 */
using Work8Lesson30.Animal;
using Work8Lesson30.Device;
using Work8Lesson30.Transport;

namespace Work8Lesson30
{
    class Program
    {
        public static void Main()
        {
            var prototype1 = new Car("Lada", 4);
            var clone1 = prototype1.MyClone();
            Console.WriteLine($"{clone1.Model},{clone1.NumberOfDoors}"); // Вывод:

            var prototype2 = new Truck("Камаз", 2, 300);
            var clone2 = prototype2.MyClone();
            prototype2.Model="Газель";
            prototype2.NumberOfDoors=8;
            Console.WriteLine($"{clone2.Model}, {clone2.NumberOfDoors}, {clone2.LoadCapacity}"); // Вывод: 



            var prototype3 = new Mammal("Собака", true, 4);
            var clone3 = prototype3.MyClone();
            Console.WriteLine($"{clone3.Name},{clone3.Legs}"); // Вывод:

            var prototype4 = new Cat("Муся", true, 4, 9); // дефолтный метод клонирования
            var clone4 = (Cat)prototype4.Clone();
            prototype4.Name="Тим";
            prototype4.NumberOfLives=8;
            Console.WriteLine($"{clone4.Name}, {clone4.NumberOfLives}, {clone4.Legs}"); // Вывод:


            var prototype5 = new Computer("111111", "Windows");
            var clone5 = prototype5.MyClone();
            Console.WriteLine($"{clone5.SerialNumber},{clone5.OperatingSystem}"); // Вывод:

            var prototype6 = new Laptop("2222222", "macOS", true);
            var clone6 = prototype6.MyClone();
            prototype6.OperatingSystem ="Android";
            prototype6.SerialNumber="33333333";
            Console.WriteLine($"{clone6.SerialNumber}, {clone6.OperatingSystem}, {clone6.HasTouchScreen}"); // Вывод:
        }
    }
}
