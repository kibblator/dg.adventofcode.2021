namespace dg.adventofcode._2021.Days.Day10
{
    public class SyntaxScoring
    {
        private readonly List<string> _openingCharacters = new()
        {
            "(",
            "[",
            "{",
            "<",
        };

        private readonly Dictionary<string, string> _charPairs = new()
        {
            {"(",")"} ,
            {"[","]"},
            {"{","}"},
            {"<",">"}
        };

        private readonly Dictionary<string, int> _mismatchScores = new()
        {
            { ")", 3 },
            { "]", 57 },
            { "}", 1197 },
            { ">", 25137 }
        };

        private readonly Dictionary<string, int> _completionScores = new()
        {
            { ")", 1 },
            { "]", 2 },
            { "}", 3 },
            { ">", 4 }
        };

        public int GetErrorScore(List<string> input)
        {
            var mismatchedList = new List<string>();

            foreach (var line in input)
            {
                var mismatched = ValidateInput(line);
                if (string.IsNullOrEmpty(mismatched) == false)
                    mismatchedList.Add(mismatched);
            }

            return mismatchedList.Sum(mm => _mismatchScores[mm]);
        }

        public long GetAutoCompleteScore(List<string> input)
        {
            var incompleteLines = new List<string>();

            foreach (var line in input)
            {
                var mismatched = ValidateInput(line);
                if (string.IsNullOrEmpty(mismatched))
                    incompleteLines.Add(line);
            }

            var scores = new List<long>();
            foreach (var line in incompleteLines)
            {
                var completedInput = CompleteInput(line);
                long score = completedInput.Aggregate<char, long>(0, (current, character) => current * 5 + _completionScores[character.ToString()]);
                scores.Add(score);
            }

            scores = scores.OrderBy(s => s).ToList();

            var index = scores.Count / 2;
            return scores[index];
        }

        public string ValidateInput(string input)
        {
            var charStack = new Stack<string>();
            var mismatched = "";

            var characters = input.Select(i => i.ToString());
            foreach (var character in characters)
            {
                if (IsOpening(character))
                {
                    charStack.Push(character);
                }
                else
                {
                    var mostRecentOpening = charStack.Pop();
                    if (character != _charPairs[mostRecentOpening])
                    {
                        mismatched = character;
                        return mismatched;
                    }
                }
            }
            return mismatched;
        }

        public string CompleteInput(string input)
        {
            var charStack = new Stack<string>();
            var completionString = "";

            var characters = input.Select(i => i.ToString());
            foreach (var character in characters)
            {
                if (IsOpening(character))
                {
                    charStack.Push(character);
                }
                else
                { 
                    charStack.Pop();
                }
            }

            while (charStack.Count > 0)
            {
                completionString += _charPairs[charStack.Pop()];
            }

            return completionString;
        }

        private bool IsOpening(string character)
        {
            return _openingCharacters.Contains(character);
        }
    }
}
