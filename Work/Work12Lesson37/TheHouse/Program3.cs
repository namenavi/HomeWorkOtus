namespace Work12Lesson37.TheHouse
{
    /// <summary>
    /// Программа Дом, который построил Джек
    /// </summary>
    public static class Program3
    {
        public static void Start()
        {
            var part1 = new Part1();
            var part2 = new Part2();
            var part3 = new Part3();
            var part4 = new Part4();
            var part5 = new Part5();
            var part6 = new Part6();
            var part7 = new Part7();
            var part8 = new Part8();
            var part9 = new Part9();
            part1.AddPart(new List<string>());
            part2.AddPart(part1.Poem);
            part3.AddPart(part2.Poem);
            part4.AddPart(part3.Poem);
            part5.AddPart(part4.Poem);
            part6.AddPart(part5.Poem);
            part7.AddPart(part6.Poem);
            part8.AddPart(part7.Poem);
            part9.AddPart(part8.Poem);

            foreach (var part in part1.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part2.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part3.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part4.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part5.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part6.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part7.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part8.Poem)
            {
                Console.WriteLine(part);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
            foreach (var part in part9.Poem)
            {
                Console.WriteLine(part);
            }
        }
    }
}