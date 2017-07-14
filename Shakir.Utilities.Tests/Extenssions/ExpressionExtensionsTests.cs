
using NUnit.Framework;
using Shakir.Utilities.Extensions;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        [Test]
        public void PropertyNameShouldReturnCorrectResult()
        {
            //Arrange & Action
            var result = ExpressionExtensions.PropertyName<FakeObjectModel, int>(x => x.SelectedCountryId);

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("SelectedCountryId"));

        } 
    }
}
