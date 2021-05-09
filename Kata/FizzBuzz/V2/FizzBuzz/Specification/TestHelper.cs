using System;
using System.Text;

namespace FizzBuzz
{
    public static class TestHelper
    {
        public static string[] SplitLines(this StringBuilder sb)
        {
            return sb.ToString().Trim().Split(Environment.NewLine);
        }
    }
}
