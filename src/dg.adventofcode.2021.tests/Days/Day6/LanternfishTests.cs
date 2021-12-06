using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day6;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day6
{
    public class LanternfishTests
    {
        private readonly ITestOutputHelper _output;

        public LanternfishTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("3,4,3,1,2")]
        public void Lanternfish_ReturnsNumLanternfish(string input)
        {
            var numLanternFish = new Lanternfish().GetNumLanternfish(input, 80);

            Assert.Equal(5934, numLanternFish);
        }

        [Fact]
        public void LanternFishTest()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadString("TestData\\Lanternfish.txt");

            var lanternfish = new Lanternfish();
            var result = lanternfish.GetNumLanternfish(input, 80);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [InlineData("3,4,3,1,2")]
        public void Lanternfish_ReturnsNumLanternfish_More(string input)
        {
            var numLanternFish = new Lanternfish().GetNumLanternfish(input, 256);

            Assert.Equal(26984457539, numLanternFish);
        }

        [Fact]
        public void LanternFishMoreDaysTest()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadString("TestData\\Lanternfish.txt");

            var lanternfish = new Lanternfish();
            var result = lanternfish.GetNumLanternfish(input, 256);

            _output.WriteLine(result.ToString());
        }
    }
}
