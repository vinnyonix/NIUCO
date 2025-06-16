using MarsExploration.Domain.Interfaces;
using MarsExploration.Domain.Models;

namespace MarsExploration.Domain.Commands
{
    public class MoveForwardCommand : IHoverMovementCommand
    {
        public void Execute(Rover rover) => rover.MoveForward();
    }
}
