﻿namespace TicTacToe.Engine.Services
{
     public interface IGameService
    {
        /// <summary>
        /// Name of winner or draw. If no one wins yet then returns continue
        /// </summary>
        /// <param name="field"></param>
        /// <param name="xPlayer"></param>
        /// <param name="oPlayer"></param>
        /// <returns></returns>
        public string HwoIsWinner(Dictionary<int,char> field, string xPlayer, string oPlayer);
        public bool RowWinSequence(Dictionary<int, char> field, char mark);
        public bool ColumnWinSequence(Dictionary<int, char> field, char mark);
        public bool DiagonalWinSequence(Dictionary<int, char> field, char mark);
    }
}
