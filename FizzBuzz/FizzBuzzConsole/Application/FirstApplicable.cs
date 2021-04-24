using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzConsole.Application
{
    class FirstApplicable : FizzBuzz
    {
        private IEnumerable<ApplicableRule> rules;

        public FirstApplicable(int index, FizzBuzzFactory factory, IEnumerable<ApplicableRule> rules) : base(index, factory)
        {
            this.rules = rules.Where(r => r.IsApplicable(Index));
        }

        internal override string Value => rules.First().application(Index).Value;
    }
}
