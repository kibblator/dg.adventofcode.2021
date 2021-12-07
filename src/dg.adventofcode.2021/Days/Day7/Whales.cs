namespace dg.adventofcode._2021.Days.Day7
{
    public class Whales
    {
        public int CalculateFuel(string input, bool isPartTwo = false)
        {
            var positions = input.Split(',').Select(int.Parse).ToList();

            var maxPosition = positions.Max();
            var minPosition = positions.Min();
            var fuelCost = CalcFuelCost(positions, minPosition, maxPosition, isPartTwo);

            return fuelCost;
        }

        private int CalcFuelCost(List<int> positions, int minPosition, int maxPosition, bool isPartTwo)
        {
            var fuelCost = int.MaxValue;
            while (maxPosition >= minPosition)
            {
                var cost = WorkOutCost(positions, maxPosition, isPartTwo);
                if (cost < fuelCost)
                    fuelCost = cost;
                maxPosition--;
            }

            return fuelCost;
        }

        private int WorkOutCost(List<int>positions, int targetPosition, bool isPartTwo)
        {
            return isPartTwo ?
                positions.Select(p => p > targetPosition
                    ? ModifiedCost(p - targetPosition)
                    : ModifiedCost(targetPosition - p)).Sum()
                : positions.Select(p => p > targetPosition
                ? p - targetPosition
                : targetPosition - p).Sum();
        }

        private int ModifiedCost(int stepsTaken)
        {
            return Enumerable.Range(1, stepsTaken).Sum();
        }
    }
}
