using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class MustBeTrueAttributeTests
    {
        private MustBeTrueAttribute _attribute;

        [SetUp]
        public void SetUp()
        {
            _attribute = new MustBeTrueAttribute();
        }
        [Test]
        public void MustBeTrueAttributeShouldReturnTrue()
        {
            //Arrange & Action
            var result = _attribute.IsValid(true);

            //Assert
            Assert.That(result,Is.TypeOf<bool>());
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void MustBeTrueAttributeShouldReturnFalseOnInvalidInput()
        {
            //Arrange & Action
            var result = _attribute.IsValid(23);

            //Assert 
            Assert.That(result, Is.EqualTo(false));
        }
        [Test]
        public void MustBeTrueAttributeShouldReturnFalseOnFalseInput()
        {
            //Arrange & Action
            var result = _attribute.IsValid(false);

            //Assert 
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
