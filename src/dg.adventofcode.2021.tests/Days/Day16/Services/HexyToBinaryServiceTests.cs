using dg.adventofcode._2021.Days.Day16;
using dg.adventofcode._2021.Days.Day16.Services;
using Xunit;

namespace dg.adventofcode._2021.tests.Days.Day16.Services
{
    public class HexyToBinaryServiceTests
    {
        [Theory]
        [InlineData("D2FE28", "110100101111111000101000")]
        [InlineData("38006F45291200", "00111000000000000110111101000101001010010001001000000000")]
        [InlineData("EE00D40C823060", "11101110000000001101010000001100100000100011000001100000")]
        public void HexStrings_ReturnCorrectBinary(string hex, string expectedBinary)
        {
            var result = HexToBinaryService.Convert(hex);
            Assert.Equal(expectedBinary, result);
        }
    }
}
