namespace FizzBuzzConsole
{
    internal class DisplayStringConstant : FizzBuzz
    {
        private readonly string ConstValue;

        public DisplayStringConstant(int begin, FizzBuzzFactory factory, string value)
            : base(begin, factory)
        {
            this.ConstValue = value;
        }

        internal override string Value => ConstValue;
    }
}