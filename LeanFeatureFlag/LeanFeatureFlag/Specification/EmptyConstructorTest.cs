using FluentAssertions;
using LeanFeatureFlag.Library;
using Xunit;

namespace LeanFeatureFlag
{
    public class EmptyConstructorTest
    {
        [Fact]
        public void When_a_class_with_an_empty_constructor_is_registered_the_di_return_an_instance_of_it()
        {
            IProductBuilder builder = Product.GetBuilder();

            builder.AnswerNeed<OurNeed>()
                .ViaFeature<FirstWayOfAnsweringOurNeed>();

            var product = builder.Build();

            var calculator = product.Get<ICalculator>();

            calculator.Should().BeOfType<DecimalCalculator>();
        }

        private class OurNeed { }

        private interface ICalculator { }

        private class DecimalCalculator : ICalculator { }

        private class FirstWayOfAnsweringOurNeed : IFeature<OurNeed>
        {
            public void Build(IScopeProvider scopes, IFeatureBuilder<OurNeed> feature)
            {
                feature.Need<ICalculator>()
                    .EnsureBy<DecimalCalculator>()
                    .During(scopes.EachCall());

            }
        }
    }
}
