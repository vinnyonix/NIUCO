using MarsExploration.Domain.Interfaces;
using MarsExploration.Domain.Models;

namespace MarsExploration.Domain.Commands
{
    public class TurnRightCommand : IHoverMovementCommand
    {
        public void Execute(Rover rover) => rover.TurnRight();
    }
}
