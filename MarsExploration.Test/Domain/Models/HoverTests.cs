using MarsExploration.Domain.Enums;
using MarsExploration.Domain.Models;
using System;
using System.Collections.Generic;
namespace MarsExploration.Test.Domain.Models
{
    public class RoverTests
    {
        [Fact]
        public void Constructor_ShouldSetInitialPositionAndDirection_AndOccupyPlateau()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(1, 2);
            var rover = new Rover(position, Direction.N, plateau);

            Assert.Equal(1, rover.Position.X);
            Assert.Equal(2, rover.Position.Y);
            Assert.Equal(Direction.N, rover.Direction);
            Assert.True(plateau.IsOccupied(position));
        }

        [Theory]
        [InlineData(Direction.N, Direction.W)]
        [InlineData(Direction.W, Direction.S)]
        [InlineData(Direction.S, Direction.E)]
        [InlineData(Direction.E, Direction.N)]
        public void TurnLeft_ShouldRotateCounterClockwise(Direction initial, Direction expected)
        {
            var rover = new Rover(new Position(0, 0), initial, new Plateau(5, 5));

            rover.TurnLeft();

            Assert.Equal(expected, rover.Direction);
        }

        [Theory]
        [InlineData(Direction.N, Direction.E)]
        [InlineData(Direction.E, Direction.S)]
        [InlineData(Direction.S, Direction.W)]
        [InlineData(Direction.W, Direction.N)]
        public void TurnRight_ShouldRotateClockwise(Direction initial, Direction expected)
        {
            var rover = new Rover(new Position(0, 0), initial, new Plateau(5, 5));

            rover.TurnRight();

            Assert.Equal(expected, rover.Direction);
        }

        [Theory]
        [InlineData(Direction.N, 1, 2, 1, 3)]
        [InlineData(Direction.E, 1, 2, 2, 2)]
        [InlineData(Direction.S, 1, 2, 1, 1)]
        [InlineData(Direction.W, 1, 2, 0, 2)]
        public void MoveForward_ShouldMoveCorrectly(Direction dir, int startX, int startY, int endX, int endY)
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(new Position(startX, startY), dir, plateau);

            rover.MoveForward();

            Assert.Equal(endX, rover.Position.X);
            Assert.Equal(endY, rover.Position.Y);
            Assert.True(plateau.IsOccupied(rover.Position));
        }

        [Fact]
        public void MoveForward_ShouldNotMove_IfOutsidePlateau()
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(new Position(0, 0), Direction.S, plateau);

            rover.MoveForward(); 

            Assert.Equal(0, rover.Position.X);
            Assert.Equal(0, rover.Position.Y);
        }

        [Fact]
        public void MoveForward_ShouldNotMove_IfNextPositionIsOccupied()
        {
            var plateau = new Plateau(5, 5);
            var occupiedPosition = new Position(1, 2);
            var rover1 = new Rover(occupiedPosition, Direction.N, plateau);

            var rover2 = new Rover(new Position(1, 1), Direction.N, plateau);

            rover2.MoveForward();

            Assert.Equal(1, rover2.Position.X);
            Assert.Equal(1, rover2.Position.Y);
        }

        [Fact]
        public void ExecuteCommands_ShouldMoveAndRotateCorrectly()
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(new Position(1, 2), Direction.N, plateau);

            rover.ExecuteCommands("LMLMLMLMM");

            Assert.Equal(1, rover.Position.X);
            Assert.Equal(3, rover.Position.Y);
            Assert.Equal(Direction.N, rover.Direction);
        }

        [Fact]
        public void ExecuteCommands_ShouldRespectOccupiedPositions()
        {
            var plateau = new Plateau(5, 5);
            var rover1 = new Rover(new Position(2, 2), Direction.N, plateau);
            var rover2 = new Rover(new Position(2, 1), Direction.N, plateau);

            rover2.ExecuteCommands("M"); 

            Assert.Equal(2, rover2.Position.X);
            Assert.Equal(1, rover2.Position.Y);
        }
    }
}
