namespace Common.Helpers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Common.Helpers.Serialization;

    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void JsonHelper_Serialize_Pass()
        {
            var person = new Person { Id = 1, FirstName = "Josue", LastName = "Garcia" };
            var json = JsonHelper.Serialize<Person>(person);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void JsonHelper_Deserialize_Pass()
        {
            var json = "{\"FirstName\":\"Josue\",\"Id\":1,\"LastName\":\"Garcia\"}";
            var person = JsonHelper.Deserialize<Person>(json);

            Assert.IsTrue(true);
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
