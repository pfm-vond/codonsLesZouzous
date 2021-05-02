using System;

namespace LeanFeatureFlag.Library
{
    class MonoCapability<TCapability> : ICapabilityBuilder<TCapability>, IResolver
    {
        private TCapability Instance;

        public void During(IScope scope)
        {
        }

        public ICapabilityBuilder<TCapability> EnsureBy<T>()
            where T : TCapability
        {
            Instance = (TCapability)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
            return this;
        }

        public T Get<T>()
        {
            return (T)(object)Instance;
        }
    }
}
