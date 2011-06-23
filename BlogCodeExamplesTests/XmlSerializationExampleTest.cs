using System.Dynamic;
using BlogCodeExamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlogCodeExamplesTests
{
    
    
    /// <summary>
    ///This is a test class for XmlSerializationExampleTest and is intended
    ///to contain all XmlSerializationExampleTest Unit Tests
    ///</summary>
    [TestClass]
    public class XmlSerializationExampleTest
    {
        readonly string _personXmlFragment = "<Person><FirstName>John</FirstName><LastName>Smith</LastName></Person>";
        readonly XmlSerializationExample.Person _person = new XmlSerializationExample.Person{FirstName = "John", LastName = "Smith"};
        readonly string _personXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><FirstName>John</FirstName><LastName>Smith</LastName></Person>";
        private dynamic _dynamicPerson = new ExpandoObject();
        /// <summary>
        ///A test for DeserializeXmlFromString
        ///</summary>
        [TestMethod]
        public void DeserializeXmlFromStringTest()
        {
            XmlSerializationExample.Person expected = _person;
            XmlSerializationExample.Person actual = XmlSerializationExample.DeserializePersonFromXmlString(_personXmlFragment);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName,actual.LastName);
        }
        [TestMethod]
        public void SerializePersonToXmlStringTest()
        {
            var expected = _personXml;
            var actual = XmlSerializationExample.SerializePersonToXmlString(_person);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void SerializePersonToXmlStringFragmentTest()
        {
            var expected = _personXmlFragment;
            var actual = XmlSerializationExample.SerializePersonToXmlStringFragment(_person);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeserializeDynamicPersonFromXmlStringTest()
        {
            dynamic expected = _person;
            var actual = XmlSerializationExample.DeserializeDynamicPersonFromXmlString(_personXmlFragment);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }
        [TestMethod]
        public void SerializeDynamicPersonToXmlStringFragmentTest()
        {
            dynamic person = new ExpandoObject();
            person.FirstName = "John";
            person.LastName = "Smith";

            var expected = _personXmlFragment;
            var actual = XmlSerializationExample.SerializeDynamicPersonToXmlStringFragment(person);
            Assert.AreEqual(expected, actual);
        }
    }
}
