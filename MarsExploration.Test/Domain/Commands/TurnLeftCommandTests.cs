using MarsExploration.Domain.Commands;
using MarsExploration.Domain.Enums;
using MarsExploration.Domain.Models;

namespace MarsExploration.Test.Domain.Commands
{
    public class TurnLeftCommandTests
    {
        [Fact]
        public void Execute_ShouldTurnRoverLeft()
        {
            var rover = new Rover(new Position(0, 0), Direction.N, new Plateau(5, 5));
            var command = new TurnLeftCommand();

            command.Execute(rover);

            Assert.Equal(Direction.W, rover.Direction);
        }
    }
}

