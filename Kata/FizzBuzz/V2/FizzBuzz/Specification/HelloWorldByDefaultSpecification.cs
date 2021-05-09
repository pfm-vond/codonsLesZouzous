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
    public class HelloWorldByDefaultSpecification
    {
        [Xunit.Theory]
        [Xunit.InlineData(1)]
        public void MyTestMethod(int index)
        {
            StringBuilder output = new();

            Program.OverridenMain(s => output.AppendLine(s), "-version", "0.1");

            output.SplitLines()[index-1].Should().Be("Hello World !");
        }
    }
}
