using System;

namespace LeanFeatureFlag.Library
{
    class MonoCapability<TCapability> : ICapabilityBuilder<TCapability>, IResolver
    {
        private TCapability Instance;

        public void During(IScope scope)
        {
        }

        public ICapabilityBuilder<TCapability> EnsureBy<TImplementation>()
            where TImplementation : TCapability
        {
            Instance = (TCapability)typeof(TImplementation).GetConstructor(new Type[0]).Invoke(new object[0]);
            return this;
        }

        public T Get<T>()
        {
            return (T)(object)Instance;
        }
    }
}
