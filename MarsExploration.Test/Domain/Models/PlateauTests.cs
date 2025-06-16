using MarsExploration.Domain.Models;
namespace MarsExploration.Test.Domain.Models
{
    public class PlateauTests
    {
        [Fact]
        public void Constructor_ShouldSetWidthAndHeight()
        {
            var plateau = new Plateau(5, 5);

            Assert.Equal(5, plateau.Width);
            Assert.Equal(5, plateau.Height);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(5, 5, true)]
        [InlineData(-1, 2, false)]
        [InlineData(2, -1, false)]
        [InlineData(6, 2, false)]
        [InlineData(2, 6, false)]
        public void IsInside_ShouldReturnExpectedResult(int x, int y, bool expected)
        {
            var plateau = new Plateau(5, 5);
            var pos = new Position(x, y);

            bool result = plateau.IsInside(pos);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void OccupyAndIsOccupied_ShouldWorkCorrectly()
        {
            var plateau = new Plateau(5, 5);
            var pos = new Position(2, 2);

            Assert.False(plateau.IsOccupied(pos)); // inicialmente não ocupada

            plateau.Occupy(pos);
            Assert.True(plateau.IsOccupied(pos)); // deve estar ocupada
        }

        [Fact]
        public void Vacate_ShouldFreeThePosition()
        {
            var plateau = new Plateau(5, 5);
            var pos = new Position(3, 3);

            plateau.Occupy(pos);
            Assert.True(plateau.IsOccupied(pos));

            plateau.Vacate(pos);
            Assert.False(plateau.IsOccupied(pos));
        }
    }
}

