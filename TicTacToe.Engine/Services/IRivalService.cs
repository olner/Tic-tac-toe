using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Services
{
    public interface IRivalService
    {
        public Dictionary<int, char> MakeMove(Dictionary<int, char> fields);

        public int CountEmptyFields(Dictionary<int, char> fields);

    }
}
