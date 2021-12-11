using dg.adventofcode._2021.crosscutting;

namespace dg.adventofcode._2021
{
    public interface IVisualisationClass
    {
        void RunVisualisation(string filePath, Action<string, Dictionary<char, ConsoleColor>> outputToScreen);
    }
}
