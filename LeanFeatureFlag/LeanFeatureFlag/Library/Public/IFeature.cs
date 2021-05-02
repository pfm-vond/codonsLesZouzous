namespace LeanFeatureFlag.Library
{
    public interface IFeature<T>
    {
        void Build(IScopeProvider scopes, IFeatureBuilder<T> need);
    }
}
