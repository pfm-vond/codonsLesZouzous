namespace LeanFeatureFlag.Library
{
    public interface IProduct
    {
        T Get<T>();
    }
}