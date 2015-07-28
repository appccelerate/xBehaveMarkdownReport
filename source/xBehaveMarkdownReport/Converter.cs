//-------------------------------------------------------------------------------
// <copyright file="Converter.cs" company="Appccelerate">
//   Copyright (c) 2008-2015
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace XBehaveMarkdownReport
{
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public class Converter
    {
        public string Convert(XDocument input)
        {
            StringBuilder report = new StringBuilder();

            var assemblies = input.Descendants("assembly");

            foreach (var assembly in assemblies)
            {
                var name = assembly.Attribute("name")?.Value ?? string.Empty;

                name = name.Substring(name.LastIndexOf('\\') + 1);
                name = name.Substring(0, name.LastIndexOf('.'));

                report.AppendLine(name);
                report.AppendLine(new string('=', name.Length));

                var collections = assembly.Descendants("collection");
                foreach (var collection in collections)
                {
                    var collectionName = collection.Attribute("name")?.Value ?? string.Empty;
                    collectionName = collectionName.Substring(collectionName.LastIndexOf('.') + 1);
                    collectionName = collectionName.CamelToSpace();
                    
                    report.AppendLine();
                    report.AppendLine(collectionName);
                    report.AppendLine(new string('-', collectionName.Length));
                    
                    var tests = collection.Descendants("test").GroupBy(test => test.Attribute("method").Value);
                    foreach (var testGroup in tests)
                    {
                        report.AppendLine();
                        report.AppendLine($"### {testGroup.Key.CamelToSpace()}");
                        report.AppendLine();

                        foreach (var test in testGroup)
                        {
                            var testName = test.Attribute("name")?.Value ?? string.Empty;
                            testName = testName.Substring(testName.IndexOf(']') + 1).TrimStart();
                            testName = testName.Replace("(Background) ", string.Empty);

                            report.AppendLine($"{testName}  ");
                        }
                    }
                }
            }

            return report.ToString();
        }
    }

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