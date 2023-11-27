namespace TicTacToe.Engine.Services
{
    public class RivalService : IRivalService
    {
        public Dictionary<int, char> MakeMove(Dictionary<int, char> fields)
        {
            var emptyFields = CountEmptyFields(fields);
            if (emptyFields == 0) return fields;

            var move = new Random().Next(1, emptyFields);

            if (emptyFields == 0) return fields;

            var i = 0;
            int counter = 0;
            while (counter < move)
            {
                if (fields[i] == ' ') counter++;
                if (counter == move) fields[i] = 'O';
                i++;
            }

            return fields;
        }

        public int CountEmptyFields(Dictionary<int, char> fields)
        {
            if (fields is null) throw new ArgumentNullException(nameof(fields));

            var emptyFields = fields.Where(x => x.Value == ' ').Count();

            return emptyFields;
        }
    }
}
