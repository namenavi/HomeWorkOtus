using System.Text;

namespace Work3Lesson10
{
    internal class Program
    {
        static int _origRow;
        static StringBuilder _inputText;
        static Dictionary _dataABC;
        static bool _isWhile = true;

        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    _dataABC = new Dictionary();
                    if(_isWhile)
                    {
                        ProgramBody();
                    }
                    Console.WriteLine("Запустить снова нажмите [Enter], завершить приложение [ESC]");
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
                catch(ArgumentException ex)
                {
                    _isWhile = false;
                    FormatData(ex.Message, Severity.info, _dataABC);
                }
                catch(UseException ex)
                {
                    _isWhile = false;
                    FormatData(ex.Message, Severity.Warning, _dataABC);
                }
                catch(Exception ex)
                {
                    _isWhile = false;
                    FormatData(ex.Message, Severity.Error, _dataABC);
                }
            }
        }
        /// <summary>
        /// Основня логика приложения
        /// </summary>
        static void ProgramBody()
        {
            _isWhile = true;
            _inputText = new StringBuilder();
            SetCursor();
            while(_isWhile)
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
                        int len = _inputText.Length;
                        if(len>0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            _inputText.Remove(--len, 1);
                        }
                        break;
                    default:
                        char input = keyPress.KeyChar;
                        _inputText.Append(input);
                        Console.Write(input);
                        break;
                }
            }
        }
        /// <summary>
        /// Метод который определяет где находится курсору
        /// </summary>
        /// <param name="key"></param>
        private static void SetCursor(ConsoleKey key = ConsoleKey.Home)
        {
            _origRow = Console.CursorTop;
            if(key == ConsoleKey.Home)
            {
                WriteAt(2);
            }
            else if(key == ConsoleKey.DownArrow)
            {
                switch(_origRow)
                {
                    case 2:
                        _dataABC.StringA =  _inputText.ToString();
                        _inputText.Clear();
                        WriteAt(3);
                        break;
                    case 3:
                        _dataABC.StringB =  _inputText.ToString();
                        _inputText.Clear();
                        WriteAt(4);
                        break;
                    default:
                        break;
                }
            }
            else if(key == ConsoleKey.Enter)
            {
                if(Console.CursorTop == 4 && _inputText.ToString() != string.Empty)
                {
                    _dataABC.StringC =  _inputText.ToString();
                    _inputText.Clear();
                    WriteAt(5);
                    _isWhile = false;
                    _dataABC.QuadraticEquation();
                }
            }
        }
        /// <summary>
        /// Метод который перерисовывает строки
        /// </summary>
        /// <param name="x"></param>
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
                        Console.WriteLine($"{_dataABC.InputA("a")} * x^2 + {_dataABC.InputB("b")} * x + {_dataABC.InputC("c")} = 0");
                        Console.WriteLine("> a: ");
                        Console.WriteLine("b: ");
                        Console.WriteLine("c: ");
                        Console.SetCursorPosition(5, 2);
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{_dataABC.InputA("a")} * x^2 + {_dataABC.InputB("b")} * x + {_dataABC.InputC("c")} = 0");
                        Console.WriteLine($"a: {_dataABC.InputA("")}");
                        Console.WriteLine($"> b: {_dataABC.InputB("")}");
                        Console.WriteLine("c: ");
                        Console.SetCursorPosition(5, 3);
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{_dataABC.InputA("a")} * x^2 + {_dataABC.InputB("b")} * x + {_dataABC.InputC("c")} = 0");
                        Console.WriteLine($"a: {_dataABC.InputA("")}");
                        Console.WriteLine($"b: {_dataABC.InputB("")}");
                        Console.WriteLine($"> c: ");
                        Console.SetCursorPosition(5, 4);
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Решаем уравнение: ");
                        Console.WriteLine($"{_dataABC.InputA("a")} * x^2 + {_dataABC.InputB("b")} * x + {_dataABC.InputC("c")} = 0");
                        Console.WriteLine($"a: {_dataABC.InputA("")}");
                        Console.WriteLine($"b: {_dataABC.InputB("")}");
                        Console.WriteLine($"c: {_dataABC.InputC("")}");
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
        /// <summary>
        /// Метод который используется для отработки исключений
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <param name="data"></param>
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
            else if(severity == Severity.info)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
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
                Console.WriteLine($"a = {data.StringA}");
                Console.WriteLine($"b = {data.StringB}");
                Console.WriteLine($"c = {data.StringC}");
                Console.ResetColor();
            }
        }
    }
}