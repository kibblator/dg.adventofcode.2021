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

        public long VersionSum => Version + SubPackets.Sum(sp => sp.VersionSum);

        public List<Packet> SubPackets
        {
            get
            {
                if (_subPackets == null && Type != PacketType.SingleNumber)
                {
                    if (SubPacketLength > 0)
                    {
                        _subPackets =
                            PacketService.GetSubPackets(_binaryString.Substring(22, _binaryString.Length - 22));
                    } else if (SubPacketCount > 0)
                    {
                        _subPackets =
                            PacketService.GetSubPackets(_binaryString.Substring(18, _binaryString.Length - 18));
                    }
                }

                return _subPackets == null ? new List<Packet>() : _subPackets;
            }
        }

        public long Value
        {
            get
            {
                switch (Type)
                {
                    case PacketType.SingleNumber:
                        return PacketService.GetLiteralValue(_binaryString);
                    case PacketType.Sum:
                        return SubPackets.Sum(sp => sp.Value);
                    default:
                        return 0;
                }
            }
        }
    }
}
