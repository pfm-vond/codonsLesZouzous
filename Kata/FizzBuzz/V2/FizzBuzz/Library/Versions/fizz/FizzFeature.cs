using Autofac;
using Autofac.Core.Registration;
using Autofac.Versioned;

namespace FizzBuzz.Library
{
    public class FizzFeature : Module, IFeatureModule
    {
        public string FeatureName => "fizz";

        public bool ActiveByDefault => true;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterDecorator<Div3PrintFizzRule, IRule>();
            builder.RegisterDecorator<Contain3PrintFizzRule, IRule>();
        }
    }
}
