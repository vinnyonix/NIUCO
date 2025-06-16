using MarsExploration.Domain.Factories;
using MarsExploration.Domain.Commands;

namespace MarsExploration.Test.Domain.Factories
{
    public class HoverMovementCommandFactoryTests
    {
        [Theory]
        [InlineData('M', typeof(MoveForwardCommand))]
        [InlineData('L', typeof(TurnLeftCommand))]
        [InlineData('R', typeof(TurnRightCommand))]
        public void Create_ValidCommands_ReturnsCorrectCommandType(char input, Type expectedType)
        {
            // Act
            var command = HoverMovementCommandFactory.Create(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType(expectedType, command);
        }

        [Theory]
        [InlineData('X')]
        [InlineData(' ')]
        [InlineData('1')]
        [InlineData('Z')]
        public void Create_InvalidCommand_ThrowsArgumentException(char invalidCommand)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                HoverMovementCommandFactory.Create(invalidCommand)
            );

            Assert.Contains("Comando inválido", exception.Message);
        }
    }
}

