using FizzBuzz.Library;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace FizzBuzz.ConsoleApp
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            OverridenMain(Console.WriteLine, args);
        }

        public static void OverridenMain(Factory.Display writeLine, params string[] args)
        {
            IConfiguration cfg = new ConfigurationBuilder()
                .AddCommandLine(args, new Dictionary<string, string> {
                    { "-version", "Version" },
                    { "-fizz", "fizz" },
                    { "-notes", "notes" }
                })
                .Build();

            new Factory(writeLine, cfg)
                .GetGame()
                .Play();
        }
    }
}
