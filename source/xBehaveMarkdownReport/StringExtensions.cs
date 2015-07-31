namespace XBehaveMarkdownReport
{
    using System.Text;

    public static class StringExtensions
    {
        public static string CamelToSpace(this string value)
        {
            var result = new StringBuilder();

            foreach (var c in value)
            {
                if (char.IsUpper(c))
                {
                    result.Append(' ');
                }

                result.Append(c);
            }

            return result.Remove(0, 1).ToString();
        }
    }
}