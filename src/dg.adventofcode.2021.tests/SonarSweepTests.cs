using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests
{
    public class SonarSweepTests
    {
        private readonly ITestOutputHelper _output;
        public SonarSweepTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CountHigher()
        {
            var sonarSweepService = new SonarSweep();
            var textFileLoader = new TextFileLoader();
            var testData = textFileLoader.LoadNumberListFromStrings("TestData\\SonarSweepData.txt");

            var result = sonarSweepService.CountNumLargerMeasurements(testData);
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void CountSlidingWindow()
        {
            var sonarSweepService = new SonarSweep();
            var textFileLoader = new TextFileLoader();
            var testData = textFileLoader.LoadNumberListFromStrings("TestData\\SonarSweepSlidingData.txt");

            var result = sonarSweepService.CountNumSlidingWindowHigher(testData);
            _output.WriteLine(result.ToString());
        }
    }
}