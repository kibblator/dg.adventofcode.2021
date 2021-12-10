using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day10;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day10
{
    public class SyntaxScoringTests
    {
        private readonly ITestOutputHelper _output;

        public SyntaxScoringTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("()")]
        [InlineData("([])")]
        [InlineData("{()()()}")]
        [InlineData("<([{}])>")]
        [InlineData("[<>({}){}[([])<>]]")]
        [InlineData("(((((((((())))))))))")]
        public void ValidChunks_ReturnNoMismatched(string input)
        {
            var mismatched = new SyntaxScoring().ValidateInput(input);
            Assert.Equal(string.Empty, mismatched);
        }

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "[({(<(())[]>[[{[]{<()<>>",
                    "[(()[<>])]({[<{<<[]>>(",
                    "{([(<{}[<>[]}>{[]{[(<()>",
                    "(((({<>}<{<{<>}{[]{[]{}",
                    "[[<[([]))<([[{}[[()]]]",
                    "[{[{({}]{}}([{[{{{}}([]",
                    "{<[[]]>}<{[{[{[]{()[[[]",
                    "[<(<(<(<{}))><([]([]()",
                    "<{([([[(<>()){}]>(<<{{",
                    "<{([{{}}[<[[[<>{}]]]>[]]"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase(params string[] input)
        {
            var errorScore = new SyntaxScoring().GetErrorScore(input.ToList());

            Assert.Equal(15, errorScore);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SyntaxScoring.txt");

            var scoring = new SyntaxScoring();
            var result = scoring.GetErrorScore(input);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase_Part2(params string[] input)
        {
            var errorScore = new SyntaxScoring().GetAutoCompleteScore(input.ToList());

            Assert.Equal(288957, errorScore);
        }

        [Fact]
        public void Part2Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SyntaxScoring.txt");

            var scoring = new SyntaxScoring();
            var result = scoring.GetAutoCompleteScore(input);

            _output.WriteLine(result.ToString());
        }
    }
}
