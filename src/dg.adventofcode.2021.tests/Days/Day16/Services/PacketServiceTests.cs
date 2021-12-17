using dg.adventofcode._2021.Days.Day16.Models;
using Xunit;

namespace dg.adventofcode._2021.tests.Days.Day16.Services
{
    public class PacketServiceTests
    {
        [Theory]
        [InlineData("100", 4)]
        [InlineData("001", 1)]
        [InlineData("111", 7)]
        public void VersionNumberBits_ReturnsCorrectVersion(string bits, int expectedVersionNumber)
        {
            var version = PacketService.GetVersion(bits);

            Assert.Equal(expectedVersionNumber, version);
        }
    }
}
