using TicTacToe.Engine.Services;

namespace TicTacToeTests
{
    public class GameServiceTest
    {
        [Fact]
        public void RowWinSequenceIsTrue()
        {
            //Arrange
            GameService gameService = new GameService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, 'X'},

                { 3, 'O'},
                { 4, 'O'},
                { 5, 'O'},

                { 6, 'X'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = gameService.RowWinSequence(field, 'O');
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void RowWinSequenceIsFalse()
        {
            //Arrange
            GameService gameService = new GameService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, 'O'},

                { 3, 'O'},
                { 4, 'O'},
                { 5, 'X'},

                { 6, 'X'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = gameService.RowWinSequence(field, 'O');
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ColumnWinSequenceIsTrue()
        {
            //Arrange
            GameService gameService = new GameService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, 'X'},

                { 3, 'O'},
                { 4, 'O'},
                { 5, 'O'},

                { 6, 'O'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = gameService.ColumnWinSequence(field, 'O');
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void ColumnWinSequenceIsFalse()
        {
            //Arrange
            GameService gameService = new GameService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, 'X'},

                { 3, 'O'},
                { 4, 'X'},
                { 5, 'O'},

                { 6, 'X'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = gameService.ColumnWinSequence(field, 'O');
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DiagonalWinSequenceIsTrue()
        {
            //Arrange
            GameService gameService = new GameService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, 'X'},

                { 3, 'O'},
                { 4, 'X'},
                { 5, 'O'},

                { 6, 'X'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = gameService.DiagonalWinSequence(field, 'X');
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void DiagonalWinSequenceIsFalse()
        {
            //Arrange
            GameService gameService = new GameService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, 'X'},

                { 3, 'O'},
                { 4, 'X'},
                { 5, 'O'},

                { 6, 'O'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = gameService.DiagonalWinSequence(field, 'X');
            //Assert
            Assert.False(result);

        }
    }
}