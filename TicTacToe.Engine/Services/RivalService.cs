using System.Data.Common;

namespace TicTacToe.Engine.Services
{
    public class RivalService : IRivalService
    {
        public Dictionary<int, char> MakeMove(Dictionary<int, char> fields)
        {
            var emptyFields = CountEmptyFields(fields);
            if (emptyFields == 0) return fields;

            if (emptyFields == 8) return FirstTurn(fields);

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
            var inversrRowTurn = InverseRowWinSequence(field);
            var columnTurn = ColumnWinSequence(field);
            var inverseColumnTurn = InverseColumnWinSequence(field);
            var diagonalTurn = DiagonalWinSequence(field);
            var additionalTurn = AdditionalRowAndCollumnWinSequence(field);

            if (rowTurn != -1)
            {
                field[rowTurn] = 'O';
                return field;
            }
            if(inversrRowTurn != -1)
            {
                field[inversrRowTurn] = 'O';
                return field;
            }
            if (columnTurn != -1)
            {
                field[columnTurn] = 'O';
                return field;
            }
            if(inverseColumnTurn != -1)
            {
                field[inverseColumnTurn] = 'O';
                return field;
            }
            if(diagonalTurn != -1)
            {
                field[diagonalTurn] = 'O';
                return field;
            }
            if(additionalTurn != -1)
            {
                field[additionalTurn] = 'O';
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
            var araryField = DictToArray(field);

            int rows = araryField.GetUpperBound(0) + 1;
            int columns = araryField.Length / rows;

            var markCount = 0;
            char tmpChar = ' ';

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 & j == 0 & araryField[i, j] != ' ')
                    {
                        tmpChar = araryField[i, j];
                        continue;
                    }
                    else if (araryField[i, j] == tmpChar & tmpChar != ' ')
                    {
                        markCount++;
                    }
                    //
                    if (markCount == 1 & araryField[i, 2] == ' ')
                    {
                        switch (i)
                        {
                            case 0:
                                return 2;
                            case 1:
                                return 5;
                            case 2:
                                return 8;
                        }
                    }
                    //
                    tmpChar = araryField[i, j];
                }
                markCount = 0;
            }
            return -1;
        }
        public int InverseRowWinSequence(Dictionary<int, char> field)
        {
            var araryField = DictToArray(field);

            int rows = araryField.GetUpperBound(0) + 1;
            int columns = araryField.Length / rows;

            var markCount = 0;
            char tmpChar = ' ';

            for (int i = 0; i < rows; i++)
            {
                for (int j = columns - 1; j >= 0; j--)
                {
                    if (i == 0 & j == 0 & araryField[i, j] != ' ')
                    {
                        tmpChar = araryField[i, j];
                        continue;
                    }
                    else if (araryField[i, j] == tmpChar & tmpChar != ' ')
                    {
                        markCount++;
                    }
                    //
                    if (markCount == 1 & araryField[i, 0] == ' ')
                    {
                        switch (i)
                        {
                            case 0:
                                return 0;
                            case 1:
                                return 3;
                            case 2:
                                return 6;
                        }
                    }
                    //
                    tmpChar = araryField[i, j];
                }
                markCount = 0;
            }

            return -1;
        }
        public int ColumnWinSequence(Dictionary<int, char> field)
        {
            var araryField = DictToArray(field);

            int rows = araryField.GetUpperBound(0) + 1;
            int columns = araryField.Length / rows;

            var markCount = 0;
            char tmpChar = ' ';
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {

                    if (j == 2 & i == 2 & araryField[i, j] != ' ')
                    {
                        tmpChar = araryField[i, j];
                        continue;
                    }
                    else if (araryField[i, j] == tmpChar & tmpChar != ' ')
                    {
                        markCount++;
                    }

                    if (markCount == 1 & araryField[2, j] == ' ')
                    {
                        return j + 6;
                    }
                    tmpChar = araryField[i, j];
                }
                markCount = 0;
            }
            return -1;
        }
        public int InverseColumnWinSequence(Dictionary<int, char> field)
        {
            var araryField = DictToArray(field);

            int rows = araryField.GetUpperBound(0) + 1;
            int columns = araryField.Length / rows;

            var markCount = 0;
            char tmpChar = ' ';
            for (int j = columns - 1; j >= 0; j--)
            {
                for (int i = rows - 1; i >= 0; i--)
                {

                    if (j == 2 & i == 2 & araryField[i, j] != ' ')
                    {
                        tmpChar = araryField[i, j];
                        continue;
                    }
                    else if (araryField[i, j] == tmpChar & tmpChar != ' ')
                    {
                        markCount++;
                    }

                    if (markCount == 1 & araryField[0, j] == ' ')
                    {
                        return j;
                    }
                    tmpChar = araryField[i, j];
                }
                markCount = 0;
            }
            return -1;
        }
        public int DiagonalWinSequence(Dictionary<int, char> field)
        {
            if (field[0] == field[4] && field[8] == ' ') return 8;
            if (field[4] == field[8] && field[0] == ' ') return 0;
            if (field[8] == field[0] && field[4] == ' ') return 4;
            if (field[2] == field[4] && field[6] == ' ') return 6; 
            if (field[6] == field[4] && field[2] == ' ') return 2;
            if (field[2] == field[6] && field[4] == ' ') return 4;

            return -1;
        }
        private int AdditionalRowAndCollumnWinSequence(Dictionary<int, char> field)
        {
            if (field[0] == field[2] && field[1] == ' ') return 1;
            if (field[3] == field[5] && field[4] == ' ') return 4;
            if (field[6] == field[8] && field[7] == ' ') return 7;

            if (field[0] == field[6] && field[3] == ' ') return 3;
            if (field[1] == field[7] && field[4] == ' ') return 4;
            if (field[2] == field[8] && field[5] == ' ') return 5;

            return -1;
        }

        private char[,] DictToArray(Dictionary<int, char> field)
        {
            char[,] array = new char[3, 3];
            int index = 0;

            foreach (var key in field.Keys)
            {
                char value = field[key];
                int row = index / 3;
                int col = index % 3;

                array[row, col] = value;
                index++;
            }

            return array;
        }
    }
}
