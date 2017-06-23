namespace XBehaveMarkdownReport
{
    using System.Xml.Linq;

    public static class XElementExtensionMethods
    {
        public static string GetAssemblyName(this XElement element)
        {
            var assemblyName = element.Attribute("name")?.Value ?? string.Empty;
            return assemblyName.Substring(assemblyName.LastIndexOf('\\') + 1);
        }
    }
}