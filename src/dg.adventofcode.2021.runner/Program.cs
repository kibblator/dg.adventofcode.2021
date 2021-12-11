using dg.adventofcode._2021;
using dg.adventofcode._2021.crosscutting;
using dg.adventofcode._2021.Days.Day11;

Console.WriteLine("Which day would you like to visualise? Current options are:" + Environment.NewLine);
var visualisationDays = new Dictionary<int, string>
{
    {11, $"{typeof(DumboOctopus).AssemblyQualifiedName}|TestData\\DumboOctopus.txt"}
};

Console.WriteLine($"{string.Join(Environment.NewLine, visualisationDays.Select(d => $"Day '{d.Key}'"))}");
int.TryParse(Console.ReadLine(), out var option);

var fullTypeName = visualisationDays[option].Split('|')[0];
var pathName = visualisationDays[option].Split('|')[1];

var instance = CreateInstance(fullTypeName);
instance.RunVisualisation(pathName, OutputToScreen);

static IVisualisationClass CreateInstance(string fullTypeName)
{
    var objectType = Type.GetType(fullTypeName);
    return (IVisualisationClass)Activator.CreateInstance(objectType);
}

void OutputToScreen(string output, Dictionary<char, ConsoleColor> config)
{
    Console.Clear();
    if (config != null && config.Count > 0)
    {
        HighlightCharacters(output, config);
    }
    else
    {
        Console.Write(output);
    }
}

void HighlightCharacters(string output, Dictionary<char, ConsoleColor> consoleConfig)
{
    var characters = output.Select(o => o).ToList();

    foreach (var character in characters)
    {
        if (consoleConfig.ContainsKey(character))
        {
            Console.ForegroundColor = consoleConfig[character];
            Console.Write(character);
            Console.ResetColor();
        }
        else
        {
            Console.Write(character);
        }
    }
}