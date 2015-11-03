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
        private const int Ok = 0;
        private const int InvalidFunction = 1;
        private const int FileNotFound = 2;
        private const int InvalidMarkup = 3;

        private const string Markdown = "markdown";
        private const string DokuWiki = "dokuwiki";

        public static int Main(string[] args)
        {
            string input = null;
            string output = null;
            string markup = Markdown;

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
                    .WithNamed("m", v => markup = v)
                        .HavingLongAlias("markup")
                        .DescribedBy($"markup [{Markdown} | {DokuWiki}]", "specifies which markup to use")
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
                return InvalidFunction;
            }

            if (!File.Exists(input))
            {
                Console.WriteLine("Input file '{0}' does not exist, please define an existing file.", input);
                return FileNotFound;
            }

            IMarkupWriter markupWriter;
            switch (markup.ToLowerInvariant())
            {
                case Markdown:
                    markupWriter = new MarkdownWriter();
                    break;

                case DokuWiki:
                    markupWriter = new DokuWikiWriter();
                    break;

                default:
                    return InvalidMarkup;
            }

            var inputXml = XDocument.Load(input);

            var converter = new Converter(markupWriter);

            var outputMarkdown = converter.Convert(inputXml);

            using (var writer = new StreamWriter(output))
            {
                writer.Write(outputMarkdown);
            }

            return Ok;
        }
    }
}