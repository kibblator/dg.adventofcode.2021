namespace dg.adventofcode._2021.Days.Day4
{
    public class GiantSquid
    {
        private const int MatrixSize = 5;

        public int GetWinningBoardScore(List<string> gameInput)
        {
            var boards = GetPlayableBoards(gameInput);
            var callouts = gameInput.First().Split(',');
            var calloutsSoFar = callouts.Take(4).ToList();

            for(var i = 4; i < callouts.Length; i++)
            {
                var numberCalled = callouts[i];
                calloutsSoFar.Add(numberCalled);

                foreach (var board in boards)
                {
                    if (BoardHasWon(board, calloutsSoFar))
                    {
                        return GetBoardScore(board, calloutsSoFar) * int.Parse(numberCalled);
                    }
                }
            }

            return 0;
        }

        public int GetLosingBoardScore(List<string> gameInput)
        {
            var boards = GetPlayableBoards(gameInput);
            var callouts = gameInput.First().Split(',');
            var calloutsSoFar = callouts.Take(4).ToList();

            var boardsWon = new List<int>();

            for (var i = 4; i < callouts.Length; i++)
            {
                var numberCalled = callouts[i];
                calloutsSoFar.Add(numberCalled);

                for (var boardCounter = 0; boardCounter < boards.Count; boardCounter++)
                {
                    if (BoardHasWon(boards[boardCounter], calloutsSoFar))
                    {
                        boardsWon.Add(boardCounter);
                        if (boardsWon.Distinct().Count() == boards.Count)
                        {
                            return GetBoardScore(boards[boardCounter], calloutsSoFar) * int.Parse(numberCalled);
                        }
                    }
                }
            }

            return 0;
        }

        private static bool BoardHasWon(string[][] board, List<string> calloutsSoFar)
        {
            return CheckRowWinner(board, calloutsSoFar) || CheckColumnWinner(board, calloutsSoFar);
        }

        private static List<string[][]> GetPlayableBoards(List<string> gameInput)
        {
            return ParseBoards(gameInput.Skip(2).Where(l => string.IsNullOrEmpty(l) == false).ToList());
        }

        private static bool CheckRowWinner(string[][] board, List<string> calloutsSoFar)
        {
            foreach (var row in board)
            {
                if (calloutsSoFar.Except(row).Count() == calloutsSoFar.Count - MatrixSize)
                    return true;
            }
            return false;
        }

        private static bool CheckColumnWinner(string[][] board, List<string> calloutsSoFar)
        {
            for (var column = 0; column < MatrixSize; column++)
            {
                var columnValues = new List<string>();
                for (var row = 0; row < board.Length; row++)
                {
                    columnValues.Add(board[row][column]);
                }

                if (calloutsSoFar.Except(columnValues).Count() == calloutsSoFar.Count - MatrixSize)
                    return true;
            }
            return false;
        }

        private static int GetBoardScore(string[][] board, List<string> calloutsSoFar)
        {
            var boardValues = new List<string>();
            foreach (var row in board)
            {
                boardValues.AddRange(row);
            }

            return boardValues.Except(calloutsSoFar).Sum(int.Parse);
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
