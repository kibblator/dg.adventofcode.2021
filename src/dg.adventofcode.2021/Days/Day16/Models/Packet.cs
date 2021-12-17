namespace dg.adventofcode._2021.Days.Day16.Models
{
    public class Packet
    {
        private readonly string _binaryString;
        private List<Packet> _subPackets;

        public Packet(string binaryString)
        {
            _binaryString = binaryString;
        }

        public int Version => PacketService.GetVersion(_binaryString);
        public PacketType Type => PacketService.GetPacketType(_binaryString);

        public int SubPacketLength => Type == PacketType.SingleNumber
            ? 0
            : PacketService.GetSubPacketLength(_binaryString);

        public int SubPacketCount => Type == PacketType.SingleNumber
            ? 0
            : PacketService.GetSubPacketCount(_binaryString);

        public List<Packet> SubPackets
        {
            get
            {
                if (_subPackets == null && Type != PacketType.SingleNumber)
                {
                    _subPackets = PacketService.GetPackets(_binaryString);
                }

                return new List<Packet>();
            }
        }

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
