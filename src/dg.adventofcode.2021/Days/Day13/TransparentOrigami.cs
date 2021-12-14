namespace dg.adventofcode._2021.Days.Day13
{
    public class TransparentOrigami
    {
        private Action<string> _outputMethod;

        public int GetNumDots(List<string> input, Action<string> outputMethod, bool isPart1 = true)
        {
            _outputMethod = outputMethod;
            var inputParts = GetInputParts(input);

            var instructions = ParseFoldInstructions(inputParts.FoldInstructions);
            var coords = ParseCoords(inputParts.Coords).ToList();
            var matrix = GetMatrix(GetYSize(instructions.First(i => i.Axis == "y")), GetXSize(instructions.First(i => i.Axis == "x")));
            matrix = GetMatrixOfCoords(matrix, coords, GetYSize(instructions.First(i => i.Axis == "y")), GetXSize(instructions.First(i => i.Axis == "x")));

            if (isPart1)
            {
                var foldInstruction = instructions.First();
                coords = GetFoldedCoords(foldInstruction, coords);
                matrix = GetMatrixOfCoords(matrix, coords, GetHeightFromNextInstruction(foldInstruction, matrix),
                    GetWidthFromNextInstruction(foldInstruction, matrix));
                OutputCoords(matrix);
            }
            else
            {
                var count = 0;
                foreach (var foldInstruction in instructions)
                {
                    coords = GetFoldedCoords(foldInstruction, coords);
                    matrix = GetMatrixOfCoords(matrix, coords, GetHeightFromNextInstruction(foldInstruction, matrix),
                        GetWidthFromNextInstruction(foldInstruction, matrix));
                    
                    if (count > 8)
                        OutputCoords(matrix);
                    count++;
                }
            }

            return coords.Count;
        }

        private static int GetXSize(FoldInstruction instruction)
        {
            return instruction.Point * 2;
        }

        private static int GetYSize(FoldInstruction instruction)
        {
            return instruction.Point * 2;
        }

        private static int GetWidthFromNextInstruction(FoldInstruction foldInstruction, string[][] matrix)
        {
            return foldInstruction.Axis == "x" ? foldInstruction.Point : matrix.First().Length;
        }

        private static int GetHeightFromNextInstruction(FoldInstruction foldInstruction, string[][] matrix)
        {
            return foldInstruction.Axis == "y" ? foldInstruction.Point : matrix.Length;
        }

        private void OutputCoords(IEnumerable<IEnumerable<string>> matrix)
        {
            using (var fileStream = new StreamWriter(File.OpenWrite("TestData\\TransparentOrigami_Results.txt")))
            {
                for (var line = 0; line < matrix.Count(); line++)
                {
                    fileStream.WriteLine(string.Join("", matrix.ToList()[line]));
                    _outputMethod(string.Join("", matrix.ToList()[line]));
                }
                _outputMethod("");
                _outputMethod("");
                fileStream.WriteLine("");
                fileStream.WriteLine("");
            }
        }
        private string[][] GetMatrix(int height, int width)
        {
            var matrix = new string[height][];
            for (var y = 0; y < height; y++)
            {
                matrix[y] = new string[width];
                for (var x = 0; x < width; x++)
                {
                    matrix[y][x] = ".";
                }
            }

            return matrix;
        }

        private string[][] GetMatrixOfCoords(string[][] matrix, List<Coord> coords, int height, int width)
        {
            matrix = matrix.Take(height).ToArray();
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    matrix[y] = matrix[y].Take(width).ToArray();
                    matrix[y][x] = coords.Any(c => c.x == x && c.y == y) ? "#" : ".";
                }
            }

            return matrix;
        }

        public static List<Coord> GetFoldedCoords(FoldInstruction fi, List<Coord> coords)
        {
            var coordinateList = coords.ToList();

            var listA = coordinateList.Where(c => fi.Axis == "x" ? c.x < fi.Point : c.y < fi.Point).ToList();
            var listB = coordinateList.Where(c => fi.Axis == "x" ? c.x > fi.Point : c.y > fi.Point).ToList();

            if (fi.Axis == "x")
            {
                var newX = listB.Select(coord => GetValueAfterFold(fi.Point, coord.x));
                var newXCoords = newX.Select((t, i) => new Coord { x = t, y = listB[i].y }).ToList();
                listA.AddRange(newXCoords.Where(newXCoord => listA.Any(l => l.x == newXCoord.x && l.y == newXCoord.y) == false));
            }
            else
            {
                var newY = listB.Select(coord => GetValueAfterFold(fi.Point, coord.y));
                var newYCoords = newY.Select((t, i) => new Coord { y = t, x = listB[i].x }).ToList();
                listA.AddRange(newYCoords.Where(newYCoord => listA.Any(l => l.x == newYCoord.x && l.y == newYCoord.y) == false));
            }

            coordinateList = listA;

            return coordinateList;
        }

        private static int GetValueAfterFold(int foldPoint, int x)
        {
            var diff = x - foldPoint;
            return foldPoint - diff;
        }

        private static IEnumerable<Coord> ParseCoords(IEnumerable<string> inputPartsCoords)
        {
            var listCoords = inputPartsCoords.Select(coord => new Coord
                { x = int.Parse(coord.Split(',')[0]), y = int.Parse(coord.Split(',')[1]) }).ToList();

            return listCoords;
        }

        private static InputParts GetInputParts(List<string> input)
        {
            var coords = new List<string>();
            var foldInstructions = new List<string>();

            var isCoords = true;
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    isCoords = false;
                    continue;
                }

                if (isCoords)
                    coords.Add(line);
                else
                    foldInstructions.Add(line);
            }

            return new InputParts(coords, foldInstructions);
        }

        private static IEnumerable<FoldInstruction> ParseFoldInstructions(List<string> foldInstructions)
        {
            return foldInstructions.Select(line => line.Replace("fold along ", ""))
                .Select(instruction => instruction.Split('='))
                .Select(instructionParts => new FoldInstruction(instructionParts[0], int.Parse(instructionParts[1]))).ToList();
        }
    }

    public class FoldInstruction
    {
        public FoldInstruction(string axis, int point)
        {
            Axis = axis;
            Point = point;
        }

        public string Axis { get; }
        public int Point { get; }
    }

    internal class InputParts
    {
        public InputParts(List<string> coords, List<string> foldInstructions)
        {
            Coords = coords;
            FoldInstructions = foldInstructions;
        }

        public List<string> Coords { get; }
        public List<string> FoldInstructions { get; }
    }

    public class Coord
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
