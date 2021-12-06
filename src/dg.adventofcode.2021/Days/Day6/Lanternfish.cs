namespace dg.adventofcode._2021.Days.Day6
{
    public class Lanternfish
    {
        private const int DaysUntilFishBreedNewBorn = 8;
        private const int DaysUntilFishBreed = 6;
        private const int FishBirthingAge = 0;

        public long GetNumLanternfish(string lanternFishState, int daysToGet, Action<string> logOutput = null)
        {
            var fishState = lanternFishState.Split(',').Select(int.Parse).OrderBy(f => f);

            var numFish = GetFishBetter(fishState, daysToGet);
            return numFish;
        }

        private static long GetFishBetter(IEnumerable<int> initialFishes, int days)
        {
            var fishAgeList = SetUpBlankFishCounts();

            TallyCurrentFishAges(initialFishes, fishAgeList);

            while (FishAreLiving(days))
            {
                var newFishToBeAdded = GetFishAboutToPop(fishAgeList);
                AgeCurrentFish(fishAgeList);

                GetFishPregnantAgain(fishAgeList, newFishToBeAdded);
                GiveBirthToBabyFish(fishAgeList, newFishToBeAdded);

                days--;
            }

            return GetCurrentFishCount(fishAgeList);
        }

        private static void AgeCurrentFish(IDictionary<int, long> fishAgeList)
        {
            for (var fishAge = 0; fishAge < DaysUntilFishBreedNewBorn; fishAge++)
            {
                fishAgeList[fishAge] = fishAgeList[fishAge + 1];
            }
        }

        private static void TallyCurrentFishAges(IEnumerable<int> initialFishes, IDictionary<int, long> fishAgeList)
        {
            foreach (var fish in initialFishes)
            {
                fishAgeList[fish]++;
            }
        }

        private static long GetCurrentFishCount(Dictionary<int, long> fishAgeList)
        {
            return fishAgeList.Sum(fishes => fishes.Value);
        }

        private static void GiveBirthToBabyFish(IDictionary<int, long> fishAgeList, long newFishToBeAdded)
        {
            fishAgeList[DaysUntilFishBreedNewBorn] = newFishToBeAdded;
        }

        private static void GetFishPregnantAgain(IDictionary<int, long> fishAgeList, long newFishToBeAdded)
        {
            fishAgeList[DaysUntilFishBreed] += newFishToBeAdded;
        }

        private static void AgeCurrentFish(IDictionary<int, long> fishAgeList, int fishAge)
        {
            fishAgeList[fishAge] = fishAgeList[fishAge + 1];
        }

        private static long GetFishAboutToPop(IReadOnlyDictionary<int, long> fishAgeList)
        {
            return fishAgeList[FishBirthingAge];
        }

        private static bool FishAreLiving(int days)
        {
            return days > 0;
        }

        private static Dictionary<int, long> SetUpBlankFishCounts()
        {
            return Enumerable.Range(0, DaysUntilFishBreedNewBorn + 1).ToDictionary(k => k, _ => (long)0);
        }
    }
}
