using Xunit;
using FluentAssertions;
using CodingGames.Specification;
using System.Numerics;

namespace CodingGames.TheResistance
{
    public class CodingGameSpecification
    {

        [Fact]
        public void DétectionCorrecteDunelettre()
        {
            Run(
                "-.-",
                "6",
                "A",
                "B",
                "C",
                "HELLO",
                "K",
                "WORLD")
                .Should().Be(1);
        }

        [Fact]
        public void DétectionCorrecteDunmot()
        {
            Run(
                "--.-------..",
                "5",
                "GOD",
                "GOOD",
                "MORNING",
                "G",
                "HELLO")
                .Should().Be(1);
        }

        BigInteger Run(params string[] lines)
        {
            var interact = new TestConsoleInteractor(lines);
            return new Solver().Entry(interact);
        }
    }
}

