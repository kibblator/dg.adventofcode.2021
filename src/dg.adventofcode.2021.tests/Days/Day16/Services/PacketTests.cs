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

        [Theory]
        [InlineData("00111000000000000110111101000101001010010001001000000000", 1, 6, 27)]
        public void OperatorPacket_ReturnsCorrectAttributes(string binaryInput, int expectedVersion, int expectedType, int expectedSubPacketLength)
        {
            var packet = new Packet(binaryInput);

            Assert.Equal(expectedVersion, packet.Version);
            Assert.Equal(expectedType, (int)packet.Type);
            Assert.Equal(expectedSubPacketLength, packet.SubPacketLength);
        }

        [Theory]
        [InlineData("11101110000000001101010000001100100000100011000001100000", 7, 3, 3)]
        public void OperatorPacketType2_ReturnsCorrectAttributes(string binaryInput, int expectedVersion, int expectedType, int expectedNumOfSubPackets)
        {
            var packet = new Packet(binaryInput);

            Assert.Equal(expectedVersion, packet.Version);
            Assert.Equal(expectedType, (int)packet.Type);
            Assert.Equal(expectedNumOfSubPackets, packet.SubPacketCount);
        }

        [Theory]
        [InlineData("110100101111111000101000", 0)]
        public void OperatorPacket_ReturnsCorrectNumSubPackets(string binaryInput, int expectedSubPacketCount)
        {
            var packet = new Packet(binaryInput);

            Assert.Equal(expectedSubPacketCount, packet.SubPackets.Count);
        }
    }
}
