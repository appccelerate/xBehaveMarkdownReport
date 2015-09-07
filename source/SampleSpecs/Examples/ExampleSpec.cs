namespace SampleSpecs.Examples
{
    using System.Collections;
    using System.Collections.Generic;

    using Xbehave;

    using Xunit;

    public class ExampleSpec
    {
        [Scenario]
        [Example("hello", 42)]
        [Example("world", 17)]
        public void ScenarioWithExamples(string word, int number)
        {
            "establish {0} as a word"._(() => { });

            $"when counting to {number}"._(() => { });

            "it should work"._(() => { });
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                yield return new object[] { "hello", 42 };
                yield return new object[] { "world", 17 };
            }
        }

        [Scenario]
        [MemberData("Data")]
        public void ScenarioWithMemberData(string s, int i)
        {
            "establish {0} as a word"._(() => { });

            $"when counting to {i}"._(() => { });

            "it should work"._(() => { });
        }

        [Scenario]
        [Example(new[] { "hello", "world" }, new[] { 17, 42 })]
        public void ScenarioWithArrays(string[] words, int[] numbers)
        {
            $"establish {string.Join(", ", words)} as words"._(() => { });

            $"when counting {string.Join(", ", numbers)}"._(() => { });

            "it should work"._(() => { });
        }
    }
}