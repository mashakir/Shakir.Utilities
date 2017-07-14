using System;
using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class CurrentDateAttributeTests
    {
        private CurrentDateAttribute _attribute;

        [SetUp]
        public void SetUp()
        {
            _attribute = new CurrentDateAttribute();
        }

        [Test]
        public void CurrentDateAttributeShouldReturnTrueIfCurrentDate()
        {
            //Arrang & Action
            var result = _attribute.IsValid(DateTime.Now);

            //Assert
            Assert.That(result, Is.TypeOf<bool>());
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CurrentDateAttributeShouldReturnFalseIfNotCurrentDate()
        {
            //Arrang & Action
            var result = _attribute.IsValid(DateTime.Now.Date.AddDays(-2));

            //Assert 
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CurrentDateAttributeShouldReturnFalseIfNullValue()
        {
            //Arrang & Action
            var result = _attribute.IsValid(null);

            //Assert 
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
