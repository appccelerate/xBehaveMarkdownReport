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
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    public class Converter
    {
        private readonly Regex namePattern = new Regex(@"[\w\.]+\(.*\) \[[0-9]{2}\] (?<name>.*)", RegexOptions.Compiled);

        private readonly IMarkupWriter writer;

        public Converter(IMarkupWriter writer)
        {
            this.writer = writer;
        }

        public string Convert(XDocument input)
        {
            var assemblies = input.Descendants("assembly").OrderBy(a => a.GetAssemblyName());

            foreach (var assembly in assemblies)
            {
                var name = assembly.GetAssemblyName();
                name = name.Substring(0, name.LastIndexOf('.'));

                this.writer.WriteTitle(name.CamelToSpace());

                var collections = assembly
                    .Descendants("collection")
                    .OrderBy(c => c.Attribute("name")?.Value ?? string.Empty)
                    .ToList();
                foreach (var collection in collections)
                {
                    var fixtures = collection
                        .Descendants("test")
                        .GroupBy(test => test.Attribute("type").Value)
                        .OrderBy(f => f.Key);
                    foreach (var fixture in fixtures)
                    {
                        var fixtureName = fixture.Key;
                        fixtureName = fixtureName.RemoveCommonPrefix(assembly.GetAssemblyName());
                        fixtureName = fixtureName.CamelToSpace();

                        this.writer.WriteFixture(fixtureName);
                        
                        var tests = fixture.GroupBy(test => test.Attribute("method").Value);
                        foreach (var testGroup in tests)
                        {
                            this.writer.WriteScenario(testGroup.Key.CamelToSpace());
                            
                            var examples = testGroup.GroupBy(g => g.Attribute("name").Value.ExtractExampleFromTest());

                            foreach (var example in examples)
                            {
                                if (!string.IsNullOrWhiteSpace(example.Key))
                                {
                                    this.writer.WriteExample(example.Key);
                                }
                                else
                                {
                                    this.writer.WriteEmptyExample();
                                }

                                foreach (var test in example)
                                {
                                    var testName = test.Attribute("name")?.Value ?? string.Empty;

                                    var match = this.namePattern.Match(testName);
                                    var step = match.Groups["name"];

                                    this.writer.WriteStep(step.ToString());
                                }
                            }
                        }
                    }
                }
            }

            return this.writer.GetReport();
        }
    }
}