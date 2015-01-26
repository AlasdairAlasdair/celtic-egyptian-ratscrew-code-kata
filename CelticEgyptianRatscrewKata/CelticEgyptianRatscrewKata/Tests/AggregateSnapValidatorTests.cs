using System.Collections.Generic;
using System.Linq;
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
                var listOfValidators = container.Resolve<IEnumerable<ISnapValidator>>();
                Assert.AreEqual(3, listOfValidators.Select(x => x.GetType()).Distinct().ToList().Count);
            }
        }
    }
}
