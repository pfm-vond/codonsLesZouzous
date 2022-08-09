namespace CodingGames.CodeVsZombies
{
    internal class Player
    {
        public Position Position;
        private int speed = 1000;
        private int killRange = 2000;

        public Player(Turn current, Position position)
        {
            this.Position = position;
        }

        public bool CanReach(Human h)
        {
            var timeToSave = TimeToSave(h);
            var closestZombie = h.ClosestZombie();
            var deadline = closestZombie.TimeToKill(h);

            return timeToSave <= deadline;
        }

        public double TimeToSave(Human h)
        {
            return (Position.DistanceTo(h.ClosestZombie().Position) - killRange) / speed;
        }
    }
}