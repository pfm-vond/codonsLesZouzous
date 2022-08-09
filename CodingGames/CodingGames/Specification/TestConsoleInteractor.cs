using System;
using System.Collections.Generic;

namespace CodingGames.Specification
{
    public class TestConsoleInteractor : Interact
    {
        private Queue<string> readable;

        public TestConsoleInteractor(string[] lines)
        {
            readable = new Queue<string>(lines);
        }

        public TestConsoleInteractor(string lines)
            : this(lines.Split(Environment.NewLine))
        {}

        public string ReadNext()
        {
            if (readable.TryDequeue(out string result))
                return result;

            return null;
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