using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class ValidatePasswordLengthAttributeTests
    {
        private ValidatePasswordLengthAttribute _attribute;

        [SetUp]
        public void SetUp()
        {
            _attribute = new ValidatePasswordLengthAttribute();
        }
        [Test]
        public void ValidatePasswordLengthAttributeShouldReturnCorrectResult()
        { 
            //Action
            var result = _attribute.IsValid("AB£X%");

            //Assert
            Assert.That(result,Is.TypeOf<bool>());
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
