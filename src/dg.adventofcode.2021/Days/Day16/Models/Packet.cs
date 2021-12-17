namespace dg.adventofcode._2021.Days.Day16.Models
{
    public class Packet
    {
        private readonly string _binaryString;
        public Packet(string binaryString)
        {
            _binaryString = binaryString;
        }

        public int Version => PacketService.GetVersion(_binaryString);
        public PacketType Type => PacketService.GetPacketType(_binaryString);

        public long Value()
        {
            switch (Type)
            {
                case PacketType.SingleNumber:
                    return PacketService.GetLiteralValue(_binaryString);
                default: 
                    return 0;
            }
        }
    }
}
