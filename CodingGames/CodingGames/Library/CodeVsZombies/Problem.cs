using System.Collections.Generic;

namespace CodingGames.CodeVsZombies
{
    public class Problem
    {
        public Interact Interactor { get; }
        private Stack<Turn> Turns = new Stack<Turn>();

        internal Turn CurrentTurn => Turns.Peek();

        public Problem(Interact interactor)
        {
            Interactor = interactor;
        }

        internal bool MoveToNextTurn()
        {
            string inputs = Interactor.ReadNext();
            bool hasNextTurn = inputs != null;

            if (!hasNextTurn)
                return false;

            Turns.Push(new Turn(inputs, Interactor));

            return hasNextTurn;
        }
    }
}
