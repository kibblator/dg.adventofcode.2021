namespace dg.adventofcode._2021.Days.Day6
{
    public class Lanternfish
    {
        public int GetNumLanternfish(string lanternFishState, int daysToGet, Action<string> logOutput = null)
        {
            var fishState = lanternFishState.Split(',').Select(int.Parse).OrderBy(f => f);

            var numFish = ProcessFish(fishState, daysToGet, logOutput);
            return numFish;
        }

        private static int ProcessFish(IEnumerable<int> fishState, int daysRemaining, Action<string> logOutput)
        {
            var totalDays = daysRemaining;

            while (true)
            {
                if (daysRemaining == 0) return fishState.Count();

                var newToAdd = 0;
                var newFishState = new List<int>();

                foreach (var fish in fishState)
                {
                    var newFish = fish - 1;
                    if (newFish < 0)
                    {
                        newToAdd++;
                        newFish = 6;
                    }

                    newFishState.Add(newFish);
                }

                while (newToAdd > 0)
                {
                    newFishState.Add(8);
                    newToAdd--;
                }

                fishState = newFishState;
                daysRemaining -= 1;

                if (logOutput != null)
                {
                    logOutput(
                        $"Fish Day {totalDays - daysRemaining}: {string.Join(",", newFishState.Select(f => f.ToString()))}");
                }
            }
        }
    }
}
