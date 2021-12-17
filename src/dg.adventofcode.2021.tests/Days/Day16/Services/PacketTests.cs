using dg.adventofcode._2021.Days.Day16.Models;
using Xunit;

namespace dg.adventofcode._2021.tests.Days.Day16.Services
{
    public class PacketTests
    {
        [Theory]
        [InlineData("110100101111111000101000", 6, 4, 2021)]
        [InlineData("11010001010", 6, 4, 10)]
        [InlineData("0101001000100100", 2, 4, 20)]
        [InlineData("01010000001", 2, 4, 1)]
        [InlineData("10010000010", 4, 4, 2)]
        [InlineData("00110000011", 1, 4, 3)]
        public void LiteralPacket_ReturnsCorrectAttributes(string binaryInput, int expectedVersion, int expectedType, long expectedValue)
        {
            var packet = new Packet(binaryInput);

            Assert.Equal(expectedVersion, packet.Version);
            Assert.Equal(expectedType, (int)packet.Type);
            Assert.Equal(expectedValue, packet.Value());
        }
    }
}
