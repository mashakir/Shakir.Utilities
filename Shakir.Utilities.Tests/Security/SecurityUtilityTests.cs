using System;
using NUnit.Framework;
using Shakir.Utilities.Security;

namespace Shakir.Utilities.Tests.Security
{
    public class SecurityUtilityTests
    {
        #region Private variables

        private SecurityUtility _securityUtil; 

        #endregion

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _securityUtil = new SecurityUtility();
        }

        #endregion

        #region Tests
        [Test]
        public void GenerateTokenShouldCorrectType()
        {
            //Action
            var result = _securityUtil.GenerateToken(DateTime.UtcNow, 1);

            //Assert
            Assert.That(result, Is.TypeOf<string>());
        }
        [Test]
        public void GenerateTokenShouldWorkProperly()
        { 
             
            //Action
            var result = _securityUtil.GenerateToken(DateTime.UtcNow, 1);

            //Assert
            Assert.That(result, Is.Not.Empty);
        }
        [Test]
        public void IsValidTokenShouldCorrectType()
        {
            //Arrange
            var tokenData = $"{1}|{DateTime.UtcNow.AddDays(1)}|{1232}"; 
            var token = _securityUtil.EncryptAndEncode(tokenData); 

            //Action
            var result = _securityUtil.IsValidToken(token);

            //Assert
            Assert.That(result, Is.TypeOf<Tuple<bool, object>>());
        }
        [Test]
        public void IsValidTokenShouldReturnValidResponse()
        {
            //Arrange
            var tokenData = $"{1}|{DateTime.UtcNow.AddDays(1)}|{1232}"; 
            var token = _securityUtil.EncryptAndEncode(tokenData); 

            //Action
            var result = _securityUtil.IsValidToken(token);

            //Assert
            Assert.That(result.Item1, Is.True);
            Assert.That(result.Item2, Is.EqualTo("1"));
        }
        [Test]
        public void IsValidTokenShouldReturnInvalidValidResponse()
        {
            var tokenData = $"{1}|{DateTime.UtcNow}|{1232}"; 
            var token = _securityUtil.EncryptAndEncode(tokenData); 

            //Action
            var result = _securityUtil.IsValidToken(token);

            //Assert
            Assert.That(result.Item1, Is.False);
            Assert.That(result.Item2, Is.Not.EqualTo("1"));
        }
        [Test]
        public void SymmetricEncryptionShouldWorkProperly()
        {
            //Arrange
            const string plainText = "EncryptedText"; 
            
            //Action
            var encrypted = _securityUtil.EncryptAndEncode(plainText);
            var decrypted = _securityUtil.DecodeAndDecrypt(encrypted);

            //Assert
            Assert.That(decrypted, Is.EqualTo(plainText));
        }

        [Test]
        public void GenerateSaltReturnRandomSaltByDefault24CharactersLong()
        {
            //Action
            var result = _securityUtil.GenerateSalt();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(24));
        }

        [Test]
        public void GenerateSaltReturnRandomSaltForRequestedLength()
        {
            //Arrange
            const int length = 13;

            //Action
            var result = _securityUtil.GenerateSalt(length);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.EqualTo(length));
        }

        [Test]
        public void GenerateSaltReturnUniqueSalts()
        {
            //Arrange & Action
            var result1 = _securityUtil.GenerateSalt();
            var result2 = _securityUtil.GenerateSalt();

            //Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);
            Assert.That(result1, Is.Not.EqualTo(result2));
        }

        [Test]
        public void CreateSaltedHashWillReturnSaltedHashOfTheInput()
        {
            //Arrange
            const string input = "myPassword";
            var salt = _securityUtil.GenerateSalt();

            //Action
            var result = _securityUtil.CreateSaltedHash(input, salt);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.EqualTo(input));
        }
        [Test]
        public void CreateSaltedHashWillReturnSameSaltedHashOfTheInput()
        {
            //Arrange
            const string input = "myPassword";
            var salt = _securityUtil.GenerateSalt();
             
            //Action
            var result = _securityUtil.CreateSaltedHash(input, salt);
            var result2 = _securityUtil.CreateSaltedHash(input, salt);
            
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.EqualTo(input));
            Assert.That(result2, Is.EqualTo(result2));
        }

        [Test]
        public void CreateSaltedHashWillThrowExceptionIfInputIsNull()
        {
            //Arrange
            var salt = _securityUtil.GenerateSalt();

            //Action & Assert
            Assert.Throws<ArgumentNullException>(() => _securityUtil.CreateSaltedHash(null, salt));
        }

        [Test]
        public void CreateSaltedHashWillThrowExceptionIfSaltIsNull()
        {
            //Arrange
            const string input = "myPassword";

            //Action & Assert
            Assert.Throws<ArgumentNullException>(() => _securityUtil.CreateSaltedHash(input, null));
        }

        [Test]
        public void ValidateInputShouldValidateInputWithTheProperHashAndSalt()
        {
            //Arrange
            const string input = "myPassword";
            var salt = _securityUtil.GenerateSalt();
            var hash = _securityUtil.CreateSaltedHash(input, salt);

            //Action
            var result = _securityUtil.ValidateHash(input, hash, salt);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateInputShouldFailIfInputIsDifferent()
        {
            //Arrange
            const string input1 = "myPassword";
            const string input2 = "myPasswordX";
            var salt = _securityUtil.GenerateSalt();
            var hash = _securityUtil.CreateSaltedHash(input1, salt);

            //Action
            var result = _securityUtil.ValidateHash(input2, hash, salt);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateInputShouldFailIfSaltIsDifferent()
        {
            //Arrange
            const string input = "myPassword";
            var salt1 = _securityUtil.GenerateSalt();
            var salt2 = _securityUtil.GenerateSalt();
            var hash = _securityUtil.CreateSaltedHash(input, salt1);

            //Action
            var result = _securityUtil.ValidateHash(input, hash, salt2);

            //Assert
            Assert.That(result, Is.False);
        }

        #endregion
    }
}
