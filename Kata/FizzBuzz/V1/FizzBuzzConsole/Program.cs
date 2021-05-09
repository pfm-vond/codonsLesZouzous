using System;

namespace FizzBuzzConsole
{

    public class Program
    {
        public static void Main(string[] args)
        {
            FizzBuzz fb = ConfigureFizzBuzz(args);

            TryGetArgument(args, "end", out int? end);

            Console.Out.WriteLine(fb.Value);

            while (fb.Index < end || Console.In.ReadLine() == "next")
            {
                fb = fb.Next();
                Console.Out.WriteLine(fb.Value);
            }
        }

        private static FizzBuzz ConfigureFizzBuzz(string[] args)
        {
            FizzBuzzFactory factory;            
            if (TryGetArgument(args, "ruleset", out string ruleset))
            {
                factory = new FizzBuzzFactory(ruleset);
            }
            else
            {
                factory = new FizzBuzzFactory();
            }

            if (TryGetArgument(args, "begin", out int? begin))
            {
                return factory.NewInstance(begin.Value);
            }

            return factory.NewInstance();
        }

        private static bool TryGetArgument(string[] args, string name, out string value)
        {
            var index = Array.FindIndex(args, s => s == name);
            if (index >= 0)
            {
                value = args[index + 1];
                return true;
            }

            value = null;
            return false;
        }
        private static bool TryGetArgument(string[] args, string name, out int? value)
        { 
            if(TryGetArgument(args, name, out string val))
            {
                value = int.Parse(val);
                return true;
            }

            value = null;
            return false;
        }

    }
}
