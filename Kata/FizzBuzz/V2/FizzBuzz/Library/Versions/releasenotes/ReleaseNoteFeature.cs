using Autofac;
using Autofac.Core.Registration;
using Autofac.Versioned;
using Microsoft.Extensions.Configuration;

namespace FizzBuzz.Library
{
    public class ReleaseNoteFeature : Module, IFeatureModule, IFeatureDescription
    {
        private readonly IConfiguration configuration;

        public ReleaseNoteFeature(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string FeatureName => "releasenote";

        public string Description => "Using parameter 'notes' allow you to display a small feature notes.";

        public bool ActiveByDefault => true;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterInstance(configuration);
            builder.RegisterDecorator<ReleaseNoteGame, IFizzBuzzGame>();
        }
    }
}
