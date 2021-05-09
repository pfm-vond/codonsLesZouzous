using System;

namespace FizzBuzzConsole
{
    public record ApplicableRule(Func<int, bool> IsApplicable, Func<int, FizzBuzz> application);
}