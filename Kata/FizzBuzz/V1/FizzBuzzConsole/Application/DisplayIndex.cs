namespace FizzBuzzConsole
{
    internal class DisplayIndex : FizzBuzz
    {
        public DisplayIndex(int index, FizzBuzzFactory factory) : base(index, factory) {}

        internal override string Value => Index.ToString();
    }
}
