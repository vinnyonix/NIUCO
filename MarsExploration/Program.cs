using MarsExploration.Domain.Enums;
using MarsExploration.Domain.Models;

Console.WriteLine("Hello, World!");

var plateau = new Plateau(5, 5);
var rover = new Rover(new Position(3, 2), Direction.N, plateau);
rover.ExecuteCommands("MRM");
Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Direction}");

