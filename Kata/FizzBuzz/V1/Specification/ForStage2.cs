using FizzBuzzConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FizzBuzzConsole.Specification
{
    [TestClass]
    public class ForStage2
    {
        private StringWriter OutContent { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            OutContent = new StringWriter();
            Console.SetOut(OutContent);
        }

        [TestMethod]
        public void the_index_13_should_display_1Fizz()
        {
            StartFizzBuzzConsoleWith("13", Environment.NewLine);

            OutputShouldBe(@"1Fizz
");
        }

        [TestMethod]
        public void the_index_3_should_display_Fizz()
        {
            StartFizzBuzzConsoleWith("3", Environment.NewLine);

            OutputShouldBe(@"Fizz
");
        }

        public void StartFizzBuzzConsoleWith(string begin, string consoleInput)
        {
            Console.SetIn(new StringReader(consoleInput));

            Program.Main(new string[] { "ruleset", "stage2", "begin", begin.ToString() });
        }

        private void OutputShouldBe(string output)
        {
            Assert.AreEqual(output, OutContent.ToString());
        }
    }
}
