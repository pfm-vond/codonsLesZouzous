namespace FizzBuzzConsole
{
    internal class ReplaceDigit : FizzBuzz
    {
        private readonly string ToReplace;
        private readonly string ReplaceBy;

        public ReplaceDigit(int index, FizzBuzzFactory factory, int toReplace, string replaceBy) : base(index, factory)
        {
            ToReplace = toReplace.ToString();
            ReplaceBy = replaceBy;
        }


        internal override string Value => Index.ToString().Replace(ToReplace, ReplaceBy);
    }
}