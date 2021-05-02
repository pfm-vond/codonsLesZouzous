using System;

namespace LeanFeatureFlag.Library
{
    internal class Feature<TNeed> : IResolver, IFeatureBuilder<TNeed>
    {
        public ICapabilityBuilder<TCapability> Need<TCapability>()
        {
            var result = new MonoCapability<TCapability>();
            Resolver = result;
            return result;
        }

        protected IResolver Resolver;

        public T Get<T>()
        {
            return Resolver.Get<T>();
        }
    }
}