using NUnit.Framework;
using Shakir.Utilities.Extensions;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void ToLowerAndRemoveSpacesShouldReturnCorrectResult()
        { 
            //Arrange
            const string testString = "Test String ";
            
            //Action
            var result = testString.ToLowerAndRemoveSpaces();

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("teststring"));
        }
        [Test]
        public void ToLowerAndTrimShouldReturnCorrectResult()
        {
            //Arrange
            const string testString = " TestString ";

            //Action
            var result = testString.ToLowerAndTrim();

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("teststring"));
        }
        [Test]
        public void TrimTextShouldReturnCorrectResult()
        {
            //Arrange
            const string testString = " Test@{}$\"String ";

            //Action
            var result = testString.TrimText(2, "string");

            //Assert
            Assert.That(result, Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("string"));
        }
        [Test]
        public void TrimTextShouldReturnCorrectResultIfStringIsEmpty()
        {
            //Arrange
            const string testString = "  ";

            //Action
            var result = testString.TrimText(2, "st");

            //Assert 
            Assert.That(result, Is.EqualTo("  "));
        } 

        [Test]
        public void RemoveSpecialCharactersShouldReturnCorrectResult()
        {
            //Arrange
            const string testString = "38&*($%&3";

            //Action
            var result = testString.RemoveSpecialCharacters();

            //Assert 
            Assert.That(result, Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("383"));
        }
        [Test]
        public void ConvertToShouldReturnCorrectResult()
        {
            //Arrange
            const string testString = "10.03";

            //Action
            var result = testString.ConvertTo<decimal>();

            //Assert 
            Assert.That(result, Is.TypeOf<decimal>());
            Assert.That(result, Is.EqualTo(10.03));
        }
        [Test]
        public void ConvertToShouldReturnCorrectResultIfTypeIsInt()
        {
            //Arrange
            const string testString = "10";

            //Action
            var result = testString.ConvertTo<int>();

            //Assert 
            Assert.That(result, Is.TypeOf<int>());
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void ConvertToShouldReturnNullIfCannotConvertToSpecifiedType()
        {
            //Arrange
            const string testString = "ab";

            //Action
            var result = testString.ConvertTo<decimal>();

            //Assert   
            Assert.IsNull(result);
        }
        [Test]
        public void MakeValidFileNameShouldReturnNullIfCannotConvertToSpecifiedType()
        {
            //Arrange
            const string testString = "T**S.txt";

            //Action
            var result = testString.MakeValidFileName();

            //Assert   
            Assert.That(result,Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("TS.txt"));
        }
        [Test]
        public void UrlPathEncodeShouldReturnNullIfInputIsNull()
        {
            //Arrange & Acrion
            var result = ((string) null).UrlPathEncode();

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void UrlPathEncodeShouldEncodeTextProperly()
        {
            //Arrange
            const string expectedUrl = @"/ABC/ABC%20%7CABC/DEF%20%7CDEF";

            //Action
            var result = (@"/ABC/ABC .ABC/DEF .DEF").UrlPathEncode();

            //Assert
            Assert.That(result, Is.EqualTo(expectedUrl));
        }
    }
}
