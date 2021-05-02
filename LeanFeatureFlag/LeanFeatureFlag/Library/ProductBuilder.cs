namespace LeanFeatureFlag.Library
{
    internal class ProductBuilder : IProductBuilder
    {
        private IBuildable Need { get; set; }

        public INeedBuilder<T> AnswerNeed<T>()
        {
            var builder = new NeedBuilder<T>();
            Need = builder;
            return builder;
        }

        public IProduct Build()
        {
            if(Need != null)
            {
                return Need.Build();
            }

            return new EmptyProduct();
        }
    }
}