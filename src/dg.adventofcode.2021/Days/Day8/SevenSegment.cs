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
    }
}
