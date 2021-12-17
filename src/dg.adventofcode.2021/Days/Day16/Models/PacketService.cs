namespace dg.adventofcode._2021.Days.Day16.Models;

public class PacketService
{
    public static int GetVersion(string binaryString)
    {
        var versionBits = $"0{binaryString.Substring(0, 3)}";
        return Convert.ToInt32(versionBits, 2);
    }

    public static PacketType GetPacketType(string binaryString)
    {
        var typeBits = $"0{binaryString.Substring(3, 3)}";
        return (PacketType)Convert.ToInt32(typeBits, 2);
    }

    public static long GetLiteralValue(string binaryString)
    {
        var valueBits = binaryString.Substring(6, binaryString.Length - 6);

        var end = false;
        var resultingValueString = "";
        while (end == false)
        {
            var value = valueBits.Substring(0, 5);
            if (value[0] == '0')
                end = true;
            resultingValueString += value.Substring(1, 4);
            valueBits = valueBits.Substring(5, valueBits.Length - 5);
        }

        return Convert.ToInt32(resultingValueString, 2);
    }
}