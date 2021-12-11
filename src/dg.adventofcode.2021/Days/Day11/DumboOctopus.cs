﻿namespace dg.adventofcode._2021.Days.Day11
{
    public class DumboOctopus
    {
        private const int MatrixSize = 10;

        public int GetNumFlashes(List<string> input, int numSteps = 100)
        {
            var octopusGroup = ParseOctopusGroups(input);
            var totalFlashes = 0;

            for (var i = 0; i < numSteps; i++)
            {
                var flashedThisRound = new List<Coord>();
                for (var depth = 0; depth < MatrixSize; depth++)
                {
                    for (var length = 0; length < MatrixSize; length++)
                    {
                        IncrementOctopus(octopusGroup, depth, length, flashedThisRound);
                    }
                }

                totalFlashes += flashedThisRound.Count;
            }

            return totalFlashes;
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
