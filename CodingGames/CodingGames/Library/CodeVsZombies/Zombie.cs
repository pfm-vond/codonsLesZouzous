namespace CodingGames.CodeVsZombies
{
    internal class Zombie
    {
        private int Id;
        public Position Position;
        private Position NextPosition;
        private int speed = 400;

        public Zombie(Turn current, string id, Position position, Position nextPosition)
            : this(current, int.Parse(id), position, nextPosition)
        { }

        public Zombie(Turn current, int id, Position position, Position nextPosition)
        {
            this.Id = id;
            this.Position = position;
            this.NextPosition = nextPosition;
        }

        public double TimeToKill(Human h)
        {
            return (Position.DistanceTo(h.Position)) / speed;
        }

        public override string ToString()
        {
            return $"{Id} ({Position})";
        }
    }
}