using MarsExploration.Domain.Commands;
using MarsExploration.Domain.Models;
using MarsExploration.Domain.Enums;

namespace MarsExploration.Test.Domain.Commands
{
    public class TurnRightCommandTests
    {
        [Fact]
        public void Execute_ShouldTurnRoverRight()
        {
            var rover = new Rover(new Position(0, 0), Direction.N, new Plateau(5, 5));
            var command = new TurnRightCommand();

            command.Execute(rover);

            Assert.Equal(Direction.E, rover.Direction);
        }
    }
}
