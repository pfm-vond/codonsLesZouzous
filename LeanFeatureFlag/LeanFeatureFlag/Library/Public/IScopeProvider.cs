namespace LeanFeatureFlag.Library
{
    public interface IScopeProvider
    {
        IScope EachCall();
    }
}