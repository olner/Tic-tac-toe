namespace TicTacToe.Engine.Services
{
    public class GameService : IGameService
    {
        public string HwoIsWinner(Dictionary<int, char> field, string xPlayer, string oPlayer)
        {
            string stringField = "";
            for (int i = 0; i < field.Count; i++)
            {
                stringField += field[i];
                if (i % 3 == 0) stringField += " ";
            }

            var winner = GetGameResult(field);

            switch (winner)
            {
                case GameResult.CrossWin:
                    return $"{xPlayer}";
                case GameResult.CircleWin:
                    return $"{oPlayer}";
                case GameResult.Draw:
                    return $"Draw";
            }

            throw new Exception("WhoISWinner exception");
        }

        public bool RowWinSequence(Dictionary<int, char> field, char mark)
        {
            var markCount = 0;
            for (int i = 0; i < field.Count; i++)
            {
                if (i == 0 & field[0] != ' ')
                {
                    markCount++;
                    continue;
                }
                if (i == 0) continue;

                if (field[i - 1] != field[i]) markCount = 1;
                else if (field[i] != ' ') markCount++;

                if (markCount == 3 && field[i] == mark) return true;

                if ((i + 1) % 3 == 0) markCount = 0;
            }

            return false;
        }

        public bool ColumnWinSequence(Dictionary<int, char> field, char mark)
        {
            var markCount = 0;
            var column = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0 && field[i] != ' ')
                    {
                        markCount++;
                        column++;
                        continue;
                    }

                    if (field[i + (3 * column)] != field[i])
                    {
                        markCount = 0;
                    }
                    else if (field[i + (3 * column)] == field[i]) markCount++;
                    column++;
                }

                if (markCount == 3 && field[i] == mark) return true;

                markCount = 0;
                column = 0;
            }

            return false;
        }

        public bool DiagonalWinSequence(Dictionary<int, char> field, char mark)
        {
            if (field[0] == mark && field[4] == mark && field[8] == mark) return true;
            if (field[2] == mark && field[4] == mark && field[6] == mark) return true;
            return false;
        }

        public bool HasWinSequence(Dictionary<int, char> field, char mark)
        {
            return (RowWinSequence(field, mark)
                || ColumnWinSequence(field, mark)
                || DiagonalWinSequence(field, mark));
        }

        public GameResult GetGameResult(Dictionary<int, char> field)
        {
            if (HasWinSequence(field, 'O')) return GameResult.CircleWin;
            else if (HasWinSequence(field, 'X')) return GameResult.CrossWin;
            return GameResult.Draw;
        }
        public enum GameResult { CrossWin, CircleWin, Draw }
    }
}
