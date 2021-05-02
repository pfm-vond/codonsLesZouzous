using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanFeatureFlag.Library
{
    class NeedBuilder<T> : INeedBuilder<T>, IBuildable
    {
        private IFeature<T> Feature;

        public IProduct Build()
        {
            var builtFeature = new Feature<T>();
            var scopeProvider = new ScopeProvider();
            Feature.Build(scopeProvider, builtFeature);

            return new MonoFeatureProduct(builtFeature);
        }

        public void ViaFeature<TFeature>()
            where TFeature : IFeature<T>, new()
        {
            Feature = new TFeature();
        }
    }
}
