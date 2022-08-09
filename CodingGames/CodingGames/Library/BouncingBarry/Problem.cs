using System;
using System.Collections.Generic;

namespace CodingGames.BouncingBarry
{

    public class Problem
    {
        public Interact Interactor { get; }
        internal List<Move> Jumps { get; private set; } = new List<Move>();

        private string[] Directions;
        private string[] NbJumps;

        public Problem(Interact interactor)
        {
            Interactor = interactor;
            Directions = Interactor.ReadNext().Split(' ');
            NbJumps = Interactor.ReadNext().Split(' ');

            Move LastMove = null;
            string lastDirection = "";
            for (int i = 0; i < Directions.Length; i++)
            {
                if (Directions[i] != lastDirection)
                {
                    Move CurrentMove = new Move()
                    {
                        Direction = ParseDirection(i),
                        Length = ParseLength(i)
                    };

                    Jumps.Add(CurrentMove);
                    LastMove = CurrentMove;
                    lastDirection = Directions[i];
                }
                else
                {
                    LastMove.Length += ParseLength(i);
                }
            }
        }
        int ParseLength(int index)
        {
            return int.Parse(NbJumps[index]);
        }

        Vector2 ParseDirection(int index)
        {
            switch (Directions[index])
            {
                case "N":
                    return Vector2.North;

                case "E":
                    return Vector2.East;

                case "S":
                    return Vector2.South;

                case "W":
                    return Vector2.West;
            }

            throw new ArgumentException($"[{Directions[index]}] unknown (result displayed between [])");
        }
    }
}
