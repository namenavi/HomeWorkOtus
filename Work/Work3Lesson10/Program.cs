using System.Text;

namespace Work3Lesson10
{
    internal class Program
    {
        protected static int origRow;
        protected static int origCol;
        protected static StringBuilder inputText;
        protected static bool isInputA;
        protected static bool isInputB;
        protected static bool isInputC;
        protected static double x1, x2;
        protected static Dictionary dataABC;

        static void Main(string[] args)
        {
            ProgramBody();
        }

        static void ProgramBody()
        {
            try
            {
                dataABC = new Dictionary();
                inputText = new StringBuilder();
                SetCursor();
                while(true)
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey(true);

                    switch(keyPress.Key)
                    {
                        case ConsoleKey.Enter:
                            SetCursor(ConsoleKey.Enter);
                            break;
                        case ConsoleKey.DownArrow:
                            SetCursor(ConsoleKey.DownArrow);
                            break;
                        case ConsoleKey.Backspace:
                            int len = inputText.Length;
                            if(len>0)
                            {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                inputText.Remove(--len, 1);
                            }
                            break;
                        default:
                            char input = keyPress.KeyChar;
                            //if(char.IsDigit(input))    //// Можно проверку на число сделать сразу
                            //{
                            inputText.Append(input);
                            Console.Write(input);
                            //}
                            break;
                    }
                }
            }
            catch(ArgumentException ex)
            {
                FormatData(ex.Message, Severity.Error, dataABC);
                Restart();
            }
            catch(ArithmeticException ex)
            {
                FormatData(ex.Message, Severity.Warning, dataABC);
                Restart();
            }
            catch(Exception ex)
            {
                FormatData(ex.Message, Severity.Error, dataABC);
                Restart();
            }
        }

        private static void Restart()
        {
            Console.WriteLine("Запустить снова нажмите [Enter], завершить приложение [ESC]");
            while(true)
            {
                ConsoleKeyInfo keyPress = Console.ReadKey(true);

                switch(keyPress.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Enter:
                        ProgramBody();
                        break;
                    default:
                        break;
                }
            }
        }

        private static string InputC(string v)
        {
            if(isInputC)
            {
                return dataABC.StrringC;
            }
            return v;
        }

        private static string InputB(string v)
        {
            if(isInputB)
            {
                return dataABC.StrringB;
            }
            return v;
        }

        private static string InputA(string v)
        {
            if(isInputA)
            {
                return dataABC.StrringA;
            }
            return v;
        }



        private static void SetCursor(ConsoleKey key = ConsoleKey.Home)
        {
            origRow = Console.CursorTop;
            if(key == ConsoleKey.Home)
            {
                WriteAt(2);
            }
            else if(key == ConsoleKey.DownArrow)
            {
                switch(origRow)
                {
                    case 2:
                        dataABC.StrringA =  inputText.ToString();
                        isInputA = true;
                        inputText.Clear();
                        WriteAt(3);
                        break;
                    case 3:
                        dataABC.StrringB =  inputText.ToString();
                        isInputB = true;
                        inputText.Clear();
                        WriteAt(4);
                        break;
                    default:
                        break;
                }
            }
            else if(key == ConsoleKey.Enter)
            {
                dataABC.StrringC =  inputText.ToString();
                if(Console.CursorTop == 4 && dataABC.StrringC !="")
                {
                    
                    isInputC = true;
                    inputText.Clear();
                    WriteAt(5);
                    ParseStringToInt();
                    QuadraticEquation(dataABC);
                }
            }
        }

        static void ParseStringToInt()
        {
            if(!int.TryParse(dataABC.StrringA, out int _resultA))
            {
                throw new ArgumentException("Не верный формат параметра a");
            }
            dataABC.A = _resultA;

            if(!int.TryParse(dataABC.StrringB, out int _resultB))
            {
                throw new ArgumentException("Не верный формат параметра b");
            }
            dataABC.B =  _resultB;

            if(!int.TryParse(dataABC.StrringC, out int _resultC))
            {
                throw new ArgumentException("Не верный формат параметра c");
            }
            dataABC.C =  _resultC;
        }

        /// <summary>
        /// Решение квадратного уравнения
        /// </summary>
        static void QuadraticEquation(Dictionary dataABC)
        {
            var discriminant = Math.Pow(dataABC.B, 2) - 4 * dataABC.A * dataABC.C;
            if(discriminant < 0)
            {
                throw new ArithmeticException("Вещественных значений не найдено");
            }
            else
            {
                if(discriminant == 0) //квадратное уравнение имеет два одинаковых корня или один
                {
                    x1 = -dataABC.B / (2 * dataABC.A);
                    x2 = x1;
                    Console.WriteLine($"x = {x1}");
                }
                else //уравнение имеет два разных корня
                {
                    x1 = (-dataABC.B + Math.Sqrt(discriminant)) / (2 * dataABC.A);
                    x2 = (-dataABC.B - Math.Sqrt(discriminant)) / (2 * dataABC.A);
                    Console.WriteLine($"x1 = {x1}; x2 = {x2}");
                }
                Restart();
            }
        }

        protected static void WriteAt(int x)
        {
            try
            {
                switch(x)
                {
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{InputA("a")} * x^2 + {InputB("b")} * x + {InputC("c")} = 0");
                        Console.WriteLine("> a: ");
                        Console.WriteLine("b: ");
                        Console.WriteLine("c: ");
                        Console.SetCursorPosition(5, 2);
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{InputA("a")} * x^2 + {InputB("b")} * x + {InputC("c")} = 0");
                        Console.WriteLine($"a: {InputA("")}");
                        Console.WriteLine($"> b: {InputB("")}");
                        Console.WriteLine("c: ");
                        Console.SetCursorPosition(5, 3);
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{InputA("a")} * x^2 + {InputB("b")} * x + {InputC("c")} = 0");
                        Console.WriteLine($"a: {InputA("")}");
                        Console.WriteLine($"b: {InputB("")}");
                        Console.WriteLine($"> c: ");
                        Console.SetCursorPosition(5, 4);
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{InputA("a")} * x^2 + {InputB("b")} * x + {InputC("c")} = 0");
                        Console.WriteLine($"a: {InputA("")}");
                        Console.WriteLine($"b: {InputB("")}");
                        Console.WriteLine($"c: {InputC("")}");
                        Console.SetCursorPosition(0, 5);
                        break;
                    default:
                        break;
                }

            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static void FormatData(string message, Severity severity, IDictionary data)
        {
            if(severity == Severity.Warning)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(message);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("");
                Console.ResetColor();
            }
            else if(severity == Severity.Error)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(message);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine($"a = {data.StrringA}");
                Console.WriteLine($"b = {data.StrringB}");
                Console.WriteLine($"c = {data.StrringC}");
                Console.ResetColor();
            }
        }
    }
}