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
            var occurrences = new SmokeBasin().CalcRisk(input.ToList());

            Assert.Equal(15, occurrences);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\SmokeBasin.txt");

            var occurrences = new SmokeBasin();
            var result = occurrences.CalcRisk(input);

            _output.WriteLine(result.ToString());
        }
    }
}
