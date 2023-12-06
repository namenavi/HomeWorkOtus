namespace Work3Lesson10
{
    public class Dictionary : IDictionary
    {
        private bool _isInputC;
        private bool _isInputA;
        private bool _isInputB;
        private int _a;
        private int _b;
        private int _c;

        private string stringA;
        private string stringB;
        private string stringC;
        public string StringA
        {
            get => stringA;
            set
            {
                stringA = value;
                _isInputA =true;
                if(!int.TryParse(stringA, out _a))
                {
                    throw new ArgumentException($"Не верный формат параметра a.  {Environment.NewLine}Или значение параметра не должно быть больше {int.MaxValue} или меньше {int.MinValue}.");
                }
            }
        }
        public string StringB 
        { 
            get => stringB;
            set
            {
                stringB = value;
                _isInputB =true;
                if(!int.TryParse(stringB, out _b))
                {
                    throw new ArgumentException($"Не верный формат параметра b или значение параметра больше {int.MaxValue} или меньше {int.MinValue}.");
                }
            }
        }
        public string StringC 
        { 
            get => stringC;
            set
            {
                stringC = value;
                _isInputC =true;
                if(!int.TryParse(stringC, out _c))
                {
                    throw new ArgumentException($"Не верный формат параметра c или значение параметра больше {int.MaxValue} или меньше {int.MinValue}.");
                }
            }
        }
        /// <summary>
        /// Функция проверяет если записано не записано возвращает входной параметр, если записано то возвращает значение
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string InputC(string value)
        {
            if(_isInputC)
            {
                return StringC;
            }
            return value;
        }
        /// <summary>
        /// Функция проверяет если записано не записано возвращает входной параметр, если записано то возвращает значение
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string InputB(string value)
        {
            if(_isInputB)
            {
                return StringB;
            }
            return value;
        }
        /// <summary>
        /// Функция проверяет если записано не записано возвращает входной параметр, если записано то возвращает значение
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string InputA(string value)
        {
            if(_isInputA)
            {
                return StringA;
            }
            return value;
        }
        /// <summary>
        /// Решение квадратного уравнения
        /// </summary>
        public void QuadraticEquation()
        {
            try
            {
                double x1, x2;
                var discriminant = Math.Pow(_b, 2) - 4 * _a * _c;
                if(discriminant < 0)
                {
                    throw new UseException("Вещественных значений не найдено");
                }
                else
                {
                    /* пример
                        9 * x^2 + -12 * x + 4 = 0
                        a: 9
                        b: -12
                        c: 4
                        x = 0,6666666666666666
                     */
                    if(discriminant == 0) //квадратное уравнение имеет два одинаковых корня или один  
                    {
                        x1 = (double)(-_b) / (double)(2 * _a);
                        x2 = x1;
                        Console.WriteLine($"x = {x1}");
                    }
                    else //уравнение имеет два разных корня
                    {
                        x1 = (-_b + Math.Sqrt(discriminant)) / (2 * _a);
                        x2 = (-_b - Math.Sqrt(discriminant)) / (2 * _a);
                        Console.WriteLine($"x1 = {x1}; x2 = {x2}");
                    }
                }
            }
            catch(UseException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}