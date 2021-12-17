using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day16;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests.Days.Day16
{
    public class PacketDecoderTests
    {
        private readonly ITestOutputHelper _output;

        public PacketDecoderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("8A004A801A8002F478", 16)]
        [InlineData("620080001611562C8802118E34", 12)]
        [InlineData("38006F45291200", 9)]
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void OperatorPacket_VersionNumberReturnsCorrect(string input, int expecetedVersionSum)
        {
            var packetDecoder = new PacketDecoderV2();
            var versionSum = packetDecoder.GetVersionSum(input);

            Assert.Equal(expecetedVersionSum, versionSum);
        }

        [Theory]
        [InlineData("C200B40A82", 3)]
        [InlineData("04005AC33890", 54)]
        [InlineData("880086C3E88112", 7)]
        [InlineData("CE00C43D881120", 9)]
        [InlineData("D8005AC2A8F0", 1)]
        [InlineData("F600BC2D8F", 0)]
        [InlineData("9C005AC2F8F0", 0)]
        [InlineData("9C0141080250320F1802104A08", 1)]
        public void OperatorPacket_ValueReturnsCorrect(string input, int expectedValue)
        {
            var packetDecoder = new PacketDecoderV2();
            var value = packetDecoder.GetValue(input);

            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadString("TestData\\PacketDecoder.txt");

            var packetDecoder = new PacketDecoderV2();
            var result = packetDecoder.GetVersionSum(input);

            _output.WriteLine(result.ToString());
        }
    }
}
