using System;

namespace CodingGames.ConsoleApp
{
    public class ConsoleInteractor : Interact
    {
        public string ReadNext()
        {
            return Console.ReadLine();
        }

        public void Debug(string read)
        {
            Console.Error.WriteLine(read);
        }

        public void Debug(int read)
        {
            Console.Error.WriteLine(read);
        }
    }
}
