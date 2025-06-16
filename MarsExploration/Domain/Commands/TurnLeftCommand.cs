using MarsExploration.Domain.Interfaces;
using MarsExploration.Domain.Models;

namespace MarsExploration.Domain.Commands
{
    public class TurnLeftCommand : IHoverMovementCommand
    {
        public void Execute(Rover rover) => rover.TurnLeft();
    }
}
