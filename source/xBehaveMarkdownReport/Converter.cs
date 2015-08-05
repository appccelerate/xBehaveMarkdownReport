//-------------------------------------------------------------------------------
// <copyright file="Converter.cs" company="Urs Enzler">
//   Copyright (c) 2015-2015
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
                var assemblyName = assembly.Attribute("name")?.Value ?? string.Empty;
                assemblyName = assemblyName.Substring(assemblyName.LastIndexOf('\\') + 1);

                var name = assemblyName;
                name = name.Substring(0, name.LastIndexOf('.'));

                report.AppendLine(name.CamelToSpace());
                report.AppendLine(new string('=', name.Length));

                var collections = assembly.Descendants("collection");
                foreach (var collection in collections)
                {
                    var fixtures = collection.Descendants("test").GroupBy(test => test.Attribute("type").Value);
                    foreach (var fixture in fixtures)
                    {
                        var fixtureName = fixture.Key;
                        fixtureName = fixtureName.RemoveCommonPrefix(assemblyName);
                        fixtureName = fixtureName.CamelToSpace();

                        report.AppendLine();
                        report.AppendLine(fixtureName);
                        report.AppendLine(new string('-', fixtureName.Length));
                        
                        var tests = fixture.GroupBy(test => test.Attribute("method").Value);
                        foreach (var testGroup in tests)
                        {
                            report.AppendLine();
                            report.AppendLine($"### {testGroup.Key.CamelToSpace()}");
                            
                            var examples = testGroup.GroupBy(g => g.Attribute("name").Value.ExtractExampleFromTest());

                            foreach (var example in examples)
                            {
                                report.AppendLine();

                                if (!string.IsNullOrWhiteSpace(example.Key))
                                {
                                    report.AppendLine($"#### {example.Key}");
                                    report.AppendLine();
                                }

                                foreach (var test in example)
                                {
                                    var testName = test.Attribute("name")?.Value ?? string.Empty;
                                    testName = testName.Substring(testName.IndexOf(']') + 1).TrimStart();
                                    testName = testName.Replace("(Background) ", string.Empty);

                                    report.AppendLine($"- {testName}");
                                }
                            }
                        }
                    }
                }
            }

            return report.ToString();
        }
    }
}