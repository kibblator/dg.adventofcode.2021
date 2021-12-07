using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day7;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day7
{
    public class WhalesTests
    {
        private readonly ITestOutputHelper _output;

        public WhalesTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("16,1,2,0,4,2,7,1,2,14")]
        public void ExampleTestCase(string input)
        {
            var fuelSpent = new Whales().CalculateFuel(input);

            Assert.Equal(37, fuelSpent);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadString("TestData\\Whales.txt");

            var fuelSpent = new Whales();
            var result = fuelSpent.CalculateFuel(input);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [InlineData("16,1,2,0,4,2,7,1,2,14")]
        public void ExampleTestCase2(string input)
        {
            var fuelCost = new Whales().CalculateFuel(input, true);

            Assert.Equal(168, fuelCost);
        }

        [Fact]
        public void Part2Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadString("TestData\\Whales.txt");

            var fuelCost = new Whales();
            var result = fuelCost.CalculateFuel(input, true);

            _output.WriteLine(result.ToString());
        }
    }
}
