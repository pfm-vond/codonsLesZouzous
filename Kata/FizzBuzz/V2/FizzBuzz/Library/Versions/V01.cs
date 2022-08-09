using Autofac;
using Autofac.Versioned;
using System;

namespace FizzBuzz.Library
{
    public class V01 : Module, IVersionModule,
        IIncludeFeature<HundredHelloWorldFeature>
    {
        private readonly Display display;

        public V01(Display display)
        {
            this.display = display;
        }

        public Version AvailableSince => new Version(0,1);

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterInstance(display);
        }
    }
}
