using System.Linq;
using dg.adventofcode._2021.crosscutting;
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
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void ExampleTestCase(string input, int versionSum)
        {
            var versionNumbers = new PacketDecoder().GetVersionSum(input.ToList());

            Assert.Equal(40, versionNumbers);
        }

        [Fact]
        public void Part1Test()
        {
            var textFileLoader = new TextFileLoader();
            var input = textFileLoader.LoadStringListFromStrings("TestData\\PacketDecoder.txt");

            var packetDecoder = new PacketDecoder();
            var result = packetDecoder.GetVersionSum(input);

            _output.WriteLine(result.ToString());
        }
    }
}
