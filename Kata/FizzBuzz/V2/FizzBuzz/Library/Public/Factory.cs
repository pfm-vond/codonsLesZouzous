using Autofac;
using Autofac.Versioned;
using Microsoft.Extensions.Configuration;
using System;

namespace FizzBuzz.Library
{
    public delegate void Display(string line);
    
    public record Dependencies(Display Output, IConfiguration Config);

    public class Factory : IServiceProvider
    {
        private IContainer Container { get; }

        public Factory(Dependencies d)
        {
            ContainerBuilder cb = new();
            string v = d.Config["Version"];

            cb.RegisterAssemblyVersions(
                GetType().Assembly,
                v,
                c => c.RegisterInstance(d.Output),
                c => c.RegisterInstance(d.Config));

            Container = cb.Build();
        }

        public IFizzBuzzGame GetGame()
        {
            return Container.Resolve<IFizzBuzzGame>();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
