namespace dg.adventofcode._2021.Days.Day6
{
    public class Lanternfish
    {
        private const int DaysUntilFishBreedNewBorn = 8;
        private const int DaysUntilFishBreed = 6;
        private const int FishBirthingAge = 0;

        public int GetNumLanternfish(string lanternFishState, int daysToGet, Action<string> logOutput = null)
        {
            var fishState = lanternFishState.Split(',').Select(int.Parse).OrderBy(f => f);

            //var numFish = ProcessFish(fishState, daysToGet, logOutput);
            var numFish = GetFishBetter(fishState, daysToGet);
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

        private static int GetFishBetter(IEnumerable<int> initialFishes, int days)
        {
            var fishAgeList = SetUpBlankFishCounts();

            foreach (var fish in initialFishes)
            {
                // Tally how many fish exist at each current age
                fishAgeList[fish]++;
            }

            while (FishAreLiving(days))
            {
                var newFishToBeAdded = fishAgeList[FishBirthingAge];

                for (var fishAge = 0; fishAge < DaysUntilFishBreedNewBorn; fishAge++)
                {
                    fishAgeList[fishAge] = fishAgeList[fishAge + 1];
                }

                if (newFishToBeAdded > 0)
                {
                    fishAgeList[DaysUntilFishBreed] += newFishToBeAdded;
                    fishAgeList[DaysUntilFishBreedNewBorn] = newFishToBeAdded;
                }
                else
                {
                    fishAgeList[DaysUntilFishBreedNewBorn] = 0;
                }

                days--;
            }

            return fishAgeList.Sum(fishes => fishes.Value);
        }

        private static bool FishAreLiving(int days)
        {
            return days > 0;
        }

        private static Dictionary<int, int> SetUpBlankFishCounts()
        {
            return Enumerable.Range(0, DaysUntilFishBreedNewBorn + 1).ToDictionary(k => k, _ => 0);
        }
    }
}
