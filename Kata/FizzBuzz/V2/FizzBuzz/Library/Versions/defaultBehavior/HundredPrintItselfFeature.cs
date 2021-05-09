using Autofac;
using Autofac.Versioned;

namespace FizzBuzz.Library
{
    internal class HundredPrintItselfFeature : Module, IFeatureModule
    {
        public string FeatureName => "defaultBehavior";

        public bool ActiveByDefault => true;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DefaultGame>().As<IFizzBuzzGame>();
            builder.RegisterType<PrintItselfRule>().As<IRule>();
        }
    }
}