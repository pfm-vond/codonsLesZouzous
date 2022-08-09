using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CodingGames.BouncingBarry
{
    [DebuggerDisplay("{Toggled}")]
    internal class Floor
    {
        private HashSet<Vector2> Toggled = new HashSet<Vector2>();

        public bool Contains(Vector2 value)
        {
            return Toggled.Contains(value);
        }
        public bool Add(Vector2 value)
        {
            return Toggled.Add(value);
        }

        public void Remove(Vector2 value)
        {
            Toggled.Remove(value);
        }

        internal IEnumerable<string> Tolines()
        {
            Vector2 from = new Vector2
            {
                X = Toggled.Min(p => p.X),
                Y = Toggled.Min(p => p.Y)
            };

            Vector2 to = new Vector2
            {
                X = Toggled.Max(p => p.X),
                Y = Toggled.Max(p => p.Y)
            };

            StringBuilder line = new StringBuilder();

            for(int x = from.X; x <= to.X; x++) 
            { 
                for (int y = from.Y; y <= to.Y; y++)
                {
                    if (Toggled.Contains(new Vector2 { X = x, Y = y }))
                        line.Append('#');
                    else
                        line.Append('.');
                }
                yield return line.ToString();
                line.Clear();
            }
        }
    }
}
