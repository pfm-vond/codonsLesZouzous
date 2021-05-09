namespace FizzBuzz.Library
{
    internal class PrintItselfRule : IRule
    {
        public string Apply(int i)
        {
            return i.ToString();
        }
    }
}