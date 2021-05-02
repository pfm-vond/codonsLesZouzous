using System;

namespace LeanFeatureFlag.Library
{
    public static class Product
    {
        public static IProductBuilder GetBuilder()
        {
            return new ProductBuilder();
        }
    }
}
