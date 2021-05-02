namespace LeanFeatureFlag.Library
{
    internal class EmptyProduct : IProduct
    {
        public T Get<T>()
        {
            throw new DependencyException("There is nothing of type 'object' registered for the current scope.", typeof(T));
        }
    }
}