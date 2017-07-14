using System.Drawing;
using NUnit.Framework;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.Attributes
{
    [TestFixture]
    public class ColourAttributeTests
    {  
        [Test]
        public void ColourAttributeShouldReturnCorrectResult()
        {
            //Arrange & Action
            var result = new ColourAttribute("Green");

            //Assert
            Assert.That(result.Colour,Is.TypeOf<Color>());
            Assert.That(result.Colour, Is.EqualTo(Color.Green));
        }
    }
}
