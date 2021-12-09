namespace dg.adventofcode._2021.Days.Day9
{
    public class SmokeBasin
    {
        public int CalcRisk(List<string> input)
        {
            var cave = ParseCave(input);

            var lowPoints = FindLowPoints(cave);

            return lowPoints.Sum(lp => lp + 1);
        }

        private IEnumerable<int> FindLowPoints(int[][] cave)
        {
            var caveLength = cave.First().Length;
            var caveDepth = cave.Length;

            var lowPoints = new List<int>();

            for (var depth = 0; depth < caveDepth; depth++)
            {
                for (var length = 0; length < caveLength; length++)
                {
                    var numToCheck = cave[depth][length];
                    var surroundingValues = GetSurroundingValues(cave, depth, length, caveLength, caveDepth);
                    if (surroundingValues.Any(sv => sv <= numToCheck) == false)
                    {
                        lowPoints.Add(numToCheck);
                    }
                }
            }

            return lowPoints;
        }

        private IEnumerable<int> GetSurroundingValues(int[][] cave, int currentDepth, int currentLength, int caveLength, int caveDepth)
        {
            var surroundingValues = new List<int>();
            if (TouchingRightWall(currentLength, caveLength) == false)
            {
                var rightValue = cave[currentDepth][currentLength + 1];
                surroundingValues.Add(rightValue);
            }

            if (TouchingBottom(currentDepth, caveDepth) == false)
            {
                var bottomValue = cave[currentDepth + 1][currentLength];
                surroundingValues.Add(bottomValue);
            }

            if (TouchingLeftWall(currentLength) == false)
            {
                var leftValue = cave[currentDepth][currentLength - 1];
                surroundingValues.Add(leftValue);
            }

            if (TouchingTop(currentDepth) == false)
            {
                var topValue = cave[currentDepth -1 ][currentLength];
                surroundingValues.Add(topValue);
            }

            return surroundingValues;
        }

        private static bool TouchingTop(int currentDepth)
        {
            return currentDepth == 0;
        }

        private static bool TouchingLeftWall(int currentLength)
        {
            return currentLength == 0;
        }

        private static bool TouchingBottom(int currentDepth, int caveDepth)
        {
            return currentDepth == caveDepth - 1;
        }

        private static bool TouchingRightWall(int currentLength, int caveLength)
        {
            return currentLength == caveLength - 1;
        }

        private static int[][] ParseCave(IReadOnlyList<string> caveInput)
        {
            var maxtrixSize = caveInput.Count;
            var cave = new int[maxtrixSize][];

            for (var y = 0; y < caveInput.Count; y++)
            {
                cave[y] = caveInput[y].Select(s => int.Parse(s.ToString())).ToArray();
            }

            return cave;
        }
    }
}
