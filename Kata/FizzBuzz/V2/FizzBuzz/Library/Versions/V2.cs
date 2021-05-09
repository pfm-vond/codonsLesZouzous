using Autofac;
using Autofac.Versioned;
using System;

namespace FizzBuzz.Library
{
    public class V2 : Module, IVersionModule,
        IIncludeFeature<FizzFeature>
    {
        public Version AvailableSince => new Version(2,0);
    }
}
