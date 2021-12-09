using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day9;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day9
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
                    "2199943210",
                    "3987894921",
                    "9856789892",
                    "8767896789",
                    "9899965678"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase(params string[] input)
        {
            var risk = new SmokeBasin().CalcRisk(input.ToList());

            Assert.Equal(15, risk);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SmokeBasin.txt");

            var risk = new SmokeBasin();
            var result = risk.CalcRisk(input);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase2(params string[] input)
        {
            var basinSizes = new SmokeBasin().CalcBasins(input.ToList());

            Assert.Equal(1134, basinSizes);
        }

        [Fact]
        public void Part2Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SmokeBasin.txt");

            var risk = new SmokeBasin();
            var result = risk.CalcBasins(input);

            _output.WriteLine(result.ToString());
        }
    }
}
