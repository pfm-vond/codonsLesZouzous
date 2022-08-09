using Xunit;
using FluentAssertions;
using CodingGames.Specification;
using System.Numerics;
using System.Collections.Generic;
using System;

namespace CodingGames.BouncingBarry
{
    public class CodingGameSpecification
    {
        [Fact]
        public void Meandering()
        {
            SolveAsString(
                "E S W",
                "4 3 2")
                .Should().Be(@"####
...#
...#
.###");
        }

        [Fact]
        public void Crossing()
        {
            SolveAsString(
                "S W W S E N W",
                "5 2 1 2 5 4 4")
                .Should().Be(@"...#..
...#..
.##.##
...#.#
####.#
#....#
######");
        }

        IEnumerable<string> Solve(params string[] lines)
        {
            var interact = new TestConsoleInteractor(lines);
            return new Solver(new Problem(interact)).Solve();
        }
        string SolveAsString(params string[] lines)
        {
            return string.Join(Environment.NewLine, Solve(lines));
        }
    }
}

