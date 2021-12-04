namespace dg.adventofcode._2021.Days.Day3
{
    public class BinaryDiagnostic
    {
        public int Calculate(List<string> data)
        {
            var binarySize = data.First().Length;
            var finalBits = "";

            for (var i = 0; i < binarySize; i++)
            {
                var mostOccurringBit = CalcMostOccuringBitInPosition(data, i);

                finalBits += mostOccurringBit;
            }

            var gammaRate = Convert.ToInt32(finalBits, 2);
            var epsilonRate = Convert.ToInt32(InvertBitString(finalBits), 2);

            return gammaRate * epsilonRate;
        }

        public int CalculateLifeSupportRating(List<string> data)
        {
            // Calc oxygen 
            var oxygenList = FilterLifeSupportList(data, data.First().Length, 0, "oxygen");

            // Calc CO2
            var co2List = FilterLifeSupportList(data, data.First().Length, 0, "co2");

            // Multiple oxygen by CO2
            var oxygenRating = Convert.ToInt32(oxygenList.First(), 2);
            var co2Rating = Convert.ToInt32(co2List.First(), 2);

            return oxygenRating * co2Rating;
        }

        public List<string> FilterLifeSupportList(List<string> data, int numberOfBits, int position, string type)
        {
            if (position == numberOfBits || data.Count == 1)
                return data;

            var mostOccuringBit = CalcMostOccuringBitInPosition(data, position);
            List<string> newData;

            if (type == "oxygen")
            {
                newData = data.Where(d => d[position].ToString() == mostOccuringBit).ToList();
                
            }
            else
            {
                newData = data.Where(d => d[position].ToString() != mostOccuringBit).ToList();
            }
            return FilterLifeSupportList(newData, numberOfBits, position + 1, type);
        }

        private static string CalcMostOccuringBitInPosition(List<string> data, int i)
        {
            var zeros = 0;
            var ones = 0;

            foreach (var t in data)
            {
                if (t[i].ToString() == "1")
                {
                    ones++;
                }
                else
                {
                    zeros++;
                }
            }

            if (zeros > ones)
            {
                return "0";
            }

            return "1";
        }

        private static string InvertBitString(string finalBits)
        {
            var newBits = "";
            foreach (var finalBit in finalBits)
            {
                newBits += finalBit.ToString() == "1" ? "0" : "1";
            }

            return newBits;
        }
    }
}
