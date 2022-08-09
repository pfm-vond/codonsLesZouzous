using CodingGames.ConsoleApp;
using System;
using System.Numerics;

namespace CodingGames.TheResistance.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger value = new Solver().Entry(new ConsoleInteractor());

            Console.WriteLine(value);
        }
    }
}
