using MarsExploration.Domain.Commands;
using MarsExploration.Domain.Models;
using MarsExploration.Domain.Enums;

namespace MarsExploration.Test.Domain.Commands
{
    public class MoveForwardCommandTests
    {
        [Fact]
        public void Execute_ShouldCallMoveForwardOnRover()
        {
            // Arrange
            var plateau = new Plateau(5, 5);
            var position = new Position(1, 1);
            var rover = new Rover(position, Direction.N, plateau);

            var command = new MoveForwardCommand();

            // Act
            command.Execute(rover);

            // Assert
            Assert.Equal(1, rover.Position.X);
            Assert.Equal(2, rover.Position.Y); // Moveu para o norte
        }
    }
}
