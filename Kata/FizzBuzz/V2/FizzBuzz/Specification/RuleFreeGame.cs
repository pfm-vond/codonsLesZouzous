using FizzBuzz.ConsoleApp;
using FluentAssertions;
using System.Text;
using Xunit;

namespace FizzBuzz
{
    public class RuleFreeGame
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void always_display_number_as_itself(int index)
        {
            StringBuilder output = new();

            Program.OverridenMain(s => output.AppendLine(s), "-fizz", "false");

            output.SplitLines()[index-1].Should().Be(index.ToString());
        }
    }
}
