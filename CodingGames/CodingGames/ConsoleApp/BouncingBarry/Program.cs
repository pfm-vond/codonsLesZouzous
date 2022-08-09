using CodingGames.ConsoleApp;
using System;
using System.Collections;

namespace CodingGames.BouncingBarry.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver(new Problem(new ConsoleInteractor()));
            IEnumerable solution = solver.Solve();

            foreach (var current in solution)
                Console.WriteLine(current);
        }
    }
}
