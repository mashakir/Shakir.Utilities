using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class DisplayNameAttributeTests
    { 
        [Test]
        public void DisplayNameShouldReturnCorrectResult()
        {
            //Arrange
            const string displayName = "Display Name";

            //Action
            var result = new DisplayNameAttribute(displayName);
            
            //Assert
            Assert.That(result.DisplayName,Is.TypeOf<string>());
            Assert.That(result.DisplayName,Is.EqualTo(displayName));
        }
    }
}
