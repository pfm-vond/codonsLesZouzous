using System;
using System.Collections.Generic;

namespace CodingGames.BouncingBarry
{
    class Move
    {
        public Vector2 Direction { get; set; }
        public int Length { get; set; } = 0;

        internal Vector2 Execute(Vector2 startingPosition, Floor toggleSquares)
        {
            Vector2 currentPosition = startingPosition;
            for(int i = 0; i < Length; i++)
            {
                currentPosition = currentPosition + Direction;
                if(toggleSquares.Contains(currentPosition))
                {
                    toggleSquares.Remove(currentPosition);
                }
                else
                {
                    toggleSquares.Add(currentPosition);
                }
            }

            return currentPosition;
        }
    }
}
