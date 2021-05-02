using FluentAssertions;
using LeanFeatureFlag.Library;
using System.Linq;
using Xunit;

namespace LeanFeatureFlag
{
    public class NonRegisterClassTest
    {
        [Fact]
        public void Requesting_a_class_that_we_never_registered_should_throw_an_exception()
        {
            IProductBuilder productBuilder = Product.GetBuilder();
            IProduct product = productBuilder.Build();

            var e = Record.Exception(() => product.Get<object>());

            e.Should().BeOfType<DependencyException>();
            e.Message.Should().Be("There is nothing of type 'object' registered for the current scope.");
            e.Data.Keys.Should().Contain("RequestedType");
            e.Data["RequestedType"].Should().Be(typeof(object));
        }
    }
}
