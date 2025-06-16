using MarsExploration.Domain.Models;

namespace MarsExploration.Test.Domain.Models
{
    public class PositionTests
    {
        [Fact]
        public void Constructor_ShouldSetXAndY()
        {
            var position = new Position(3, 4);

            Assert.Equal(3, position.X);
            Assert.Equal(4, position.Y);
        }
    }
}
