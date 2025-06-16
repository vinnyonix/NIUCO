using MarsExploration.Domain.Enums;
using MarsExploration.Domain.Factories;
using System.Windows.Input;

namespace MarsExploration.Domain.Models
{
    public class Rover
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        private readonly Plateau _plateau;

        public Rover(Position position, Direction direction, Plateau plateau)
        {
            Position = position;
            Direction = direction;
            _plateau = plateau;
            _plateau.Occupy(Position);
        }

        public void ExecuteCommands(string commandSequence)
        {
            foreach (char c in commandSequence)
            {
                var command = HoverMovementCommandFactory.Create(c);
                command.Execute(this);
            }
        }

        public void TurnLeft() => Direction = (Direction)(((int)Direction + 3) % 4);
        public void TurnRight() => Direction = (Direction)(((int)Direction + 1) % 4);

        public void MoveForward()
        {
            Position next = NextPosition();

            if (!_plateau.IsInside(next) || _plateau.IsOccupied(next))
                return; 

            _plateau.Vacate(Position);
            Position = next;
            _plateau.Occupy(Position);
        }

        private Position NextPosition()
        {
            return Direction switch
            {
                Direction.N => new Position(Position.X, Position.Y + 1),
                Direction.E => new Position(Position.X + 1, Position.Y),
                Direction.S => new Position(Position.X, Position.Y - 1),
                Direction.W => new Position(Position.X - 1, Position.Y),
                _ => throw new InvalidOperationException("Direção inválida")
            };
        }
    }
}
