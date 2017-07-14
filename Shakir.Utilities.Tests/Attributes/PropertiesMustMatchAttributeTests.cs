using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Shakir.Utilities.Attributes;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class PropertiesMustMatchAttributeTests
    {
        private PropertiesMustMatchAttribute _attribute;
        private ValidationContext _validationContext;
        [SetUp]
        public void SetUp()
        {
            _attribute = new PropertiesMustMatchAttribute("SelectedCountryId", "UkCountryId");
        }
        [Test]
        public void PropertiesMustMatchAttributeShouldReturnCorrectResultOnNotMatchingProperties()
        {
            //Arrange
            var fakeModel = new FakeObjectModel {SelectedCountryId = 22, UkCountryId = 23};
            _validationContext = new ValidationContext(fakeModel);

            //Action 
            var result = _attribute.GetValidationResult(fakeModel, _validationContext);

            //Assert
            Assert.That(result, Is.TypeOf<ValidationResult>());
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ErrorMessage, Is.Not.EqualTo(string.Empty));
        }
        [Test]
        public void PropertiesMustMatchAttributeShouldReturnCorrectResultOnMatchingProperties()
        {
            //Arrange
            var fakeModel = new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 };
            _validationContext = new ValidationContext(fakeModel);

            //Action 
            var result = _attribute.GetValidationResult(fakeModel, _validationContext);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
