using System;

namespace FizzBuzz.Library
{
    internal class DummyGame : IFizzBuzzGame
    {
        private readonly Display writeLine;

        public DummyGame(Display writeLine)
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
