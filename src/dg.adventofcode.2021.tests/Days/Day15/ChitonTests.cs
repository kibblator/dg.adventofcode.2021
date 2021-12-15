using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day14;
using dg.adventofcode._2021.Days.Day15;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day15
{
    public class ChitonTests
    {
        private readonly ITestOutputHelper _output;

        public ChitonTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "1163751742",
                    "1381373672",
                    "2136511328",
                    "3694931569",
                    "7463417111",
                    "1319128137",
                    "1359912421",
                    "3125421639",
                    "1293138521",
                    "2311944581"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase(params string[] input)
        {
            var quantityDiff = new Chiton().GetPathRisk(input.ToList());

            Assert.Equal(40, quantityDiff);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\Chiton.txt");

            var chiton = new Chiton();
            var result = chiton.GetPathRisk(input);

            _output.WriteLine(result.ToString());
        }
    }
}
