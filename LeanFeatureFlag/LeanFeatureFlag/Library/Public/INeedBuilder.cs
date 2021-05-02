namespace LeanFeatureFlag.Library
{
    public interface INeedBuilder<TNeed>
    {
        void ViaFeature<TFeature>()
            where TFeature : IFeature<TNeed>, new();
    }
}