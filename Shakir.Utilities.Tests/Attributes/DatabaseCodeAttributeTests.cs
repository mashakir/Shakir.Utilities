using NUnit.Framework; 
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class DatabaseCodeAttributeTests
    { 
        [Test]
        public void DatbaseAttributShouldReturnCorrectType()
        {
            //Arrange
            const string code = "124";
            //Action
            var result = new DatabaseCodeAttribute(code);

            //Assert
            Assert.That(result.Code,Is.TypeOf<string>());
        }
        [Test]
        public void DatbaseAttributShouldReturnCorrectResult()
        {
            //Arrange
            const string code = "124";
            //Action
            var result = new DatabaseCodeAttribute(code);

            //Assert
            Assert.That(result.Code, Is.EqualTo(code));
        }
    }
}
