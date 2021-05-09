namespace FizzBuzz.Library
{
    internal class Div3PrintFizzRule : IRule
    {
        private readonly IRule rule;

        public Div3PrintFizzRule(IRule rule)
        {
            this.rule = rule;
        }

        public string Apply(int i)
        {
            if (i % 3 == 0)
                return "Fizz";

            return rule.Apply(i);
        }
    }
}