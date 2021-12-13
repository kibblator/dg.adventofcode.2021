using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day13;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day13
{
    public class TransparentOrigamiTests
    {
        private readonly ITestOutputHelper _output;

        public TransparentOrigamiTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> FoldInstructionsPart1 =>
            new object[]
            {
                new string[]
                {
                    "6,10",
                    "0,14",
                    "9,10",
                    "0,3",
                    "10,4",
                    "4,11",
                    "6,0",
                    "6,12",
                    "4,1",
                    "0,13",
                    "10,12",
                    "3,4",
                    "3,0",
                    "8,4",
                    "1,10",
                    "2,14",
                    "8,10",
                    "9,0",
                    "",
                    "fold along y=7",
                    "fold along x=5"
                }
            };

        [Theory]
        [MemberData(nameof(FoldInstructionsPart1))]
        public void ExampleTestCase(params string[] input)
        {
            var numPaths = new TransparentOrigami().GetNumDots(input.ToList());

            Assert.Equal(17, numPaths);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\TransparentOrigami.txt");

            var transparentOrigami = new TransparentOrigami();
            var result = transparentOrigami.GetNumDots(input);

            _output.WriteLine(result.ToString());
        }
    }
}
