using MarsExploration.Domain.Models;

namespace MarsExploration.Domain.Interfaces
{
    public interface IHoverMovementCommand
    {
        void Execute(Rover rover);
    }
}
