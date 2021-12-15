using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day13;
using dg.adventofcode._2021.Days.Day14;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day14
{
    public class ExtendedPolyTests
    {
        private readonly ITestOutputHelper _output;

        public ExtendedPolyTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "NNCB",
                    "",
                    "CH -> B",
                    "HH -> N",
                    "CB -> H",
                    "NH -> C",
                    "HB -> C",
                    "HC -> B",
                    "HN -> C",
                    "NN -> C",
                    "BH -> H",
                    "NC -> B",
                    "NB -> B",
                    "BN -> B",
                    "BB -> N",
                    "BC -> B",
                    "CC -> N",
                    "CN -> C"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCase(params string[] input)
        {
            var quantityDiff = new ExtendedPoly().GetQuantityDiff(input.ToList());

            Assert.Equal(1588, quantityDiff);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\ExtendedPoly.txt");

            var extendedPoly = new ExtendedPoly();
            var result = extendedPoly.GetQuantityDiff(input);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ExampleTestCasePart2(params string[] input)
        {
            var quantityDiff = new ExtendedPoly().GetQuantityDiff(input.ToList(), 40);

            Assert.Equal(2188189693529, quantityDiff);
        }
    }
}
