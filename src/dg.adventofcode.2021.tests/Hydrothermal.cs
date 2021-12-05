using System.Collections.Generic;
using System.Linq;
using dg.adventofcode._2021.Days.Day_5;
using dg.adventofcode._2021.Days.Day4;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests
{
    public class HydrothermalTests
    {
        private readonly ITestOutputHelper _output;

        public HydrothermalTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object> Data =>
            new object[]
            {
                new string[]
                {
                    "0,9 -> 5,9",
                    "8,0 -> 0,8",
                    "9,4 -> 3,4",
                    "2,2 -> 2,1",
                    "7,0 -> 7,4",
                    "6,4 -> 2,0",
                    "0,9 -> 2,9",
                    "3,4 -> 1,4",
                    "0,0 -> 8,8",
                    "5,5 -> 8,2"
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Hydrothermal_ReturnOverlappingPoints(params string[] input)
        {
            var overlappingPoints = new Hydrothermal().GetOverlappingPoints(input.ToList());

            Assert.Equal(5, overlappingPoints);
        }
    }
}
