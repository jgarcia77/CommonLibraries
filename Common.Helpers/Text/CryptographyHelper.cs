namespace Common.Helpers.Text
{
    using System;
    using System.IO;
    using System.Text;
    using System.Security.Cryptography;

    public class CryptographyHelper
    {
        private readonly byte[] EncryptionKey;

        public CryptographyHelper(string encryptionKey)
        {
            this.EncryptionKey = ASCIIEncoding.ASCII.GetBytes(encryptionKey);
        }

        /// <summary>
        /// Encryption using DESCryptoServiceProvider
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(EncryptionKey, EncryptionKey), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);

            writer.Write(value);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }


        /// <summary>
        /// Decryption using DESCryptoServiceProvider
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Decrypt(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(value));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(EncryptionKey, EncryptionKey), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }

        /// <summary>
        /// Hashing using SHA-512
        /// </summary>
        /// <param name="saltValue"></param>
        /// <param name="valueToHash"></param>
        /// <returns></returns>
        public static string Hash(string saltValue, string valueToHash)
        {
            HashAlgorithm hasher = HashAlgorithm.Create("SHA-512");

            byte[] unhashedBytes = Encoding.UTF8.GetBytes(string.Concat(saltValue, valueToHash));

            byte[] hashBytes = hasher.ComputeHash(unhashedBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}