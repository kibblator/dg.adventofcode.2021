namespace dg.adventofcode._2021.Days.Day14
{
    public class ExtendedPoly
    {
        public long GetQuantityDiff(List<string> input, int iterations = 10)
        {
            var initialString = input.First();
            var polymerRulesString = input.Skip(2).Take(input.Count);

            var polymerRules = ParsePolymerStrings(polymerRulesString);

            for (var count = 0; count < iterations; count++)
            {
                var newString = "";
                for (int i = 0, j = 1; j < initialString.Length; i++, j++)
                {
                    newString += polymerRules[$"{initialString[i]}{initialString[j]}"];
                }

                initialString = $"{newString}{initialString.Last()}";
            }

            var groups = initialString.GroupBy(i => i).ToList();
            var max = groups.Select(g => g.Count()).Max();
            var min = groups.Select(g => g.Count()).Min();

            return max - min;
        }

        private Dictionary<string, string> ParsePolymerStrings(IEnumerable<string> polymerRulesString)
        {
            var rules = polymerRulesString.Select(polymerRule => polymerRule.Split(" -> ")).ToDictionary(
                initalStringParts => initalStringParts[0],
                initalStringParts => initalStringParts[0].Insert(1, initalStringParts[1]).Substring(0, 2));
            return rules;
        }
    }
}
