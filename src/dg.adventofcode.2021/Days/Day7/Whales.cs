namespace dg.adventofcode._2021.Days.Day7
{
    public class Whales
    {
        public int CalculateFuel(string input, bool part2 = false)
        {
            var positions = input.Split(',').Select(int.Parse).ToList();

            var maxPosition = positions.Max();
            var minPosition = positions.Min();
            var fuelCost = CalcFuelCost(positions, minPosition, maxPosition);

            return fuelCost;
        }

        private int CalcFuelCost(List<int> positions, int minPosition, int maxPosition)
        {
            var fuelCost = int.MaxValue;
            while (maxPosition >= minPosition)
            {
                var cost = WorkOutCost(positions, maxPosition);
                if (cost < fuelCost)
                    fuelCost = cost;
                maxPosition--;
            }

            return fuelCost;
        }

        private int WorkOutCost(List<int>positions, int targetPosition)
        {
            return positions.Select(p => p > targetPosition
                ? p - targetPosition
                : targetPosition - p).Sum();
        }
    }
}
