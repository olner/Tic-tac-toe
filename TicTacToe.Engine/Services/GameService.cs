using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var winner = GetGameResult(CreateFromString(stringField));

            switch (winner)
            {
                case GameResult.CrossWin:
                    return $"{xPlayer} win";
                case GameResult.CircleWin:
                    return $"{oPlayer} win";
                case GameResult.Draw:
                    return $"Draw";
            }

            throw new Exception("WhoISWinner exception");
        }

        public static Mark[,] CreateFromString(string description)
        {
            var charMarkDictionary = new Dictionary<char, Mark>
            {
                ['X'] = Mark.Cross,
                ['O'] = Mark.Circle,
                [' '] = Mark.Empty
            };

            int width = description.IndexOf(' ');
            description = description.Replace(" ", "");
            int height = description.Length / width;

            var field = new Mark[height, width];

            for (int i = 0; i < description.Length; i++)
                field[i / width, i % width] = charMarkDictionary[description[i]];

            return field;
        }

        public static IList<Mark> EnumerateValues(Mark[,] field, Point start, Size delta)
        {
            var values = new List<Mark>();

            int width = field.GetLength(1);
            int height = field.GetLength(0);

            while (start.X >= 0 && start.Y >= 0 && start.X < width && start.Y < height)
            {
                values.Add(field[start.Y, start.X]);
                start = Point.Add(start, delta);
            }

            return values;
        }

        public static bool RowWinSequence(Mark[,] field, Mark mark)
        {
            for (int y = 0; y < field.GetLength(0); y++)
                if (EnumerateValues(field, new Point(0, y), new Size(1, 0)).All(v => v == mark))
                    return true;

            return false;
        }

        public static bool ColumnWinSequence(Mark[,] field, Mark mark)
        {
            for (int x = 0; x < field.GetLength(1); x++)
                if (EnumerateValues(field, new Point(x, 0), new Size(0, 1)).All(v => v == mark))
                    return true;

            return false;
        }

        public static bool DiagonalWinSequence(Mark[,] field, Mark mark)
        {
            return EnumerateValues(field, Point.Empty, new Size(1, 1)).All(v => v == mark) ||
                EnumerateValues(field, new Point(field.GetLength(1) - 1, 0), new Size(-1, 1)).All(v => v == mark);
        }

        public static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            return (RowWinSequence(field, mark)
                || ColumnWinSequence(field, mark)
                || DiagonalWinSequence(field, mark));
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            if (HasWinSequence(field, Mark.Circle)) return GameResult.CircleWin;
            else if (HasWinSequence(field, Mark.Cross)) return GameResult.CrossWin;
            return GameResult.Draw;
        }

        public enum Mark { Cross, Circle, Empty }
        public enum GameResult { CrossWin, CircleWin, Draw }
    }
}
