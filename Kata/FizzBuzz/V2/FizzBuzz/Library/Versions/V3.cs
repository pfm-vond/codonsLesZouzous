using Autofac;
using Autofac.Versioned;
using Microsoft.Extensions.Configuration;
using System;

namespace FizzBuzz.Library.Versions
{
    public class V3 : Module, IVersionModule,
        IIncludeFeature<ReleaseNoteFeature>
    {
        public Version AvailableSince => new Version(3, 0);
    }
}
