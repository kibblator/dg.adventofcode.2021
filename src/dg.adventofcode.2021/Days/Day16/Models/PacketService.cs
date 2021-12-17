﻿namespace dg.adventofcode._2021.Days.Day16.Models;

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
        var stringWithoutHeaders = binaryString.Substring(6, binaryString.Length - 6);

        var end = false;
        var resultingValueString = "";
        while (end == false)
        {
            var value = stringWithoutHeaders.Substring(0, 5);
            if (value[0] == '0')
                end = true;
            resultingValueString += value.Substring(1, 4);
            stringWithoutHeaders = stringWithoutHeaders.Substring(5, stringWithoutHeaders.Length - 5);
        }

        return Convert.ToInt32(resultingValueString, 2);
    }

    public static int GetSubPacketLength(string binaryString)
    {
        var stringWithoutHeaders = binaryString.Substring(6, binaryString.Length - 6);
        var lengthBits = stringWithoutHeaders[0] == '0' ? 15 : 11;

        if (lengthBits == 15)
        {
            return Convert.ToInt32(stringWithoutHeaders.Substring(1, lengthBits),2);
        }

        return 0;
    }

    public static int GetSubPacketCount(string binaryString)
    {
        var stringWithoutHeaders = binaryString.Substring(6, binaryString.Length - 6);
        var lengthBits = stringWithoutHeaders[0] == '0' ? 15 : 11;

        if (lengthBits == 11)
        {
            return Convert.ToInt32(stringWithoutHeaders.Substring(1, lengthBits), 2);
        }

        return 0;
    }

    public static List<Packet> GetPackets(string binaryString)
    {
        return null;
    }
}