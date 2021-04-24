using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FizzBuzzConsole.Specification
{
    [TestClass]
    public class ForBaseRule
    {
        private StringWriter OutContent { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            OutContent = new StringWriter();
            Console.SetOut(OutContent);
        }

        [TestMethod]
        public void OnStart_Console_Should_Display_1()
        {
            Console.SetIn(new StringReader($"{Environment.NewLine}"));

            Program.Main(new string[0]);

            OutputShouldBe(
@"1
");
        }

        public void StartFizzBuzzConsoleWith(string begin, string consoleInput)
        {
            Console.SetIn(new StringReader(consoleInput));

            Program.Main(new string[] { "begin", begin.ToString() });
        }

        [TestMethod]
        public void OnStart_with_begin_parameter_Console_should_display_it()
        {
            StartFizzBuzzConsoleWith("4", $"{Environment.NewLine}");

            OutputShouldBe(
@"4
");
        }

        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(7, 8)]
        public void after_displaying_a_value_entering_next_on_prompt_display_the_following_value(int begin, int followingValue)
        {
            StartFizzBuzzConsoleWith(begin.ToString(), $"next{Environment.NewLine}");

            OutputShouldBe(
@$"{begin}
{followingValue}
");
        }

        [TestMethod]
        public void instead_of_displaying_number_divisible_by_3_display_Fizz()
        {
            StartFizzBuzzConsoleWith(2.ToString(), $"next{Environment.NewLine}");

            OutputShouldBe(
@"2
Fizz
");
        }

        [TestMethod]
        public void when_begining_By_a_divisible_by_3_index_console_should_display_Fizz()
        {
            StartFizzBuzzConsoleWith("3", $"{Environment.NewLine}");

            OutputShouldBe(
@"Fizz
");
        }

        [TestMethod]
        public void instead_of_displaying_number_divisible_by_5_display_Buzz()
        {
            StartFizzBuzzConsoleWith("5", Environment.NewLine);

            OutputShouldBe(
@"Buzz
");
        }

        [TestMethod]
        public void OnStart_with_end_parameter_Console_should_display_all_value_while_less_or_equal_than_it()
        {
            Console.SetIn(new StringReader(@""));

            Program.Main(new string[] { "end", "14" });

            OutputShouldBe(
@"1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
"
                );
        }

        [TestMethod]
        public void when_begining_By_a_divisible_by_3_and_5_index_console_should_display_FizzBuzz()
        {
            StartFizzBuzzConsoleWith("15", Environment.NewLine);

            OutputShouldBe(
@"FizzBuzz
");
        }

        private void OutputShouldBe(string output)
        {
            Assert.AreEqual(output, OutContent.ToString());
        }
    }
}
