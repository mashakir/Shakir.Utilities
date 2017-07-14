using System;
using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    public class DateFormatValidatorAttributeTests
    {
        private DateFormatValidatorAttribute _ukDateFormatValidator;

        [SetUp]
        public void SetUp()
        {
            _ukDateFormatValidator = new DateFormatValidatorAttribute();
        }

        [Test]
        public void ValidatorShouldWorkWithNullableDateTimeInput()
        { 
            //Arrange & Action
            var result = _ukDateFormatValidator.IsValid((DateTime?)DateTime.Now);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidatorShouldWorkWithDateTimeInput()
        {
            //Arrange & Action
            var result = _ukDateFormatValidator.IsValid(DateTime.Now);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidatorShouldReturnTrueForValidDate()
        {
            //Arrange & Action
            var result = _ukDateFormatValidator.IsValid("01/01/1970");

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidatorShouldReturnFalseForInValidDate()
        {
            //Arrange & Action
            var result = _ukDateFormatValidator.IsValid("29/02/1981");

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
