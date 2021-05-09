using System;

namespace FizzBuzz.Library
{
    internal class DummyGame : IFizzBuzzGame
    {
        private readonly Factory.Display writeLine;

        public DummyGame(Factory.Display writeLine)
        {
            this.writeLine = writeLine;
        }

        public void Play()
        {
            for (int i = 1; i <= 100; i++)
                writeLine("Hello World !");
        }
    }
}
