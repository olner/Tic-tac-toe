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

                { 3, 'X'},
                { 4, 'O'},
                { 5, 'O'},

                { 6, ' '},
                { 7, ' '},
                { 8, ' '}
            };
            //Act
            var result = service.RowWinSequence(field);
            //Assert
            Assert.Equal(-1, result);
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
    }
}
