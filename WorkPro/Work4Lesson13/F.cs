using System.Text;

namespace Work4Lesson13
{
    [Serializable]
    public class F
    {
        public int I1 { get; set; }
        public int I2 { get; set; }
        public int I3 { get; set; }
        public int I4 { get; set; }
        public int I5 { get; set; }

        public static F Get() => new F() { I1 = 1, I2 = 2, I3 = 3, I4 = 4, I5 = 5 };
        public string ToText()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("\ti1: {0}", I1));
            sb.AppendLine(string.Format("\ti2: {0}", I2));
            sb.AppendLine(string.Format("\ti3: {0}", I3));
            sb.AppendLine(string.Format("\ti4: {0}", I4));
            sb.AppendLine(string.Format("\ti5: {0}", I5));
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
