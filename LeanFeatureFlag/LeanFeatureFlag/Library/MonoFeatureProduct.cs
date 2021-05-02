namespace LeanFeatureFlag.Library
{
    internal class MonoFeatureProduct : IProduct
    {
        private IResolver feature;

        public MonoFeatureProduct(IResolver feature)
        {
            this.feature = feature;
        }

        public T Get<T>()
        {
            return feature.Get<T>();
        }
    }
}