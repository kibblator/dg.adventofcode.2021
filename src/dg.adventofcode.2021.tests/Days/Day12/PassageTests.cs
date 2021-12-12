using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day12;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day12
{
    public class PassageTests
    {
        private readonly ITestOutputHelper _output;

        public PassageTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> DataSmall =>
            new object[]
            {
                new string[]
                {
                    "dc-end",
                    "HN-start",
                    "start-kj",
                    "dc-start",
                    "dc-HN",
                    "LN-dc",
                    "HN-end",
                    "kj-sa",
                    "kj-HN",
                    "kj-dc"
                }
            };

        [Theory]
        [MemberData(nameof(DataSmall))]
        public void ExampleTestCase(params string[] input)
        {
            var numPaths = new Passage().GetNumPaths(input.ToList());

            Assert.Equal(19, numPaths);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\Passage.txt");

            var passage = new Passage();
            var result = passage.GetNumPaths(input);

            _output.WriteLine(result.ToString());
        }

        public static IEnumerable<object> DataTiny =>
            new object[]
            {
                new string[]
                {
                    "start-A",
                    "start-b",
                    "A-c",
                    "A-b",
                    "b-d",
                    "A-end",
                    "b-end"
                }
            };

        [Theory]
        [MemberData(nameof(DataTiny))]
        public void ExampleTestCasePart2(params string[] input)
        {
            var numPaths = new Passage(true).GetNumPaths(input.ToList());

            Assert.Equal(36, numPaths);
        }

        [Theory]
        [MemberData(nameof(DataSmall))]
        public void ExampleTestCasePart2Small(params string[] input)
        {
            var numPaths = new Passage(true).GetNumPaths(input.ToList());

            Assert.Equal(103, numPaths);
        }

        [Fact]
        public void Part2Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\Passage.txt");

            var passage = new Passage(true);
            var result = passage.GetNumPaths(input);

            _output.WriteLine(result.ToString());
        }

        public static IEnumerable<object> DataLarge =>
            new object[]
            {
                new string[]
                {
                    "fs-end",
                    "he-DX",
                    "fs-he",
                    "start-DX",
                    "pj-DX",
                    "end-zg",
                    "zg-sl",
                    "zg-pj",
                    "pj-he",
                    "RW-he",
                    "fs-DX",
                    "pj-RW",
                    "zg-RW",
                    "start-pj",
                    "he-WI",
                    "zg-he",
                    "pj-fs",
                    "start-RW"
                }
            };

        [Theory]
        [MemberData(nameof(DataLarge))]
        public void ExampleTestCasePart2Large(params string[] input)
        {
            var numPaths = new Passage(true).GetNumPaths(input.ToList());

            Assert.Equal(3509, numPaths);
        }
    }
}
