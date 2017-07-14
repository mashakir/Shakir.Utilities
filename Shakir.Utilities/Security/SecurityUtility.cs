using System;
using System.Security.Cryptography;
using System.Text;
using Shakir.Utilities.Security.Interfaces;

namespace Shakir.Utilities.Security
{
    public class SecurityUtility: ISecurityUtility
    {
        #region Constants

        private const int SaltLength = 24;
        private const int HashByteSize = 24;
        private const int IterationCount = 1000;

        #endregion

        #region Public methods 
        /// <summary>
        /// Generates the token information.
        /// </summary>
        /// <param name="expiryDateTime">An expiry UTC date time.</param>
        /// <param name="keyInfo">An information to be embedded into the token.</param>
        /// <returns>Returns the token.</returns>
        public string GenerateToken(DateTime expiryDateTime, object keyInfo)
        {
            var tokenData = $"{keyInfo}|{expiryDateTime}";
            return EncryptAndEncode(tokenData);
        }
        /// <summary>
        /// Valides the token.
        /// </summary>
        /// <param name="token">A system generated token.</param>
        /// <returns>Returns the token information with validation flag.</returns>
        public Tuple<bool, object> IsValidToken(string token)
        {
            try
            {
                var tokenParts = DecodeAndDecrypt(token).Split('|');
                var expiryDateTime = Convert.ToDateTime(tokenParts[1]);
                return expiryDateTime < DateTime.UtcNow
                    ? new Tuple<bool, object>(false, string.Empty)
                    : new Tuple<bool, object>(true, tokenParts[0]);
            }
            catch
            {
                return new Tuple<bool, object>(false, string.Empty);
            }
        }

        public string EncryptAndEncode(string plainText) => string.IsNullOrEmpty(plainText) ? string.Empty : Convert.ToBase64String(Encoding.UTF8.GetBytes(CryptographyUtility.Encrypt(plainText)));

        public string DecodeAndDecrypt(string base64CipherText) => string.IsNullOrEmpty(base64CipherText) ? string.Empty : CryptographyUtility.Decrypt(Encoding.UTF8.GetString(Convert.FromBase64String(base64CipherText)));

        public byte[] GenerateSalt(int length = 0)
        {
            var cryptoServiceProvider = new RNGCryptoServiceProvider();

            var salt = length == 0 ? new byte[SaltLength] : new byte[length];

            cryptoServiceProvider.GetBytes(salt);

            return salt;
        }

        public string CreateSaltedHash(string source, byte[] salt)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException(nameof(source));

            if (salt == null || salt.Length == 0)
                throw new ArgumentNullException(nameof(salt));

            var hash = generateHash(source, salt, HashByteSize);

            return Convert.ToBase64String(hash);
        }

        public bool ValidateHash(string source, string storedHash, byte[] salt)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(storedHash))
                throw new ArgumentNullException(nameof(storedHash));

            if (salt == null || salt.Length == 0)
                throw new ArgumentNullException(nameof(salt));

            var hash = Convert.FromBase64String(storedHash);

            var testHash = generateHash(source, salt, hash.Length);
            return slowEquals(hash, testHash);
        }

        #endregion

        #region Private methods

        private bool slowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;

            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }

        private byte[] generateHash(string input, byte[] salt, int outputBytes)
        {
            var key = new Rfc2898DeriveBytes(input, salt)
            {
                IterationCount = IterationCount
            };

            return key.GetBytes(outputBytes);
        }

        #endregion
    }
}
