namespace TicTacToe.Engine.Services
{
    public class RivalService : IRivalService
    {
        public Dictionary<int, char> MakeMove(Dictionary<int, char> fields)
        {
            var emptyFields = CountEmptyFields(fields);
            if (emptyFields == 0) return fields;

            if(emptyFields == 8) return FirstTurn(fields);

            return Turn(fields);
        }

        public int CountEmptyFields(Dictionary<int, char> fields)
        {
            if (fields is null) throw new ArgumentNullException(nameof(fields));

            var emptyFields = fields.Where(x => x.Value == ' ').Count();

            return emptyFields;
        }

        private Dictionary<int, char> FirstTurn(Dictionary<int, char> fields)
        {
            var moves = new Dictionary<int, int>()
            {
                { 0, 0 },
                { 1, 2 },
                { 2, 6 },
                { 3, 8 }

            };

            if (fields[4] == ' ')
            {
                fields[4] = 'O';
            }
            else
            {
                var move = new Random().Next(0, 4);
                fields[moves[move]] = 'O';
            }

            return fields;
        }

        private Dictionary<int, char> Turn(Dictionary<int, char> field)
        {
            var rowTurn = RowWinSequence(field);
            var columnTurn = ColumnWinSequence(field);
            if(rowTurn != -1)
            {
                field[rowTurn] = 'O';
                return field;
            }
            if(columnTurn != -1)
            {
                field[columnTurn] = 'O';
                return field;
            }

            var emptyFields = CountEmptyFields(field);
            var move = new Random().Next(1, emptyFields);

            if (emptyFields == 0) return field;

            var i = 0;
            int counter = 0;
            while (counter < move)
            {
                if (field[i] == ' ') counter++;
                if (counter == move) field[i] = 'O';
                i++;
            }


            return field;
        }
        public int RowWinSequence(Dictionary<int, char> field)
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

                if (i + 1 < field.Count)
                    if (markCount == 2 && field[i + 1] == ' ' && ((i + 1) % 3 != 0)) return i + 1;

                if ((i + 1) % 3 == 0) markCount = 0;
            }
            return -1;
        }
        public int ColumnWinSequence(Dictionary<int, char> field)
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

                    if (i + 1 < field.Count)
                        if (markCount == 2 && field[i + (3 * column)] == ' ' && ((i + 1) % 3 != 0)) return i + (3 * column);

                }

                markCount = 0;
                column = 0;
            }

            return -1;
        }
        public bool DiagonalWinSequence(Dictionary<int, char> field, char mark)
        {
            if (field[0] == mark && field[4] == mark && field[8] == mark) return true;
            if (field[2] == mark && field[4] == mark && field[6] == mark) return true;
            return false;
        }
    }
}
