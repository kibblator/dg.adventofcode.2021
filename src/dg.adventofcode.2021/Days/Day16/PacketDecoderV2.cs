using dg.adventofcode._2021.Days.Day16.Models;
using dg.adventofcode._2021.Days.Day16.Services;

namespace dg.adventofcode._2021.Days.Day16
{
    public class PacketDecoderV2
    {
        public long GetVersionSum(string hexInput)
        {
            var binary = HexToBinaryService.Convert(hexInput);
            var packet = new Packet(binary);
            return packet.VersionSum;
        }

        public long GetValue(string hexInput)
        {
            var binary = HexToBinaryService.Convert(hexInput);
            var packet = new Packet(binary);
            return packet.Value;
        }
    }
}
