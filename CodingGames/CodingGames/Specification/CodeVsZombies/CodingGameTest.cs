using Xunit;
using FluentAssertions;
using CodingGames.Specification;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit.Abstractions;

namespace CodingGames.CodeVsZombies
{
    public class CodingGameSpecification
    {
        public CodingGameSpecification(ITestOutputHelper output)
        {
            this.Output = output;
        }

        public ITestOutputHelper Output { get; }

        [Fact]
        public void Simple()
        {
            var positions = Run(
                @"0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 8999 8250 8599",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 8599 8250 8199",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 8199 8250 7799",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 7799 8250 7399",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 7399 8250 6999",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 6999 8250 6599",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 6599 8250 6199",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 6199 8250 5799",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 5799 8250 5399",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 5399 8250 4999",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 4999 8250 4599",
                "0 0",
                "1",
                "0 8250 4500",
                "1",
                "0 8250 4599 8250 4500");

            foreach (var position in positions)
                Output.WriteLine(position.ToString());

            // can't be tested without implementing the simulation so not a very usefull class :'(
        }

        IEnumerable<Position> Run(params string[] lines)
        {
            var interact = new TestConsoleInteractor(lines);
            Solver solver = new Solver(new Problem(interact));
            return solver.Solve();
        }
    }
}

