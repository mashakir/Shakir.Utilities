using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Shakir.Utilities.Helpers;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Helpers
{
    [TestFixture]
    public class PropertyHelperTests
    {
        [Test]
        public void GetPropertyValueShouldReturnCorrectResult()
        {
            //Arrange
            var validationContext = new ValidationContext(new FakeObjectModel { SelectedCountryId = 23, UkCountryId = 23 });
            
            //Action
            var result = PropertyHelper.GetPropertyValue(validationContext.ObjectInstance, "SelectedCountryId");

            //Assert
            Assert.That(result, Is.TypeOf<int>());
            Assert.That(result, Is.EqualTo(23));
        }
    }
}
