using Autofac;
using Autofac.Versioned;
using System;

namespace FizzBuzz.Library
{
    public class V1 : Module, IVersionModule,
        IIncludeFeature<HundredPrintItselfFeature>
    {
        public Version AvailableSince => new Version(1, 0);
    }
}
