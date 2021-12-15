namespace dg.adventofcode._2021.Days.Day14
{
    public class ExtendedPoly
    {
        public long GetQuantityDiff(List<string> input, int iterations = 10)
        {
            var initialString = input.First();
            var polymerRulesString = input.Skip(2).Take(input.Count);

            var polymerRules = ParsePolymerStrings(polymerRulesString);

            var pairOccurrences = GetInitialPairs(initialString);

            for (var count = 0; count < iterations; count++)
            {
                pairOccurrences = GetPairOccurrences(pairOccurrences, polymerRules);
                //    var newString = "";
                //    for (int i = 0, j = 1; j < initialString.Length; i++, j++)
                //    {
                //        newString += polymerRules[$"{initialString[i]}{initialString[j]}"];
                //    }

                //    initialString = $"{newString}{initialString.Last()}";
            }

            //var groups = initialString.GroupBy(i => i).ToList();
            var letterCounts = new Dictionary<string, long>();
            foreach (var currentPairOccurrence in pairOccurrences)
            {
                var letters = (FirstLetter: currentPairOccurrence.Key.Substring(0, 1),
                    SecondLetter: currentPairOccurrence.Key.Substring(1, 1));
                IncrementLetterCount(letterCounts, letters.FirstLetter, currentPairOccurrence);
                IncrementLetterCount(letterCounts, letters.SecondLetter, currentPairOccurrence);
            }
            
            var max = letterCounts.Max(l => l.Value);
            var min = letterCounts.Min(l => l.Value);

            var diff = (max - min) / 2;

            return diff + 1;
        }

        private static void IncrementLetterCount(Dictionary<string, long> letterCounts, string letter,
            KeyValuePair<string, long> currentPairOccurrence)
        {
            if (letterCounts.ContainsKey(letter) == false)
            {
                letterCounts[letter] = currentPairOccurrence.Value;
            }
            else
            {
                letterCounts[letter] += currentPairOccurrence.Value;
            }
        }

        private static Dictionary<string, long> GetInitialPairs(string initialString)
        {
            var pairOccurrences = new Dictionary<string, long>();
            for(int i = 0, j = 1; j < initialString.Length; i++, j++)
            {
                var pair = $"{initialString[i]}{initialString[j]}";
                IncrementPair(pairOccurrences, pair, 1);
            }

            return pairOccurrences;
        }

        private static void IncrementPair(Dictionary<string, long> pairOccurrences, string pairKey, long incrementBy)
        {
            if (pairOccurrences.ContainsKey(pairKey) == false)
                pairOccurrences[pairKey] = 0;
            pairOccurrences[pairKey] += incrementBy;
        }

        private Dictionary<string, long> GetPairOccurrences(Dictionary<string, long> currentPairOccurrences,
            Dictionary<string, string> polymerRules)
        {
            // Copy dictionary so I'm not adding to it whilst looping it
            var pairOccurrences = new Dictionary<string, long>(currentPairOccurrences);

            foreach (var (pair, timesPairOccurs) in currentPairOccurrences)
            {
                if (timesPairOccurs == 0)
                    continue;

                var (firstPair, secondPair) = GetPairs(polymerRules, pair);

                IncrementPair(pairOccurrences, firstPair, timesPairOccurs);
                IncrementPair(pairOccurrences, secondPair, timesPairOccurs);

                pairOccurrences[pair] -= timesPairOccurs;
            }

            return pairOccurrences;
        }

        private static (string FirstPair, string SecondPair) GetPairs(Dictionary<string, string> polymerRules, string pair)
        {
            var threeCharString = polymerRules[pair];
            var pairs = (FirstPair: threeCharString.Substring(0, 2), SecondPair: threeCharString.Substring(1, 2));
            return pairs;
        }

        private Dictionary<string, string> ParsePolymerStrings(IEnumerable<string> polymerRulesString)
        {
            var rules = polymerRulesString.Select(polymerRule => polymerRule.Split(" -> ")).ToDictionary(
                initalStringParts => initalStringParts[0],
                initalStringParts => initalStringParts[0].Insert(1, initalStringParts[1]));
            return rules;
        }
    }
}
