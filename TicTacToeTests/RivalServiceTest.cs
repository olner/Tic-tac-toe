using TicTacToe.Engine.Services;

namespace TicTacToeTests
{
    public class RivalServiceTest
    {
        [Fact]
        public void RowWinSequenceIsTrue()
        {
            //Arrange
            RivalService service = new RivalService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'X'},
                { 1, ' '},
                { 2, ' '},

                { 3, 'O'},
                { 4, 'O'},
                { 5, ' '},

                { 6, ' '},
                { 7, ' '},
                { 8, ' '}
            };
            //Act
            var result = service.RowWinSequence(field);
            //Assert
            Assert.Equal(5, result);
        }
        [Fact]
        public void InverseRowWinSequenceIsTrue()
        {
            //Arrange
            RivalService service = new RivalService();
            var field = new Dictionary<int, char>()
            {
                { 0, ' '},
                { 1, ' '},
                { 2, ' '},

                { 3, ' '},
                { 4, 'O'},
                { 5, 'O'},

                { 6, 'X'},
                { 7, ' '},
                { 8, ' '}
            };
            //Act
            var result = service.InverseRowWinSequence(field);
            //Assert
            Assert.Equal(3, result);
        }
        [Fact]
        public void CollumnWinSequenceIsTrue()
        {
            //Arrange
            RivalService service = new RivalService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'X'},
                { 1, ' '},
                { 2, ' '},

                { 3, 'X'},
                { 4, 'O'},
                { 5, 'O'},

                { 6, ' '},
                { 7, ' '},
                { 8, ' '}
            };
            //Act
            var result = service.ColumnWinSequence(field);
            //Assert
            Assert.Equal(6, result);
        }
        [Fact]
        public void InverseCollumnWinSequenceIsTrue()
        {
            //Arrange
            RivalService service = new RivalService();
            var field = new Dictionary<int, char>()
            {
                { 0, ' '},
                { 1, ' '},
                { 2, ' '},

                { 3, ' '},
                { 4, 'X'},
                { 5, ' '},

                { 6, 'O'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = service.InverseColumnWinSequence(field);
            //Assert
            Assert.Equal(1, result);
        }
        [Fact]
        public void DiagonalWinSequence()
        {
            RivalService service = new RivalService();
            var field = new Dictionary<int, char>()
            {
                { 0, 'O'},
                { 1, ' '},
                { 2, ' '},

                { 3, ' '},
                { 4, ' '},
                { 5, ' '},

                { 6, 'O'},
                { 7, 'X'},
                { 8, 'O'}
            };
            //Act
            var result = service.DiagonalWinSequence(field);
            //Assert
            Assert.Equal(4, result);
        }
    }
}
