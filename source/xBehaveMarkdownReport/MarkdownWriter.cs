//-------------------------------------------------------------------------------
// <copyright file="MarkdownWriter.cs" company="Appccelerate">
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
    using System.Text;

    public class MarkdownWriter : IMarkupWriter
    {
        readonly StringBuilder report = new StringBuilder();

        public void WriteTitle(string title)
        {
            this.report.AppendLine(title);
            this.report.AppendLine(new string('=', title.Length));
        }

        public void WriteFixture(string fixtureName)
        {
            this.report.AppendLine();
            this.report.AppendLine(fixtureName);
            this.report.AppendLine(new string('-', fixtureName.Length));
        }

        public void WriteScenario(string scenarioName)
        {
            this.report.AppendLine();
            this.report.AppendLine($"### {scenarioName}");
        }

        public void WriteExample(string example)
        {
            this.report.AppendLine();
            this.report.AppendLine($"#### {example}");
            this.report.AppendLine();
        }

        public void WriteEmptyExample()
        {
            this.report.AppendLine();
        }

        public void WriteStep(string step)
        {
            this.report.AppendLine($"- {step}");
        }

        public string GetReport()
        {
            return this.report.ToString();
        }
    }
}