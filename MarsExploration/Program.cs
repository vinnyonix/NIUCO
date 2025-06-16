using MarsExploration.Domain.Enums;
using MarsExploration.Domain.Factories;
using MarsExploration.Domain.Models;
using MarsExploration.Viewer;

Console.WriteLine(":::   EXECUÇÃO SEM TRILHA  :::");

// Criando um platô de matriz 5,5
var plateau = new Plateau(5, 5);
// Criando uma sonda e passando sua posição inicial e o platô onde ela deve se movimentar.
var rover = new Rover(new Position(3, 2), Direction.N, plateau);
// Passando para a sonda seu roteiro.
rover.ExecuteCommands("MRM");
Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Direction}");


Console.WriteLine(":::   EXECUÇÃO COM TRILHA  :::");

// Criando um platô de matriz 10,10
var plateau2 = new Plateau(10, 10);
// Criando a posição inicial da Sonda2.
var start = new Position(3, 4);
// Passando a posição inicial e o platô para a Sonda2 onde ela deve se movimentar.
var rover2 = new Rover(start, Direction.N, plateau2);
// Criando o tracker com suas configurações.
var tracker = new RoverTracker(plateau2.Width, plateau2.Height);
// Simula execução dos comandos e faz tracking após cada passo
string commands = "MMMRMMLMMMLMM";
tracker.Track(rover2.Position.X, rover2.Position.Y, rover2.Direction); // estado inicial

foreach (char cmd in commands)
{
    var command = HoverMovementCommandFactory.Create(cmd);
    command.Execute(rover2);
    tracker.Track(rover2.Position.X, rover2.Position.Y, rover2.Direction);
}
tracker.PrintMap();
