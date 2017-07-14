using System;

namespace Shakir.Utilities.Security.Interfaces
{
    public interface ISecurityUtility
    {
        /// <summary>
        /// Encrypts the give string and encodes it to Base64 format.
        /// </summary>
        string EncryptAndEncode(string plainText);
        /// <summary>
        /// Encodes the string from Base64 format and decrypts it.
        /// </summary>
        string DecodeAndDecrypt(string base64CipherText);
        byte[] GenerateSalt(int length = 0);
        string CreateSaltedHash(string source, byte[] salt);
        bool ValidateHash(string source, string storedHash, byte[] salt);

        /// <summary>
        /// Generates the token information.
        /// </summary>
        /// <param name="expiryDateTime">An expiry UTC date time.</param>
        /// <param name="keyInfo">An information to be embedded into the token.</param>
        /// <returns>Returns the token.</returns>
        string GenerateToken(DateTime expiryDateTime, object keyInfo);
        /// <summary>
        /// Valides the token.
        /// </summary>
        /// <param name="token">A system generated token.</param>
        /// <returns>Returns the token information with validation flag.</returns>
        Tuple<bool, object> IsValidToken(string token);
    }
}
