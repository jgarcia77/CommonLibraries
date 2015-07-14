namespace Common.Helpers.Text
{
    using Common.Helpers.Text;
    using Common.Helpers.Configuration;
    using System;

    public class PasswordHelper
    {
        public Guid SaltValue { get; private set; }

        private readonly CryptographyHelper cryptographyHelper;

        public PasswordHelper(Guid saltValue)
        {
            cryptographyHelper = new CryptographyHelper(ConfigHelper.RegistrationEncryptionKey);
            SaltValue = saltValue;
        }

        public string Hash(string value)
        {
            var encryptedSaltValue = cryptographyHelper.Encrypt(this.SaltValue.ToString());
            var encryptedValue = cryptographyHelper.Encrypt(value);
            return CryptographyHelper.Hash(encryptedSaltValue, encryptedValue);
        }
    }
}