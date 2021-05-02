namespace LeanFeatureFlag.Library
{
    public interface IProductBuilder
    {
        IProduct Build();
        INeedBuilder<T> AnswerNeed<T>();
    }
}