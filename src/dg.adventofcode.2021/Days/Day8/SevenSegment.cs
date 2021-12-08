namespace dg.adventofcode._2021.Days.Day8
{
    public class SevenSegment
    {
        public int CalcOccurrences(List<string> input)
        {
            var numberOccurrences = Enumerable.Range(0, 10).ToDictionary(k => k, _ => 0);

            var outputList = input
                .Select(line => line.Split(" | ")[1])
                .Select(outputValuesSection => outputValuesSection.Split(' ').ToList())
                .SelectMany(outputValues => outputValues);

            foreach (var outputValue in outputList)
            {
                switch (outputValue.Length)
                {
                    case 2:
                        numberOccurrences[1]++;
                        break;
                    case 3:
                        numberOccurrences[7]++;
                        break;
                    case 4:
                        numberOccurrences[4]++;
                        break;
                    case 7:
                        numberOccurrences[8]++;
                        break;
                }
            }

            return numberOccurrences.Sum(o => o.Value);
        }

        public int CalcOutputValue(List<string> input)
        {
            var values = new List<int>();
            foreach (var line in input)
            {
                var lineToCalc = line.Replace(" | ", " ").Split(' ').ToList();
                var codedNumbers = WorkOutCodedNumbers(lineToCalc);

                var orderedStrings = line.Split(" | ")[1].Split(' ').Select(Alphabetise);
                var value = string.Concat(orderedStrings.Select(o => codedNumbers[o].ToString()));
                var intValue = int.Parse(value);
                values.Add(intValue);
            }

            return values.Sum();
        }

        private string Alphabetise(string line)
        {
            return string.Concat(line.OrderBy(c => c));
        }

        private Dictionary<string,int> WorkOutCodedNumbers(List<string> outputValues)
        {
            var string1 = GetStringsForKnownNumber(outputValues, 2);
            var string7 = GetStringsForKnownNumber(outputValues, 3);
            var string4 = GetStringsForKnownNumber(outputValues, 4);
            var string8 = GetStringsForKnownNumber(outputValues, 7);

            var sixLengthNumbers = outputValues.Where(o => o.Length == 6).Select(Alphabetise).Distinct().ToList();
            var fiveLengthNumbers = outputValues.Where(o => o.Length == 5).Select(Alphabetise).Distinct().ToList();

            var string3 = ReturnNumberWithExpectedIntersects(fiveLengthNumbers.Distinct().ToList(), string1.Select(c => c.ToString()).ToList(), 2);
            var string9 = ReturnNumberWithExpectedIntersects(sixLengthNumbers.Distinct().ToList(), string3.Select(c => c.ToString()).ToList(), 5);
            var string0 = ReturnNumberWithExpectedIntersects(sixLengthNumbers.Distinct().Except(new List<string>{string9}).ToList(), string7.Select(c => c.ToString()).ToList(), 3);

            var string6 = sixLengthNumbers.Single(n => n != string0 && n != string9);
            var string5 = ReturnNumberWithExpectedIntersects(
                fiveLengthNumbers.Except(new List<string> { string3 }).Distinct().ToList(),
                string9.Select(c => c.ToString()).ToList(), 5);
            var string2 = fiveLengthNumbers.Distinct().Single(n => n != string5 && n != string3);

            return new Dictionary<string, int>
            {
                {string0, 0},
                {string1, 1},
                {string2, 2},
                {string3, 3},
                {string4, 4},
                {string5, 5},
                {string6, 6},
                {string7, 7},
                {string8, 8},
                {string9, 9}
            };
        }

        private static string ReturnNumberWithExpectedIntersects(List<string> numberList, IList<string> numberListToCheckAgainst, int expectedIntersects)
        {
            string numberStringResult = "";
            foreach (var number in numberList)
            {
                var numberAsCharList = number.Select(c => c.ToString()).ToList();
                if (numberAsCharList.Intersect(numberListToCheckAgainst).Count() == expectedIntersects)
                    numberStringResult = number;
            }

            return numberStringResult;
        }

        private string GetStringsForKnownNumber(List<string> outputValues, int size)
        {
            return outputValues.Where(ov => ov.Length == size).Select(Alphabetise).First();
        }
    }
}
