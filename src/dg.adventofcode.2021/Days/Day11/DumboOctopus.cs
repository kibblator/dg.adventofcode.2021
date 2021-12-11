using System.Text;
using dg.adventofcode._2021.crosscutting;

namespace dg.adventofcode._2021.Days.Day11
{
    public class DumboOctopus : IVisualisationClass
    {
        private const int MatrixSize = 10;
        private Action<string, Dictionary<char, ConsoleColor>> _outputAction;

        public void RunVisualisation(string filePath, Action<string, Dictionary<char, ConsoleColor>> outputToScreen)
        {
            _outputAction = outputToScreen;
            var input = new TextFileLoader().LoadStringListFromStrings(filePath);
            var octopusGroup = ParseOctopusGroups(input);
            RunSimulation(100, octopusGroup);
        }

        public int GetNumFlashes(List<string> input, int numSteps = 100, bool breakWhenSimul = false)
        {
            var octopusGroup = ParseOctopusGroups(input);
            var totalFlashes = 0;

            totalFlashes = RunSimulation(numSteps, octopusGroup);

            return totalFlashes;
        }

        public int GetSimultaneousFlashStep(List<string> input)
        {
            var octopusGroup = ParseOctopusGroups(input);
            return RunSimulation(1000, octopusGroup, true);
        }

        private int RunSimulation(int numSteps, int[][] octopusGroup, bool returnFlashPointStep = false)
        {
            var totalFlashes = 0;
            for (var i = 0; i < numSteps; i++)
            {
                if (_outputAction != null)
                {
                    _outputAction(GetStringOutput(octopusGroup), new Dictionary<char, ConsoleColor>{{'0', ConsoleColor.Red}});
                    Thread.Sleep(500);
                }
                var flashedThisRound = new List<Coord>();
                for (var depth = 0; depth < MatrixSize; depth++)
                {
                    for (var length = 0; length < MatrixSize; length++)
                    {
                        IncrementOctopus(octopusGroup, depth, length, flashedThisRound);
                    }
                }

                totalFlashes += flashedThisRound.Count;
                if (returnFlashPointStep && flashedThisRound.Count == 100)
                    return i + 1;
            }

            return totalFlashes;
        }

        private static string GetStringOutput(int[][] octopusGroup)
        {
            var stringBuilder = new StringBuilder();
            for (var depth = 0; depth < MatrixSize; depth++)
            {
                var lineString = "";
                for (var length = 0; length < MatrixSize; length++)
                {
                    lineString += $"{octopusGroup[depth][length]} ";
                }

                stringBuilder.AppendLine(lineString);
            }

            return stringBuilder.ToString();
        }

        private void IncrementOctopus(int[][] octopusGroup, int depth, int length, List<Coord> flashedThisRound)
        {
            try
            {
                if (flashedThisRound.Any(f => f.x == length && f.y == depth) == false)
                    octopusGroup[depth][length]++;

                if (Flashed(octopusGroup, depth, length))
                {
                    ResetEnergy(octopusGroup, depth, length);

                    if (flashedThisRound.Any(f => f.x == length && f.y == depth) == false)
                    {
                        flashedThisRound.Add(new Coord { x = length, y = depth });

                        IncrementOctopus(octopusGroup, depth - 1, length - 1, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth - 1, length, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth - 1, length + 1, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth, length - 1, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth, length + 1, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth + 1, length - 1, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth + 1, length, flashedThisRound);
                        IncrementOctopus(octopusGroup, depth + 1, length + 1, flashedThisRound);
                    }
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        private static void ResetEnergy(int[][] octopusGroup, int depth, int length)
        {
            octopusGroup[depth][length] = 0;
        }

        private static bool Flashed(int[][] octopusGroup, int depth, int length)
        {
            return octopusGroup[depth][length] > 9;
        }

        private static int[][] ParseOctopusGroups(IReadOnlyList<string> octopusInput)
        {
            var maxtrixSize = octopusInput.Count;
            var group = new int[maxtrixSize][];

            for (var y = 0; y < octopusInput.Count; y++)
            {
                group[y] = octopusInput[y].Select(s => int.Parse(s.ToString())).ToArray();
            }

            return group;
        }

        private class Coord
        {
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}
