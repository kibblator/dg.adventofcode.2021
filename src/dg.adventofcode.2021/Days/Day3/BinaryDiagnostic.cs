namespace dg.adventofcode._2021.Days.Day3
{
    public class BinaryDiagnostic
    {
        public int Calculate(List<string> numberData)
        {
            var binarySize = numberData.First().Length;
            var finalBits = "";

            for (var i = 0; i < binarySize; i++)
            {
                var mostOccurringBit = CalcMostOccuringBitInPosition(numberData, i);

                finalBits += mostOccurringBit;
            }

            var gammaRate = Convert.ToInt32(finalBits, 2);
            var epsilonRate = Convert.ToInt32(InvertBitString(finalBits), 2);

            return gammaRate * epsilonRate;
        }

        public int CalculateLifeSupportRating(List<string> toList)
        {
            // Calc oxygen 

            // Calc CO2

            //Multiple oxygen by CO2

            return 0;
        }

        private static string CalcMostOccuringBitInPosition(List<string> numberData, int i)
        {
            var zeros = 0;
            var ones = 0;

            foreach (var t in numberData)
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
