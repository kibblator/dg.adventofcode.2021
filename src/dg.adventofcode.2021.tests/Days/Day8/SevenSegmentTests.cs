using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day8;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day8
{
    public class SmokeBasinTests
    {
        private readonly ITestOutputHelper _output;

        public SmokeBasinTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
                    "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
                    "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
                    "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
                    "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
                    "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
                    "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
                    "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
                    "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
                    "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase(params string[] input)
        {
            var occurrences = new SevenSegment().CalcOccurrences(input.ToList());

            Assert.Equal(26, occurrences);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SevenSegment.txt");

            var occurrences = new SevenSegment();
            var result = occurrences.CalcOccurrences(input);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf")]
        public void ExampleTestCase2(string input)
        {
            var outputValue = new SevenSegment().CalcOutputValue(new List<string>{input});

            Assert.Equal(5353, outputValue);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase3(params string[] input)
        {
            var outputValue = new SevenSegment().CalcOutputValue(input.ToList());

            Assert.Equal(61229, outputValue);
        }

        [Fact]
        public void Part2Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SevenSegment.txt");

            var occurrences = new SevenSegment();
            var result = occurrences.CalcOutputValue(input);

            _output.WriteLine(result.ToString());
        }
    }
}
