using System.Linq;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day2;
using Xunit;
using Xunit.Abstractions;

namespace dg.adventofcode._2021.tests
{
    public class DiveTests
    {
        private readonly ITestOutputHelper _output;

        public DiveTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("forward 5","down 5","forward 8","up 3","down 8","forward 2")]
        public void GetDivePosition_ExampleData_Returns150(params string[] positions)
        {
            //Arrange
            var dive = new Dive();

            //Act
            var position = dive.GetPosition(positions.ToList());

            //Assert
            Assert.Equal(150, position);
        }

        [Fact]
        public void RealTest_1()
        {
            var dive = new Dive();

            var textFileLoader = new TextFileLoader();
            var testData = textFileLoader.LoadStringListFromStrings("TestData\\DiveData.txt");

            var position = dive.GetPosition(testData);
            _output.WriteLine(position.ToString());
        }

        [Theory]
        [InlineData("forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2")]
        public void GetDivePositionAim_ExampleData_Returns900(params string[] positions)
        {
            //Arrange
            var dive = new Dive();

            //Act
            var position = dive.GetPosition(positions.ToList());

            //Assert
            Assert.Equal(900, position);
        }

        [Fact]
        public void RealTest_2()
        {
            var dive = new Dive();

            var textFileLoader = new TextFileLoader();
            var testData = textFileLoader.LoadStringListFromStrings("TestData\\DiveData.txt");

            var position = dive.GetPosition(testData);
            _output.WriteLine(position.ToString());
        }
    }
}
