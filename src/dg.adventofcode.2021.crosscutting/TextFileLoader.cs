namespace dg.adventofcode._2021.crosscutting
{
    public class TextFileLoader
    {
        public List<int> LoadNumberListFromStrings(string relativeFilePath)
        {
            var contents = new List<int>();

            var uriString = Path.Combine(Directory.GetCurrentDirectory(), relativeFilePath);
            using var fileStream = new StreamReader(File.OpenRead(uriString));
            while (fileStream.EndOfStream == false)
            {
                contents.Add(int.Parse(fileStream.ReadLine()));
            }

            return contents;
        }

        public List<string> LoadStringListFromStrings(string relativeFilePath)
        {
            var contents = new List<string>();

            var uriString = Path.Combine(Directory.GetCurrentDirectory(), relativeFilePath);
            using var fileStream = new StreamReader(File.OpenRead(uriString));
            while (fileStream.EndOfStream == false)
            {
                contents.Add(fileStream.ReadLine());
            }

            return contents;
        }
    }
}