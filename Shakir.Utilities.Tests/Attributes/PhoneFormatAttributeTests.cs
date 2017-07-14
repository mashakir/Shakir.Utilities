using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Shakir.Utilities.Attributes;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class PhoneFormatAttributeTests
    {
        #region Member Variable

        private PhoneFormatAttribute _attribute;
        private ValidationContext _validationContext;
        #endregion

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _attribute = new PhoneFormatAttribute
            {
                SelectedCountryPropertyName = "SelectedCountryId",
                DefaultCountryPropertyName = "UkCountryId" 
            };
        }
        #endregion

        #region IsValid Tests
        [Test]
        public void IsValidShouldReturnCorrectType()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("32", _validationContext);

            //Assert
            Assert.That(result, Is.TypeOf<ValidationResult>());
        }
        [Test]
        public void IsValidShouldReturnNullIfUkIsSelected()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("0113258456", _validationContext);

            //Assert
            Assert.That(result, Is.Null);
        }
        [Test]
        public void IsValidShouldNotReturnNullIfUkIsSelected()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("0113", _validationContext);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ErrorMessage, Is.Not.EqualTo(string.Empty));
        }
        [Test]
        public void IsValidShouldReturnNullIfUkIsNotSelected()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 199, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("011333", _validationContext);

            //Assert
            Assert.That(result, Is.Null);
        }
        [Test]
        public void IsValidShouldNotReturnNullIfUkIsNotSelected()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 199, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("dsf", _validationContext);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ErrorMessage, Is.Not.EqualTo(string.Empty));
        }
        [Test]
        public void IsValidShouldReturnErrorIfUkIsSelectedAndWrongPhoneNumber()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("4568ss", _validationContext);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ErrorMessage, Is.Not.EqualTo(string.Empty));
        }
        [Test]
        public void IsValidShouldReturnErrorIfUkIsSelectedAndNoPhoneNumber()
        {
            //Arrange 
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult(null, _validationContext);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ErrorMessage, Is.Not.EqualTo(string.Empty));
        }
        [Test]
        public void IsValidShouldReturnNullIfUkIsSelectedAndCorrectPhoneNumber()
        {
            //Arrange
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("0113283245", _validationContext);

            //Assert
            Assert.That(result, Is.Null);
        }
        [Test]
        public void IsValidShouldReturnNullIfCorrectPostCodeWithSpace()
        {
            //Arrange 
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("0113 245852", _validationContext);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void IsValidShouldReturnNullIfNonUkNumberWithSpacesAndDigits()
        {
            //Arrange 
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 100, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("01 13 24 58 52", _validationContext);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void IsValidShouldReturnNotNullIfNonUkNumberWithIncorrectLetter()
        {
            //Arrange 
            _validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 100, UkCountryId = 23 });

            //Action
            var result = _attribute.GetValidationResult("01 13 24 58 52a", _validationContext);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        #endregion  
         
    }
}
