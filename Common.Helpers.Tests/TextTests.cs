namespace Common.Helpers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Common.Helpers.Text;
    using Common.Helpers.Configuration;
    using System.Collections.Generic;

    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void Hash_Test_Pass()
        {
            var saltValue = Guid.Parse("06099cc8-30da-4918-be0f-a06316de4a2d");
            var unhashedValue = "Password123!";
            var passwordHelper = new PasswordHelper(saltValue);
            var hashedValue = passwordHelper.Hash(unhashedValue);
            var expected = "vCu+DrCimRsT9SXLCM7JlbdVJWiz5KElucGLB8ALoqcCnyV8KPI8pejwzQuZ6yn52/r5eXN+4ItgEtORj5LPtQ==";

            Assert.AreEqual(expected, hashedValue);
        }

        [TestMethod]
        public void Encrypt_Decrypt_Pass()
        {
            var one = 1;
            var two = 2;
            var three = 3;
            var four = 4;
            var five = 5;

            var cryptographyHelper = new CryptographyHelper(ConfigHelper.RegistrationEncryptionKey);

            var oneEncrypted = cryptographyHelper.Encrypt(one.ToString());
            var twoEncrypted = cryptographyHelper.Encrypt(two.ToString());
            var threeEncrypted = cryptographyHelper.Encrypt(three.ToString());
            var fourEncrypted = cryptographyHelper.Encrypt(four.ToString());
            var fiveEncrypted = cryptographyHelper.Encrypt(five.ToString());

            var oneDecrypted = cryptographyHelper.Decrypt(oneEncrypted);
            var twoDecrypted = cryptographyHelper.Decrypt(twoEncrypted);
            var threeDecrypted = cryptographyHelper.Decrypt(threeEncrypted);
            var fourDecrypted = cryptographyHelper.Decrypt(fourEncrypted);
            var fiveDecrypted = cryptographyHelper.Decrypt(fiveEncrypted);

            Assert.AreEqual(one, int.Parse(oneDecrypted));
            Assert.AreEqual(two, int.Parse(twoDecrypted));
            Assert.AreEqual(three, int.Parse(threeDecrypted));
            Assert.AreEqual(four, int.Parse(fourDecrypted));
            Assert.AreEqual(five, int.Parse(fiveDecrypted));
        }

        [TestMethod]
        public void Encrypt_Iterations_Pass()
        {
            var cryptographyHelper = new CryptographyHelper(ConfigHelper.RegistrationEncryptionKey);

            var value = long.MaxValue.ToString();
            var iterations = 5;

            var encryptedValue = cryptographyHelper.Encrypt(value, iterations);

            var decryptedValue = cryptographyHelper.Decrypt(encryptedValue, iterations);

            Assert.AreEqual(value, decryptedValue);
        }

        [TestMethod]
        public void ParseTags_NoResults_Pass()
        {
            var value = "select * from tableName";
            var output = new List<string>();
            var result = StringHelper.ParseTags("[[", "]]", value, output);

            Assert.IsTrue(result);
            Assert.AreEqual(0, output.Count);
        }

        [TestMethod]
        public void ParseTags_NoResults_Fail()
        {
            var value = "select * from tableName where field1 = [[";
            var output = new List<string>();
            var result = StringHelper.ParseTags("[[", "]]", value, output);

            Assert.IsFalse(result);
            Assert.AreEqual(0, output.Count);
        }

        [TestMethod]
        public void ParseTags_OneResult_Pass()
        {
            var value = "select * from tableName where field1 = [[parm1]]";
            var output = new List<string>();
            var result = StringHelper.ParseTags("[[", "]]", value, output);

            Assert.IsTrue(result);
            Assert.AreEqual(1, output.Count);
        }

        [TestMethod]
        public void ParseTags_OneResult_Fail()
        {
            var value = "select * from tableName where field1 = [[parm1]] and field2 = [[parm2";
            var output = new List<string>();
            var result = StringHelper.ParseTags("[[", "]]", value, output);

            Assert.IsFalse(result);
            Assert.AreEqual(1, output.Count);
        }

        [TestMethod]
        public void ParseTags_TwoResult_Pass()
        {
            var value = "select * from tableName where field1 = [[parm1]] and field2 = [[parm2]]";
            var output = new List<string>();
            var result = StringHelper.ParseTags("[[", "]]", value, output);

            Assert.IsTrue(result);
            Assert.AreEqual(2, output.Count);
        }


        [TestMethod]
        public void ParseTagsWithLineBreaks_TwoResult_Pass()
        {
            var value = @"\n\r\n\rselect * \n\rfrom tableName \n\rwhere field1 = \n\r\n\[[\n\r\n\parm1\n\r\n\]] \n\rand field2 = [[parm2]]           ";
            var output = new List<string>();
            var result = StringHelper.ParseTags("[[", "]]", value, output);

            Assert.IsTrue(result);
            Assert.AreEqual(2, output.Count);
        }
    }
}
