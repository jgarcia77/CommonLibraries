namespace Common.Helpers.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Common.Helpers.Text;

    /// <summary>
    /// Summary description for StringTests
    /// </summary>
    [TestClass]
    public class StringTests
    {
        public StringTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AbbreviateInteger_LessThan1k()
        {
            var integer = 35;
            var expected = "35";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1000()
        {
            var integer = 1000;
            var expected = "1k";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1250()
        {
            var integer = 1250;
            var expected = "1.25k";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1500()
        {
            var integer = 1500;
            var expected = "1.5k";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1750()
        {
            var integer = 1750;
            var expected = "1.75k";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_199999()
        {
            var integer = 199999;
            var expected = "199.99k";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1000000()
        {
            var integer = 1000000;
            var expected = "1m";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1250000()
        {
            var integer = 1250000;
            var expected = "1.25m";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1500000()
        {
            var integer = 1500000;
            var expected = "1.5m";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1750000()
        {
            var integer = 1750000;
            var expected = "1.75m";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_199999999()
        {
            var integer = 199999999;
            var expected = "199.99m";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AbbreviateInteger_1000000000()
        {
            var integer = 1000000000;
            var expected = "1b";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1250000000()
        {
            var integer = 1250000000;
            var expected = "1.25b";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1500000000()
        {
            var integer = 1500000000;
            var expected = "1.5b";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1750000000()
        {
            var integer = 1750000000;
            var expected = "1.75b";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_199999999999()
        {
            var integer = 199999999999;
            var expected = "199.99b";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1000000000000()
        {
            var integer = 1000000000000;
            var expected = "1t";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1250000000000()
        {
            var integer = 1250000000000;
            var expected = "1.25t";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1500000000000()
        {
            var integer = 1500000000000;
            var expected = "1.5t";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_1750000000000()
        {
            var integer = 1750000000000;
            var expected = "1.75t";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbbreviateInteger_199999999999999()
        {
            var integer = 199999999999999;
            var expected = "199.99t";

            var actual = StringHelper.AbbreviateInt(integer);

            Assert.AreEqual(expected, actual);
        }
    }
}
