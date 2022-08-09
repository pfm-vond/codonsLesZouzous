using System.Linq;

namespace CodingGames.CodeVsZombies
{
    internal class Human
    {
        public int Id;
        public Position Position;
        public Turn Board;

        public Human(Turn current, string id, Position position)
            : this(current, int.Parse(id), position)
        { }

        public Human(Turn current, int id, Position position)
        {
            Board = current;
            this.Id = id;
            this.Position = position;
        }

        public Zombie ClosestZombie()
        {
            return Board.Zombies.OrderBy(z => z.TimeToKill(this)).First();
        }
    }
}