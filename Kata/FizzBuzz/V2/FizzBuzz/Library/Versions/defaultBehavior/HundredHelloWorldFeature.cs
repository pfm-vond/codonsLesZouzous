using Autofac;
using Autofac.Versioned;

namespace FizzBuzz.Library
{
    internal class HundredHelloWorldFeature : Module, IFeatureModule
    {
        public string FeatureName => "defaultBehavior";

        public bool ActiveByDefault => true;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DummyGame>().As<IFizzBuzzGame>();
        }
    }
}