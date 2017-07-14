using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shakir.Utilities.Security
{
    public static class CryptographyUtility
    {
        #region Member Variables

        private const string PasswordHash = "Sh@k1rP@55w0rdH45h";
        private const string SaltKey = "S@ir31y541tK3y";
        private const string ViKey = "@S@ir31yV1K3y@@@";

        #endregion

        #region Public Methods

        /// <summary>
        /// Encrypt the plain text into Hash string by using MD5 Cryptography.
        /// </summary>
        /// <param name="plainText">A simple text.</param>
        /// <returns>Returns the hash string.</returns>
        public static string GetHashSring(string plainText)
        {
            var encryptprovider = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            encryptprovider.ComputeHash(Encoding.ASCII.GetBytes(plainText));

            //get hash result after compute it
            var hashbytes = encryptprovider.Hash;

            var myhashstring = new StringBuilder();
            foreach (var hashbyte in hashbytes)
            {
                //change it into 2 hexadecimal digits for each byte
                myhashstring.Append(hashbyte.ToString("x2"));
            }

            return myhashstring.ToString();
        }

        /// <summary>
        /// Returns plain text by decryting cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns>Returns plain text by decryting cipher text.</returns>
        public static string Decrypt(string cipherText)
        {
            var ciphertextbytes = Convert.FromBase64String(cipherText);
            var keybytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetrickey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            int decryptedbytecount;
            byte[] plaintextbytes;
            using (var memorystream = new MemoryStream(ciphertextbytes))
            {
                var decryptor = symmetrickey.CreateDecryptor(keybytes, Encoding.ASCII.GetBytes(ViKey));
                using (var cryptostream = new CryptoStream(memorystream, decryptor, CryptoStreamMode.Read))
                {
                    plaintextbytes = new byte[ciphertextbytes.Length];
                    decryptedbytecount = cryptostream.Read(plaintextbytes, 0, plaintextbytes.Length);
                    cryptostream.Close();
                }
                memorystream.Close();
            }

            return Encoding.UTF8.GetString(plaintextbytes, 0, decryptedbytecount).TrimEnd("\0".ToCharArray());
        }

        /// <summary>
        /// Returns ciphyer text by encryping the plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>Returns ciphyer text by encryping the plain text.</returns>
        public static string Encrypt(string plainText)
        {
            var plaintextbytes = Encoding.UTF8.GetBytes(plainText);

            var keybytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetrickey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetrickey.CreateEncryptor(keybytes, Encoding.ASCII.GetBytes(ViKey));

            byte[] ciphertextbytes;

            using (var memorystream = new MemoryStream())
            {
                using (var cryptostream = new CryptoStream(memorystream, encryptor, CryptoStreamMode.Write))
                {
                    cryptostream.Write(plaintextbytes, 0, plaintextbytes.Length);
                    cryptostream.FlushFinalBlock();
                    ciphertextbytes = memorystream.ToArray();
                    cryptostream.Close();
                }
                memorystream.Close();
            }
            return Convert.ToBase64String(ciphertextbytes);
        }
        #endregion
    }
}
