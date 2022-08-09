using System.Diagnostics;

namespace CodingGames.BouncingBarry
{
    [DebuggerDisplay("x = {X} y = {Y}")]
    struct Vector2
    {
        public int X;
        public int Y;

        public static Vector2 North = new Vector2() { X = -1, Y = 0 };
        public static Vector2 East = new Vector2() { X = 0, Y = 1 };
        public static Vector2 South = new Vector2() { X = 1, Y = 0 };
        public static Vector2 West = new Vector2() { X = 0, Y = -1 };

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2 { X = a.X + b.X, Y = a.Y + b.Y };
        }
    }
}
