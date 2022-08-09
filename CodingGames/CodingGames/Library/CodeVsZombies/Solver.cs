using System.Collections.Generic;
using System.Linq;

namespace CodingGames.CodeVsZombies
{
    public class Solver
    {
        private Problem Problem;

        public Solver(Problem problem)
        {
            this.Problem = problem;
        }

        public IEnumerable<Position> Solve()
        {
            while (Problem.MoveToNextTurn())
            {
                Turn current = Problem.CurrentTurn;

                yield return current.Humans
                    .OrderBy(human => human.ClosestZombie().TimeToKill(human))
                    .FirstOrDefault(human => current.Ash.CanReach(human))
                    ?.ClosestZombie()
                    ?.Position
                    
                    ?? current.Ash.Position;

            }
        }
    }
}
