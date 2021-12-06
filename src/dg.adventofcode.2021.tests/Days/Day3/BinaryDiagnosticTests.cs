using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day3;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day3
{
    public class BinaryDiagnosticTests
    {
        private readonly ITestOutputHelper _output;

        public BinaryDiagnosticTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010")]
        public void CalcPowerConsumption(params string[] numberData)
        {
            var binaryDiag = new BinaryDiagnostic();

            var result = binaryDiag.Calculate(numberData.ToList());

            Assert.Equal(198, result);
        }

        [Fact]
        public void ActualTest()
        {
            var binaryDiag = new BinaryDiagnostic();

            var textFileLoader = new TextFileLoader();
            var testData = textFileLoader.LoadStringListFromStrings("TestData\\BinaryDiagnosticData.txt");
            var result = binaryDiag.Calculate(testData);

            _output.WriteLine(result.ToString());
        }

        [Theory]
        [InlineData("00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010")]
        public void CalcLifeSupportRating(params string[] numberData)
        {
            var binaryDiag = new BinaryDiagnostic();

            var result = binaryDiag.CalculateLifeSupportRating(numberData.ToList());

            Assert.Equal(230, result);
        }

        [Fact]
        public void ActualLieSupportTest()
        {
            var binaryDiag = new BinaryDiagnostic();

            var textFileLoader = new TextFileLoader();
            var testData = textFileLoader.LoadStringListFromStrings("TestData\\BinaryDiagnosticData.txt");
            var result = binaryDiag.CalculateLifeSupportRating(testData);

            _output.WriteLine(result.ToString());
        }
    }
}
