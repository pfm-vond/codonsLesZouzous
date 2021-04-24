using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzConsole
{
    internal class Concatenate : FizzBuzz
    {
        private IEnumerable<FizzBuzz> rules;

        public Concatenate(int index, FizzBuzzFactory factory, IEnumerable<ApplicableRule> rules)
            : base(index, factory)
        {
            this.rules = rules.Where(r => r.IsApplicable(index)).Select(r => r.application(index));
        }

        internal override string Value => string.Concat(rules.Select(r => r.Value));
    }
}