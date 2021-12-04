namespace dg.adventofcode._2021.Days.Day4
{
    public class GiantSquid
    {
        private const int MatrixSize = 5;

        public int GetWinningBoardScore(List<string> gameInput)
        {
            var callouts = gameInput.First();

            var boards = ParseBoards(gameInput.Skip(2).Where(l => string.IsNullOrEmpty(l) == false).ToList());

            return 0;
        }

        private static List<string[][]> ParseBoards(List<string> boardsInput)
        {
            var boards = new List<string[][]>();
            var board = new string[MatrixSize][];

            for (var line = 0; line < boardsInput.Count; line++)
            {

                board[line % MatrixSize] = boardsInput[line].Split(' ').Where(x => string.IsNullOrEmpty(x) == false)
                    .Select(x => x.Trim()).ToArray();

                if ((line + 1) % MatrixSize == 0)
                {
                    boards.Add(board);
                    board = new string[MatrixSize][];
                }
            }

            return boards;
        }
    }
}
