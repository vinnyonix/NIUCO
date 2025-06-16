using MarsExploration.Domain.Interfaces;
using MarsExploration.Domain.Commands;

namespace MarsExploration.Domain.Factories
{
    public static class HoverMovementCommandFactory
    {
        public static IHoverMovementCommand Create(char commandChar)
        {
            return commandChar switch
            {
                'M' => new MoveForwardCommand(),
                'L' => new TurnLeftCommand(),
                'R' => new TurnRightCommand(),
                _ => throw new ArgumentException($"Comando inválido: {commandChar}")
            };
        }
    }
}
