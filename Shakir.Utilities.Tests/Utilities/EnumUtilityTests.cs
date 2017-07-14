using System;
using NUnit.Framework;
using Shakir.Utilities.Tests.FakeObjects;
using Shakir.Utilities.Utiltiies;

namespace Shakir.Utilities.Tests.Utilities
{
    [TestFixture]
    public class EnumUtilityTests
    {
        [Test]
        public void GetEnumShouldReturnCorrectResultOnMatchingProeprty()
        {
            //Arrange & Action
            var result = EnumUtility.GetEnum<FakeEnum>("Ok");

            //Assert
            Assert.That(result,Is.TypeOf<FakeEnum>());
            Assert.That(result, Is.EqualTo(FakeEnum.Ok));
        }
        [Test]
        public void GetEnumShouldReturnThrowExceptionOnNotMatchingEnumProperty()
        {
            //Arrange, Action & Assert
            Assert.Throws<ArgumentException>(() => EnumUtility.GetEnum<FakeEnum>("Okay")); 
        }
        [Test]
        public void GetEnumShouldReturnCorrectResultOnNotMatchingHashcode()
        {
            //Arrange
            const int hashCode = 2001;

            //Action & Assert
            Assert.Throws<ArgumentException>(() => hashCode.GetEnum<FakeEnum>());
        }
        [Test]
        public void GetEnumShouldReturnCorrectResultOnMatchingHashcode()
        {
            //Arrange
            const int hashCode = 200;

            //Action
            var result = hashCode.GetEnum<FakeEnum>();

            //Assert
            Assert.That(result, Is.TypeOf<FakeEnum>());
            Assert.That(result, Is.EqualTo(FakeEnum.Ok));
        } 
        
    }
}
