using System.Collections.Generic;

namespace CodingGames.CodeVsZombies
{
    class Turn
    {
        public Player Ash;
        public List<Human> Humans = new List<Human>();
        public List<Zombie> Zombies = new List<Zombie>();

        public Turn(string playerPosition, Interact interactor)
        {
            var inputs = playerPosition.Split(' ');
            Ash = new Player(
                this,
                new Position(inputs[0], inputs[1]));

            int humanCount = int.Parse(interactor.ReadNext());
            for (int i = 0; i < humanCount; i++)
            {
                inputs = interactor.ReadNext().Split(' ');
                Humans.Add(
                    new Human(
                        this,
                        inputs[0],
                        new Position(inputs[1], inputs[2])
                        )
                    );
            }
            int zombieCount = int.Parse(interactor.ReadNext());
            for (int i = 0; i < zombieCount; i++)
            {
                inputs = interactor.ReadNext().Split(' ');
                Zombies.Add(
                    new Zombie(
                        this,
                        inputs[0],
                        new Position(inputs[1], inputs[2]),
                        new Position(inputs[3], inputs[4])
                        )
                    );
            }
        }
    }
}