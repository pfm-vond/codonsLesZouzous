namespace LeanFeatureFlag.Library
{
    public interface ICapabilityBuilder<TCapability>
    {
        ICapabilityBuilder<TCapability> EnsureBy<T>()
            where T : TCapability;

        void During(IScope scope);
    }
}