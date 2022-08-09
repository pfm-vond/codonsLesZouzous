using System.Collections.Generic;
using System.Linq;

namespace CodingGames.BouncingBarry
{

    public class Solver
    {
        private Problem Problem;

        public Solver(Problem problem)
        {
            this.Problem = problem;
        }

        Floor ToggleSquares = new Floor();

        public IEnumerable<string> Solve()
        {
            Vector2 Current = new Vector2 { X = 0, Y = 0 };
            foreach (var jump in Problem.Jumps) 
            {
                Current = jump.Execute(Current, ToggleSquares);
            }

            return ToggleSquares.Tolines();
        }
    }
}
