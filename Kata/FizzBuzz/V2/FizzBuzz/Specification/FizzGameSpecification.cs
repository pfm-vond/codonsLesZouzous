using FizzBuzz.ConsoleApp;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzz
{
    public class FizzGameSpecification
    {
        [Theory]
        [InlineData(3)]
        public void Line_having_their_index_divisible_By_3_print_Fizz(int index)
        {
            StringBuilder output = new();

            Program.OverridenMain(s => output.AppendLine(s));

            output.SplitLines()[index - 1].Should().Be("Fizz");
        }
    }
}
