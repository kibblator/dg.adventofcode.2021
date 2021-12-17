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
        public void OperatorPacketDecode(string input, int expecetedVersionSum)
        {
            var packetDecoder = new PacketDecoderV2();
            var versionSum = packetDecoder.GetVersionSum(input);

            Assert.Equal(expecetedVersionSum, versionSum);
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
