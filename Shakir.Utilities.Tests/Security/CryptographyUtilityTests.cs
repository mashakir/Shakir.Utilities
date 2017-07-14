using System;
using System.Text;
using NUnit.Framework;
using static Shakir.Utilities.Security.CryptographyUtility;

namespace Shakir.Utilities.Tests.Security
{
    [TestFixture]
    public class CryptographyUtilityTests
    {
        #region Private variables

        private const string TestString = "teststring";

        #endregion

        #region Tests

        [Test]
        public void EncryptReturnsAnEncryptedString()
        {
            //Arrange & Action
            var result = Encrypt(TestString);

            //Assert
            Assert.That(!result.Equals(TestString));
        }

        [Test]
        public void EncryptReturnsTheSameResultForTheSameString()
        {
            //Arrange & Action
            var result1 = Encrypt(TestString);
            var result2 = Encrypt(TestString);

            //Assert
            Assert.That(result1.Equals(result2));
        }

        [Test]
        public void DecryptReturnsTheOriginalStringOfAnEncryptedString()
        {
            //Arrange & Action
            var encrypted = Encrypt(TestString);
            var decrypted = Decrypt(encrypted);

            //Assert
            Assert.That(!encrypted.Equals(decrypted));
            Assert.That(decrypted.Equals(TestString));
        }

        [Test]
        public void HashReturnsAHashedString()
        {
            //Acton
            var result = GetHashSring(TestString);

            //Assert
            Assert.That(!result.Equals(TestString));
        }

        [Test]
        public void EncryptAndConvertEmailAddress()
        {
            //Arrange
            const string emailAddress = "michael.craven@manheim.co.uk";

            //Action
            var result = Convert.ToBase64String(Encoding.UTF8.GetBytes(Encrypt(emailAddress)));

            //Assert
            Assert.That(!result.Equals(emailAddress));
        }

        #endregion
    }
}
