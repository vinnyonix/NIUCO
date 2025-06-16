namespace MarsExploration.Domain.Models
{
    public class Plateau
    {
        public int Width { get; }
        public int Height { get; }

        private HashSet<string> _occupiedPositions = new();

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsInside(Position pos) => pos.X >= 0 && pos.X <= Width && pos.Y >= 0 && pos.Y <= Height;
        public bool IsOccupied(Position pos) => _occupiedPositions.Contains($"{pos.X},{pos.Y}");
        public void Occupy(Position pos) => _occupiedPositions.Add($"{pos.X},{pos.Y}");
        public void Vacate(Position pos) => _occupiedPositions.Remove($"{pos.X},{pos.Y}");
    }
}
