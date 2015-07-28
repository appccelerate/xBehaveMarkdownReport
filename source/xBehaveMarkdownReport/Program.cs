//-------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Appccelerate">
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
    using System;
    using System.IO;
    using System.Xml.Linq;
    using Appccelerate.CommandLineParser;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = null;
            string output = null;

            var configuration = CommandLineParserConfigurator
                .Create()
                     .WithNamed("i", v => input = v)
                        .HavingLongAlias("input")
                        .Required()
                        .DescribedBy("path", "specifies the input path pointing to a xBehave/xUnit XML report.")
                    .WithNamed("o", v => output = v)
                        .HavingLongAlias("output")
                        .Required()
                        .DescribedBy("path", "specifies the output path where the generated markdown will be written to.")
                .BuildConfiguration();

            var parser = new CommandLineParser(configuration);
            var parseResult = parser.Parse(args);

            if (!parseResult.Succeeded)
            {
                Usage usage = new UsageComposer(configuration).Compose();
                Console.WriteLine(parseResult.Message);
                Console.WriteLine("usage:" + usage.Arguments);
                Console.WriteLine("options");
                Console.WriteLine(usage.Options.IndentBy(4));
                Console.WriteLine();

                return;
            }

            var inputXml = XDocument.Load(input);

            var converter = new Converter();

            var outputMarkdown = converter.Convert(inputXml);

            using (var writer = new StreamWriter(output))
            {
                writer.Write(outputMarkdown);
            }
         }
    }
}
