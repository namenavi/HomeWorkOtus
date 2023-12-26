using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Work4Lesson13.CSV
{
    /// <summary>
	/// Сериализация и десериализация объектов любого типа в CSV.
	/// </summary>
	public class CsvSerializer<T> where T : class, new()
    {
        #region Поля
        private bool _ignoreEmptyLines = true;

        private string _newlineReplacement = ((char)0x254).ToString();

        private List<PropertyInfo> _properties;

        private string _replacement = ((char)0x255).ToString();

        private char _separator = ',';

        private bool _useTextQualifier = false;

        #endregion

        #region Свойства
        public bool IgnoreEmptyLines
        {
            get { return _ignoreEmptyLines; }
            set { _ignoreEmptyLines = value; }
        }

        public string NewlineReplacement
        {
            get { return _newlineReplacement; }
            set { _newlineReplacement = value; }
        }

        public string Replacement
        {
            get { return _replacement; }
            set { _replacement = value; }
        }

        public char Separator
        {
            get { return _separator; }
            set { _separator = value; }
        }

        public bool UseTextQualifier
        {
            get { return _useTextQualifier; }
            set { _useTextQualifier = value; }
        }

        #endregion

        /// <summary>
        /// Csv-сериализатор
        /// </summary>
        public CsvSerializer()
        {
            var type = typeof(T);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.GetProperty | BindingFlags.SetProperty);

            var q = properties.AsQueryable();

            var r = from a in q
                    where a.GetCustomAttribute<CsvIgnoreAttribute>() == null
                    orderby a.Name
                    select a;

            _properties = r.ToList();
        }

        /// <summary>
        /// ДеСериализация
        /// </summary>
        /// <param name="stream">поток</param>
        /// <returns></returns>
        public T Deserialize(Stream stream)
        {
            string[] columns;
            string[] rows;
            var datum = new T();

            try
            {
                using (var sr = new StreamReader(stream))
                {
                    columns = sr.ReadLine().Split(Separator);
                    rows = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                }

            }
            catch (Exception ex)
            {
                throw new InvalidCsvFormatException("Файл CSV недействителен.Дополнительную информацию см.в разделе Внутреннее исключение.", ex);
            }

            var data = new List<T>();

            for (int row = 0; row < rows.Length; row++)
            {
                var line = rows[row];

                if (IgnoreEmptyLines && string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (!IgnoreEmptyLines && string.IsNullOrWhiteSpace(line))
                {
                    throw new InvalidCsvFormatException(string.Format(@"Ошибка: Пустая строка с номером строки: {0}", row));
                }

                var parts = line.Split(Separator);


                for (int i = 0; i < parts.Length; i++)
                {
                    var value = parts[i];
                    var column = columns[i];

                    value = value
                        .Replace(Replacement, Separator.ToString())
                        .Replace(NewlineReplacement, Environment.NewLine).Trim();

                    var p = _properties.FirstOrDefault(a => a.Name.Equals(column, StringComparison.InvariantCultureIgnoreCase));

                    if (p == null)
                    {
                        continue;
                    }

                    if (UseTextQualifier)
                    {
                        if (value.IndexOf("\"") == 0)
                            value = value.Substring(1);

                        if (value[value.Length - 1].ToString() == "\"")
                            value = value.Substring(0, value.Length - 1);
                    }

                    var converter = TypeDescriptor.GetConverter(p.PropertyType);
                    var convertedvalue = converter.ConvertFrom(value);

                    p.SetValue(datum, convertedvalue);
                }

                data.Add(datum);
            }

            return datum;
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <param name="data">Данные</param>
        public void Serialize(Stream stream, T data)
        {
            var sb = new StringBuilder();
            var values = new List<string>();

            sb.AppendLine(GetHeader());

            foreach (var p in _properties)
            {
                var raw = p.GetValue(data);
                var value = raw == null ? "" :
                    raw.ToString()
                    .Replace(Separator.ToString(), Replacement)
                    .Replace(Environment.NewLine, NewlineReplacement);

                if (UseTextQualifier)
                {
                    value = string.Format("\"{0}\"", value);
                }
                values.Add(value);
            }
            sb.AppendLine(string.Join(Separator.ToString(), values));

            using (var sw = new StreamWriter(stream))
            {
                sw.Write(sb.ToString().Trim());
            }
        }

        /// <summary>
        /// Получить заголовок
        /// </summary>
        /// <returns></returns>
        private string GetHeader()
        {
            var header = _properties.Select(a => a.Name);
            return string.Join(Separator.ToString(), header.ToArray());
        }
    }
}
