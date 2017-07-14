using NUnit.Framework;
using Shakir.Utilities.Attributes;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class LocalisedDescriptionAttributeTests
    {
        [Test]
        public void LocalisedDescriptionAttributeShouldReturnCorrectResult()
        {
            //Arrange & Action
            var result = new LocalisedDescriptionAttribute("Description", typeof(FakeResource));

            //Assert
            Assert.That(result.Description, Is.TypeOf<string>());
            Assert.That(result.Description, Is.EqualTo(FakeResource.Description));
        }
    }
}
