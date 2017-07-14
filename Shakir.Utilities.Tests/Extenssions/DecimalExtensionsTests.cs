using NUnit.Framework;
using Shakir.Utilities.Extensions;

namespace Shakir.Utilities.Tests.Extenssions
{
    [TestFixture]
    public class DecimalExtensionsTests
    {
        [Test]
        public void ToStringAndRemoveDecimalsShouldReturnCorrectResult()
        {
            //Arrange
            const decimal decimalData = (decimal) 10.00;

            //Action
            var result = decimalData.ToStringAndRemoveDecimals();

            //Assert
            Assert.That(result,Is.TypeOf<string>());
            Assert.That(result,Is.EqualTo("10"));
        }

        [Test]
        public void ConditionalFlipSignShouldReturnCorrectResultIfFalse()
        {
            //Arrange
            const decimal decimalData = (decimal)10.00;

            //Action
            var result = decimalData.ConditionalFlipSign(false);

            //Assert
            Assert.That(result, Is.TypeOf<decimal>());
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void ConditionalFlipSignShouldReturnCorrectResultIfTrue()
        {
            //Arrange
            const decimal decimalData = (decimal)10.00;
            const decimal decimalData2 = (decimal)-10.00;

            //Action
            var result = decimalData.ConditionalFlipSign(true);
            var result2 = decimalData2.ConditionalFlipSign(true);

            //Assert
            Assert.That(result, Is.TypeOf<decimal>());
            Assert.That(result, Is.EqualTo(-10));
            Assert.That(result2, Is.EqualTo(10));
        }
        [Test]
        public void IsOppositeSignToShouldReturnCorrectResultIfTrue()
        {
            //Arrange
            const decimal decimalData = (decimal)10.00;
            const decimal decimalData2 = (decimal)-10.00;
            const decimal decimalData3 = (decimal)10.00;

            //Action
            var result = decimalData.IsOppositeSignTo(decimalData2);
            var result2 = decimalData.IsOppositeSignTo(decimalData3);

            //Assert
            Assert.That(result, Is.TypeOf<bool>());
            Assert.That(result, Is.EqualTo(true));
            Assert.That(result2, Is.EqualTo(false));
        }
        
    }
}
