using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day11;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day11
{
    public class DumboOctopusTests
    {
        private readonly ITestOutputHelper _output;

        public DumboOctopusTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "5483143223",
                    "2745854711",
                    "5264556173",
                    "6141336146",
                    "6357385478",
                    "4167524645",
                    "2176841721",
                    "6882881134",
                    "4846848554",
                    "5283751526"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase(params string[] input)
        {
            var numFlashes = new DumboOctopus().GetNumFlashes(input.ToList());

            Assert.Equal(1656, numFlashes);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\DumboOctopus.txt");

            var dumboOctopus = new DumboOctopus();
            var result = dumboOctopus.GetNumFlashes(input);

            _output.WriteLine(result.ToString());
        }
    }
}
