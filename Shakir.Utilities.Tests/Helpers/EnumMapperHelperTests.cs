 using NUnit.Framework;
 using Shakir.Utilities.Helpers; 

namespace Shakir.Utilities.Tests.Helpers
{
    [TestFixture]
    public class EnumMapperHelperTests
    { 
        [Test]
        public void EnumMapperHelperShouldReturnCorrectProperties()
        {
            //Arrange & Action
            var result = new EnumMapperHelper("Test", "Description", "DC");

            //Assert
            Assert.That(result.Enum, Is.EqualTo("Test"));
            Assert.That(result.Description, Is.EqualTo("Description"));
            Assert.That(result.DatabaseCode, Is.EqualTo("DC")); 
        } 
    }
}
