using System;
using System.Drawing; 
using NUnit.Framework; 
using Shakir.Utilities.Extensions;
using Shakir.Utilities.Tests.FakeObjects;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        #region Description

        [Test]
        public void DescriptionShouldReturnDescriptionIfAvailable()
        {
            //Action
            var result = FakeEnum.Ok.Description();

            //Assert
            Assert.That(result, Is.EqualTo("Ok"));
        }

        [Test]
        public void DescriptionShouldReturnEnumValueAsStringIfNoAttributeIsAvailable()
        {
            //Action
            var result = FakeEnum.NoDescription.Description();

            //Assert
            Assert.That(result, Is.EqualTo("NoDescription"));
        }

        #endregion

        #region DatabaseCode
        [Test]
        public void DatabaseCodeShouldReturnDescriptionIfAvailable()
        {
            //Action
            var result = FakeEnum.Ok.DatabaseCode();

            //Assert
            Assert.That(result, Is.EqualTo("113"));
        }

        [Test]
        public void DatabaseCodeShouldReturnNullIfNoAttributeIsAvailable()
        {
            //Action
            var result = FakeEnum.NoDescription.DatabaseCode();

            //Assert
            Assert.IsNull(result);
        }

        #endregion

        #region Colour
        [Test]
        public void ColourShouldReturnDescriptionIfAvailable()
        {
            //Action
            var result = FakeEnum.Ok.Colour();

            //Assert
            Assert.That(result.Name, Is.EqualTo("Black"));
        }

        [Test]
        public void ColourShouldReturnThrowAnExceptionIfNoAttributeIsAvailable()
        {
            //Action && Assert
            Assert.Throws<ArgumentNullException>(() => FakeEnum.NoDescription.Colour());
        }

        #endregion

        #region BrushColour
        [Test]
        public void BrushColourShouldReturnCorrectType()
        {
            //Action
            var result = FakeEnum.Ok.BrushColour();

            //Assert
            Assert.That(result, Is.TypeOf<SolidBrush>());
        }

        [Test]
        public void BrushColourShouldReturnThrowAnExceptionIfNoAttributeIsAvailable()
        {
            //Action && Assert
            Assert.Throws<ArgumentNullException>(() => FakeEnum.NoDescription.BrushColour());
        }

        #endregion

        #region ParseEnum
        [Test]
        public void ParseEnumShouldReturnEnumIfAvailable()
        {
            //Action
            var result = EnumExtensions.ParseEnum<FakeEnum>("Ok");

            //Assert
            Assert.That(result, Is.EqualTo(FakeEnum.Ok));
        }

        [Test]
        public void ParseEnumShouldReturnAnExceptionIfEnumNotAvailable()
        {
            //Action & Assert
            Assert.Throws<ArgumentException>(() => EnumExtensions.ParseEnum<FakeEnum>("Okay"));
        }

        #endregion 
    }
}
