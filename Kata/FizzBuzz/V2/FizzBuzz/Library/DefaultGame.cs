namespace FizzBuzz.Library
{
    internal class DefaultGame : IFizzBuzzGame
    {
        private Display display;
        private readonly IRule ruleToApply;

        public DefaultGame(Display display, IRule ruleToApply)
        {
            this.display = display;
            this.ruleToApply = ruleToApply;
        }

        public void Play()
        {
            for (int i = 1; i <= 100; i++)
                display(ruleToApply.Apply(i));
        }
    }
}