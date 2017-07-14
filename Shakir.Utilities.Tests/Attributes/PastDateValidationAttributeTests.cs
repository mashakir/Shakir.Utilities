using System;
using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class PastDateValidationAttributeTests
    {
        private PastDateValidationAttribute _attribute;

        [SetUp]
        public void SetUp()
        {
            _attribute = new PastDateValidationAttribute();
        }
        [Test]
        public void PastDateValidationAttributeShouldReturnTrueIfDateIsPast()
        {
            //Arrange
            var datetime = DateTime.Now.AddDays(-1);
            
            //Action
            var result = _attribute.IsValid(datetime);

            //Assert
            Assert.That(result,Is.TypeOf<bool>());
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void PastDateValidationAttributeShouldReturnFalseOnNoPastDate()
        {
            //Arrange
            var datetime = DateTime.Now;

            //Action
            var result = _attribute.IsValid(datetime);

            //Assert
            Assert.That(result, Is.TypeOf<bool>());
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
