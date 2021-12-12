namespace dg.adventofcode._2021.Days.Day12
{
    public class Passage
    {
        private readonly bool _parseSmallTwice;

        public Passage(bool parseSmallTwice = false)
        {
            _parseSmallTwice = parseSmallTwice;
        }

        public int GetNumPaths(List<string> input)
        {
            var possiblePaths = ParsePossiblePaths(input);

            const string currentStep = "start";
            var currentPathList = new List<string>();

            CalculateNextStep(possiblePaths, currentPathList, currentStep, "");
            var paths = string.Join(Environment.NewLine, currentPathList);

            return currentPathList.Count;
        }

        private static Dictionary<string, List<string>> ParsePossiblePaths(List<string> input)
        {
            var possiblePaths = new Dictionary<string, List<string>>();

            foreach (var pathDef in input)
            {
                var startFin = pathDef.Split('-');
                var startPath = startFin[0];
                var endPath = startFin[1];

                BuildLink(possiblePaths, startPath, endPath);
                BuildLink(possiblePaths, endPath, startPath);
            }

            return possiblePaths;
        }

        private static void BuildLink(IDictionary<string, List<string>> possiblePaths, string startPath, string endPath)
        {
            if (endPath != "start")
            {
                if (possiblePaths.ContainsKey(startPath))
                {
                    possiblePaths[startPath].Add(endPath);
                }
                else
                {
                    possiblePaths[startPath] = new List<string> { endPath };
                }
            }
        }

        private void CalculateNextStep(IReadOnlyDictionary<string, List<string>> possiblePaths, IList<string> currentPathList, string currentStep, string stepsString)
        {
            stepsString = string.IsNullOrEmpty(stepsString) ? currentStep : string.Join(',', stepsString, currentStep);
            if (currentStep == "end")
            {
                if (currentPathList.Contains(stepsString) == false)
                {
                    currentPathList.Add(stepsString);
                    return;
                }
            }

            var possibleNextSteps = GetNextSteps(possiblePaths, currentStep);
            foreach (var step in possibleNextSteps)
            {
                if (IsSmallCave(step))
                {
                    if (SmallCaveHasAlreadyBeenUsed(stepsString, step))
                        continue;
                }
                CalculateNextStep(possiblePaths, currentPathList, step, stepsString);
            }
        }

        private bool SmallCaveHasAlreadyBeenUsed(string stepsString, string step)
        {
            var smallCaveOccurences = stepsString.Split(',').Count(s => s == step);

            var smallCaves = stepsString.Split(',').Where(s => char.IsLower(s.First())).ToList();
            var hasUsedMoreThanOneSmallCave = smallCaves.Distinct().Count() < smallCaves.Count();

            var smallCaveUsed = _parseSmallTwice && hasUsedMoreThanOneSmallCave == false ? smallCaveOccurences > 1 : smallCaveOccurences > 0;
            return smallCaveUsed;
        }

        private static bool IsSmallCave(string step)
        {
            return char.IsUpper(step.First()) == false;
        }

        private static IEnumerable<string> GetNextSteps(IReadOnlyDictionary<string, List<string>> possiblePaths, string currentStep)
        {
            try
            {
                var paths = possiblePaths[currentStep];
                return paths;
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}
