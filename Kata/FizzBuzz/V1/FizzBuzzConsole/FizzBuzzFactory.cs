using FizzBuzzConsole.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzConsole
{
    public class FizzBuzzFactory
    {
        private const int BEGIN = 1;
        private ApplicableRule Rule { get; }

        public FizzBuzzFactory(string rulesetToload = null)
        {
            if (rulesetToload == "stage2")
            {
                Rule = Stage2Rule();
            }
            else
            {
                Rule = BaseRule();
            }
        }

        private ApplicableRule Stage2Rule()
        {
            var stage2Rules = new List<ApplicableRule>
                {
                    BaseRule(),
                    new ApplicableRule(index => index.ToString().Contains("3"), index => new ReplaceDigit(index, this, 3, "Fizz"))
                };

            return new ApplicableRule(index => stage2Rules.Any(r => r.IsApplicable(index)), index => new FirstApplicable(index, this, stage2Rules));
        }

        private ApplicableRule BaseRule()
        {
            var rules = new List<ApplicableRule>{
                new ApplicableRule(index => index % 3 == 0, index => new DisplayStringConstant(index, this, "Fizz")),
                new ApplicableRule(index => index % 5 == 0, index => new DisplayStringConstant(index, this, "Buzz")),
            };

            return new ApplicableRule(index => rules.Any(r => r.IsApplicable(index)), index => new Concatenate(index, this, rules));
        }

        public FizzBuzz NewInstance(int begin = BEGIN)
        {
            if (Rule.IsApplicable(begin))
            {
                return Rule.application(begin);
            }

            return new DisplayIndex(begin, this);
        }
    }
}
