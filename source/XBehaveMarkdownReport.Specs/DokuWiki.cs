//-------------------------------------------------------------------------------
// <copyright file="DokuWiki.cs" company="Appccelerate">
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

namespace XBehaveMarkdownReport.Specs
{
    using System.Xml.Linq;

    using ApprovalTests;

    using Xunit;

    public class DokuWiki
    {
        [Fact]
        public void Converts()
        {
            Converter converter = new Converter(new DokuWikiWriter());
                
            string result = converter.Convert(Input);
                
            Approvals.Verify(result);
        }

        private static readonly XDocument Input = XDocument.Parse(
            @"<?xml version=""1.0"" encoding=""utf-8""?>
<assemblies>
  <assembly name=""C:\projects\xBehaveMarkdownReport\source\SampleSpecs\bin\Debug\SampleSpecs.DLL"" environment=""64-bit .NET 4.0.30319.42000 [collection-per-class, parallel]"" test-framework=""xUnit.net 2.0.0.2929"" run-date=""2015-08-05"" run-time=""16:31:44"" config-file=""C:\temp\xunit.runner.console.2.0.0\tools\xunit.console.exe.Config"" total=""20"" passed=""20"" failed=""0"" skipped=""0"" time=""0.140"" errors=""0"">
    <errors />
    <collection total=""15"" passed=""15"" failed=""0"" skipped=""0"" name=""Test collection for SampleSpecs.Examples.ExampleSpec"" time=""0.013"">
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithArrays(words: [&quot;hello&quot;, &quot;world&quot;], numbers: [17, 42]) [01] establish hello, world as words"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithArrays"" time=""0.0030742"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithArrays(words: [&quot;hello&quot;, &quot;world&quot;], numbers: [17, 42]) [02] when counting 17, 42"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithArrays"" time=""0.0000671"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithArrays(words: [&quot;hello&quot;, &quot;world&quot;], numbers: [17, 42]) [03] it should work"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithArrays"" time=""0.0000576"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithExamples(word: &quot;hello&quot;, number: 42) [01] establish hello as a word"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithExamples"" time=""0.0026213"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithExamples(word: &quot;hello&quot;, number: 42) [02] when counting to 42"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithExamples"" time=""0.0000905"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithExamples(word: &quot;hello&quot;, number: 42) [03] it should work"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithExamples"" time=""0.0000763"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithExamples(word: &quot;world&quot;, number: 17) [01] establish world as a word"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithExamples"" time=""0.0000018"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithExamples(word: &quot;world&quot;, number: 17) [02] when counting to 17"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithExamples"" time=""0.0000012"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithExamples(word: &quot;world&quot;, number: 17) [03] it should work"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithExamples"" time=""0.0000012"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithMemberData(word: &quot;hello&quot;, number: 42) [01] establish hello as a word"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithMemberData"" time=""0.0000585"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithMemberData(word: &quot;hello&quot;, number: 42) [02] when counting to 42"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithMemberData"" time=""0.000051"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithMemberData(word: &quot;hello&quot;, number: 42) [03] it should work"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithMemberData"" time=""0.000051"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithMemberData(word: &quot;world&quot;, number: 17) [01] establish world as a word"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithMemberData"" time=""0.0000036"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithMemberData(word: &quot;world&quot;, number: 17) [02] when counting to 17"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithMemberData"" time=""0.0000015"" result=""Pass"" />
      <test name=""SampleSpecs.Examples.ExampleSpec.ScenarioWithMemberData(word: &quot;world&quot;, number: 17) [03] it should work"" type=""SampleSpecs.Examples.ExampleSpec"" method=""ScenarioWithMemberData"" time=""0.0000012"" result=""Pass"" />
    </collection>
    <collection total=""8"" passed=""8"" failed=""0"" skipped=""0"" name=""Test collection for SampleSpecs.BasicSpecs"" time=""0.009"">
      <test name=""SampleSpecs.BasicSpecs.ThisIsAScenario() [01] establish something"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAScenario"" time=""0.0025522"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAScenario() [02] when doing something"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAScenario"" time=""0.0000609"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAScenario() [03] it should be this"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAScenario"" time=""0.0000516"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAScenario() [04] it should not be that"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAScenario"" time=""0.0000498"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAnotherScenario() [01] establish something"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAnotherScenario"" time=""0.000079"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAnotherScenario() [02] when doing something"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAnotherScenario"" time=""0.0000724"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAnotherScenario() [03] it should be this"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAnotherScenario"" time=""0.0000736"" result=""Pass"" />
      <test name=""SampleSpecs.BasicSpecs.ThisIsAnotherScenario() [04] it should not be that"" type=""SampleSpecs.BasicSpecs"" method=""ThisIsAnotherScenario"" time=""0.000073"" result=""Pass"" />
    </collection>
  </assembly>
</assemblies>");
    }
}