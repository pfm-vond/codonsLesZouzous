using FizzBuzz.ConsoleApp;
using FluentAssertions;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace FizzBuzz
{
    public class GeneralSpecification
    {
        [Fact]
        public void FizzBuzz_should_have_an_overidable_console()
        {
            StringBuilder output = new();
            StringBuilder overridedOutput = new();
            Console.SetOut(new StringWriter(output));

            Program.Main();
            Program.OverridenMain(s => overridedOutput.AppendLine(s));

            output.ToString().Should().Be(overridedOutput.ToString());
        }

        [Fact]
        public void Playing_fizzBuzz_prints_the_numbers_from_1_to_100()
        {
            StringBuilder output = new();

            Program.OverridenMain(s => output.AppendLine(s));

            output.SplitLines().Should().HaveCount(100);
        }
    }
}
