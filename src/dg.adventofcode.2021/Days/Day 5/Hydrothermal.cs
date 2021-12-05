namespace dg.adventofcode._2021.Days.Day_5
{
    public class Hydrothermal
    {
        public int GetOverlappingPoints(List<string> input)
        {
            var allCoords = GetAllCoords(input);
            var maxX = allCoords.Max(c => c.x)+1;
            var maxY = allCoords.Max(c => c.y)+1;

            var matrix = new int[maxY][];
            for (var y = 0; y < maxY; y++)
            {
                matrix[y] = new int[maxX];
            }

            foreach (var coord in allCoords)
            {
                matrix[coord.y][coord.x]++;
            }

            var pointsOverTwo = SearchForOverlaps(maxY, maxX, matrix);

            return pointsOverTwo;
        }

        private static int SearchForOverlaps(int maxY, int maxX, int[][] matrix)
        {
            var pointsOverTwo = 0;
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    if (matrix[y][x] > 1)
                        pointsOverTwo++;
                }
            }

            return pointsOverTwo;
        }

        private static IList<Point> GetAllCoords(List<string> input)
        {
            var allCoords = new List<Point>();

            foreach (var line in input)
            {
                var lineParts = line.Split(" -> ");
                var fromLine = lineParts[0];
                var toLine = lineParts[1];

                var fromPoint = GetPoint(fromLine);
                var toPoint = GetPoint(toLine);

                allCoords.AddRange(GetIntermediatePoints(fromPoint, toPoint));
            }

            return allCoords;
        }

        private static IEnumerable<Point> GetIntermediatePoints(Point fromPoint, Point toPoint)
        {
            var points = new List<Point>();

            if (IsHorizontal(fromPoint, toPoint))
            {
                var singlePoints = GenerateGapPoints(fromPoint.x, toPoint.x);
                points.AddRange(singlePoints.Select(point => new Point { x = point, y = fromPoint.y }));
            } 
            else if (IsVertical(fromPoint, toPoint))
            {
                var singlePoints = GenerateGapPoints(fromPoint.y, toPoint.y);
                points.AddRange(singlePoints.Select(point => new Point { x = fromPoint.x, y = point }));
            }

            return points;
        }

        private static List<int> GenerateGapPoints(int fromPoint, int toPoint)
        {
            var diff = toPoint - fromPoint;

            var isPositive = diff >= 0;
            var positiveDifference = isPositive ? diff : diff * -1;

            var singlePoints = new List<int>();
            for (var i = 0; i <= positiveDifference; i++)
            {
                singlePoints.Add(isPositive ? fromPoint + i : fromPoint - i);
            }

            return singlePoints;
        }

        private static bool IsVertical(Point fromPoint, Point toPoint)
        {
            return fromPoint.x == toPoint.x;
        }

        private static bool IsHorizontal(Point fromPoint, Point toPoint)
        {
            return fromPoint.y == toPoint.y;
        }

        private static Point GetPoint(string fromLine)
        {
            var coordParts = fromLine.Split(',');

            return new Point
            {
                x = int.Parse(coordParts[0]),
                y = int.Parse(coordParts[1])
            };
        }

        internal class Point
        {
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}
