namespace dg.adventofcode._2021
{
    public class SonarSweep
    {
        public int CountNumLargerMeasurements(List<int> input)
        {
            var countHigher = 0;
            for (var i = 0; i < input.Count; i++)
            {
                if (i == 0)
                    continue;
                if (input[i] > input[i - 1])
                    countHigher++;
            }

            return countHigher;
        }

        public object CountNumSlidingWindowHigher(List<int> input)
        {
            const int windowSize = 3;

            var countHigher = 0;
            var lastWindow = new List<int>();

            for (var i = 0; i+windowSize <= input.Count; i++)
            {
                var currentWindow = new List<int>();
                for (var j = 0; j < windowSize; j++)
                {
                    currentWindow.Add(input[j + i]);
                }

                if (i == 0)
                {
                    lastWindow = currentWindow;
                    continue;
                }

                if (currentWindow.Sum() > lastWindow.Sum())
                    countHigher++;

                lastWindow = currentWindow;
            }

            return countHigher;
        }
    }
}