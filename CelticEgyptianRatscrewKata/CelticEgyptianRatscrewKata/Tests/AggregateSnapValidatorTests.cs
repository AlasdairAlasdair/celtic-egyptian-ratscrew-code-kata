using Autofac;
using CelticEgyptianRatscrewKata.SnapValidation;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class AggregateSnapValidatorTests
    {
        [Test]
        public void Test()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<SnapValidationModule>();
            using (var container = containerBuilder.Build())
            {
                var aggregateSnapValidator = container.Resolve<AggregateSnapValidator>();
            }
        }
    }
}
