namespace dg.adventofcode._2021.Days.Day15
{
    public class Chiton
    {
        public int GetPathRisk(List<string> input)
        {
            var width = input.First().Length;
            var height = input.Count;
            var graph = GetGraph(input, width, height);

            //var numberOfNodes;
            
            return 0;
        }

        private int[][] GetGraph(List<string> input, int width, int height)
        {
            var graph = new int[height][];

            for(var y = 0; y < height; y++)
            {
                var line = input[y];
                for (var x = 0; x < width; x++)
                {
                    graph[y][x] = int.Parse(line[x].ToString());
                }
            }

            return graph;
        }

        public class Node
        {
            public int x { get; set; }
            public int y { get; set; }

            public override string ToString()
            {
                return $"{x}{y}";
            }
        }
    }
}
