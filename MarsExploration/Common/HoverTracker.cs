using MarsExploration.Domain.Enums;

namespace MarsExploration.Viewer
{
    using System;
    using System.Collections.Generic;

    public class RoverTracker
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<(int x, int y, Direction dir)> _path = new();

        public RoverTracker(int width, int height)
        {
            if (width > 10 || height > 10)
            {
                Console.WriteLine("⚠️  RoverTracker suporta visualização apenas de platôs até 10x10. Visualização desativada.");
                _enabled = false;
            }

            _width = width;
            _height = height;
        }

        private readonly bool _enabled = true;

        public void Track(int x, int y, Direction dir)
        {
            if (!_enabled) return;
            _path.Add((x, y, dir));
        }

        public void PrintMap()
        {
            if (!_enabled) return;

            string[,] grid = new string[_height + 1, _width + 1];

            for (int y = 0; y <= _height; y++)
                for (int x = 0; x <= _width; x++)
                    grid[y, x] = " ";

            // Caminho com "*"
            for (int i = 1; i < _path.Count - 1; i++)
            {
                var (x, y, _) = _path[i];
                grid[y, x] = "*";
            }

            // Direções como ícones
            static string Icon(Direction d) => d switch
            {
                Direction.N => "^",
                Direction.S => "v",
                Direction.E => ">",
                Direction.W => "<",
                _ => "?"
            };

            if (_path.Count > 0)
            {
                var (xStart, yStart, dirStart) = _path[0];
                grid[yStart, xStart] = Icon(dirStart); // mesmo ícone para início e fim
            }

            if (_path.Count > 1)
            {
                var (xEnd, yEnd, dirEnd) = _path[^1];
                grid[yEnd, xEnd] = Icon(dirEnd); // ícone final
            }

            // Impressão
            for (int y = _height; y >= 0; y--)
            {
                Console.Write($"{y,2} | ");
                for (int x = 0; x <= _width; x++)
                    Console.Write(grid[y, x] + " ");
                Console.WriteLine();
            }

            Console.Write("   +");
            for (int x = 0; x <= _width; x++) Console.Write("--");
            Console.WriteLine();

            Console.Write("     ");
            for (int x = 0; x <= _width; x++) Console.Write($"{x} ");
            Console.WriteLine();
        }
    }
}

