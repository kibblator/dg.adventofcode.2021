using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "Initial state: 3,4,3,1,2",
                    "After  1 day:  2,3,2,0,1",
                    "After  2 days: 1,2,1,6,0,8",
                    "After  3 days: 0,1,0,5,6,7,8",
                    "After  4 days: 6,0,6,4,5,6,7,8,8",
                    "After  5 days: 5,6,5,3,4,5,6,7,7,8",
                    "After  6 days: 4,5,4,2,3,4,5,6,6,7",
                    "After  7 days: 3,4,3,1,2,3,4,5,5,6",
                    "After  8 days: 2,3,2,0,1,2,3,4,4,5",
                    "After  9 days: 1,2,1,6,0,1,2,3,3,4,8",
                    "After 10 days: 0,1,0,5,6,0,1,2,2,3,7,8",
                    "After 11 days: 6,0,6,4,5,6,0,1,1,2,6,7,8,8,8",
                    "After 12 days: 5,6,5,3,4,5,6,0,0,1,5,6,7,7,7,8,8",
                    "After 13 days: 4,5,4,2,3,4,5,6,6,0,4,5,6,6,6,7,7,8,8",
                    "After 14 days: 3,4,3,1,2,3,4,5,5,6,3,4,5,5,5,6,6,7,7,8",
                    "After 15 days: 2,3,2,0,1,2,3,4,4,5,2,3,4,4,4,5,5,6,6,7",
                    "After 16 days: 1,2,1,6,0,1,2,3,3,4,1,2,3,3,3,4,4,5,5,6,8",
                    "After 17 days: 0,1,0,5,6,0,1,2,2,3,0,1,2,2,2,3,3,4,4,5,7,8",
                    "After 18 days: 6,0,6,4,5,6,0,1,1,2,6,0,1,1,1,2,2,3,3,4,6,7,8,8,8,8"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void GiantSquid_ReturnsWinningBoardScore(params string[] gameInput)
        {
            var numLanternFish = new Lanternfish().GetNumLanternfish(gameInput.ToList());

            Assert.Equal(5934, numLanternFish);
        }

        [Fact]
        public void GiantSquidTest()
        {
            var textFileLoader = new TextFileLoader();
            var gameInput = textFileLoader.LoadStringListFromStrings("TestData\\Lanternfish.txt");

            var lanternfish = new Lanternfish();
            var result = lanternfish.GetNumLanternfish(gameInput);

            _output.WriteLine(result.ToString());
        }
    }
}
