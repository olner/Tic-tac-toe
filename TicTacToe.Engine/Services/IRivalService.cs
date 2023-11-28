namespace TicTacToe.Engine.Services
{
    public interface IRivalService
    {
        public Dictionary<int, char> MakeMove(Dictionary<int, char> fields);

        public int CountEmptyFields(Dictionary<int, char> fields);
        public int RowWinSequence(Dictionary<int, char> field);
        public int ColumnWinSequence(Dictionary<int, char> field);

    }
}
