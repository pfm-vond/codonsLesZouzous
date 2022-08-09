using System;

namespace CodingGames.CodeVsZombies
{
    public struct Position
    {
        public Position(string x, string y)
            : this(int.Parse(x), int.Parse(y))
        {
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x;
        public int y;

        public override string ToString()
        {
            return $"{x} {y}";
        }

        public double DistanceTo(Position other)
        {
            double xdiff = this.x - other.x;
            double ydiff = this.y - other.y;
            return Math.Sqrt(xdiff * xdiff + ydiff * ydiff);
        }
    }
}
