namespace FizzBuzz.Library
{
    class Contain3PrintFizzRule : IRule
    {
        private readonly IRule rule;

        public Contain3PrintFizzRule(IRule rule)
        {
            this.rule = rule;
        }

        public string Apply(int i)
        {
            if (i.ToString().Contains("3"))
                return "Fizz";

            return rule.Apply(i);
        }
    }
}