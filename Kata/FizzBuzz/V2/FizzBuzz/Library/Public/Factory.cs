using Autofac;
using Autofac.Versioned;
using Microsoft.Extensions.Configuration;
using System;

namespace FizzBuzz.Library
{
    public class Factory
    {
        public delegate void Display(string line);

        private IContainer Container { get; }

        public Factory(Display display, IConfiguration cfg)
        {
            ContainerBuilder cb = new();
            string v = cfg["Version"];

            cb.RegisterAssemblyVersions(
                GetType().Assembly,
                v,
                c => c.RegisterInstance(display),
                c => c.RegisterInstance(cfg));

            Container = cb.Build();
        }

        public IFizzBuzzGame GetGame()
        {
            return Container.Resolve<IFizzBuzzGame>();
        }
    }
}
