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
                if (c == '.')
                {
                    continue;
                }

                if (char.IsUpper(c))
                {
                    result.Append(' ');
                }

                result.Append(c);
            }

            return result.Remove(0, 1).ToString();
        }

        public static string RemoveCommonPrefix(this string value, string compareWith)
        {
            int indexLastDot = 0;
            for (int i = 0; i < value.Length && i < compareWith.Length&& value[i] == compareWith[i]; i++)
            {
                if (value[i] == '.')
                {
                    indexLastDot = i;
                }
            }

            return value.Substring(indexLastDot);
        }

        public static string ExtractExampleFromTest(this string test)
        {
            int start = test.IndexOf('(') + 1;
            int end = test.IndexOf(')', start);

            return test.Substring(start, end - start);
        }
    }
}