namespace FizzBuzzConsole
{
    public abstract class FizzBuzz
    {
        private FizzBuzzFactory Factory { get; }

        internal FizzBuzz(int index, FizzBuzzFactory factory)
        {
            Index = index;
            Factory = factory;
        }

        protected internal int Index = 1;

        internal abstract string Value { get; }

        internal FizzBuzz Next()
        {
            int nextIndex = this.Index + 1;

            return Factory.NewInstance(nextIndex);
        }
    }
}
