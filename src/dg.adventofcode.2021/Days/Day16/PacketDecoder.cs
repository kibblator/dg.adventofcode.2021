namespace dg.adventofcode._2021.Days.Day16
{
    public class PacketDecoder
    {
        private Dictionary<string, string> _hexBinaryLookup = new Dictionary<string, string>
        {
            { "0", "0000" },
            { "1", "0001" },
            { "2", "0010" },
            { "3", "0011" },
            { "4", "0100" },
            { "5", "0101" },
            { "6", "0110" },
            { "7", "0111" },
            { "8", "1000" },
            { "9", "1001" },
            { "A", "1010" },
            { "B", "1011" },
            { "C", "1100" },
            { "D", "1101" },
            { "E", "1110" },
            { "F", "1111" }
        };

        public long GetVersionSum(string input)
        {
            long versionSum = 0;
            var decodedPacket = GetDecodedPacket(input, ref versionSum);
            return versionSum;
        }

        public string GetDecodedPacket(string encodedInput, ref long versionSum)
        {
            var binaryString = GetBinaryStringFromHex(encodedInput);

            while (binaryString.Any(b => b != '0'))
            {
                var packetVersion = BinaryToInt(binaryString, 0, 3);
                var packetTypeId = BinaryToInt(binaryString, 3, 3);
                binaryString = binaryString.Substring(6, binaryString.Length - 6);

                versionSum += packetVersion;

                switch (packetTypeId)
                {
                    case 4:
                        binaryString = ParseLiteralValuePackage(binaryString, out var literalValue);
                        break;
                    default:
                        binaryString = ParseOperatorPackage(binaryString);
                        break;
                }
            }

            return "";
        }

        private static long BinaryToInt(string binaryString, int startIndex, int length)
        {
            return Convert.ToInt64(binaryString.Substring(startIndex, length).PadLeft(4, '0'), 2);
        }

        private string ParseOperatorPackage(string binaryString)
        {
            var length = binaryString.Substring(0, 1) == "0" ? 15 : 11;
            var lengthBits = binaryString.Substring(1, length);
            var lengthOfSubPackets = BinaryToInt(lengthBits, 0, lengthBits.Length);

            return binaryString.Substring(length + 1, binaryString.Length - (length + 1));
        }

        public static string ParseLiteralValuePackage(string binaryString, out long literalValue)
        {
            const int bitLength = 1;
            const int chunkSize = 4;

            //binaryString = RemoveZeroPadding(binaryString);

            var lastBit = false;
            var totalString = "";

            while (lastBit == false)
            {
                var bit = ManagedSubstring(binaryString, 0, bitLength);
                lastBit = bit == "0";
                var numPart = ManagedSubstring(binaryString, bitLength, chunkSize);
                totalString += numPart;
                binaryString = binaryString.Substring(chunkSize + bitLength, binaryString.Length - (bitLength + chunkSize));
            }

            literalValue = BinaryToInt(totalString, 0, totalString.Length);

            return binaryString;
        }

        private static string RemoveZeroPadding(string binaryString)
        {
            while (binaryString.Length % 4 != 0)
            {
                binaryString = binaryString.Substring(1, binaryString.Length - 1);
            }

            return binaryString;
        }

        private static string ManagedSubstring(string binaryString, int startIndex, int length)
        {
            try
            {
                binaryString = binaryString.Substring(startIndex, length);
            }
            catch (Exception)
            {
                binaryString = binaryString.PadLeft(length, '0');
            }

            return binaryString;
        }

        private string GetBinaryStringFromHex(string hex)
        {
            return string.Concat(hex.Select(h => _hexBinaryLookup[h.ToString()]));
        }
    }
}
