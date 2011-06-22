using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BlogCodeExamples
{
    public class XmlSerializationExample
    {
        public static Person DeserializePersonFromXmlString(string personXml)
        {
            Person result;
            var xmlSerializer = new XmlSerializer(typeof (Person));
            using(var reader = new StringReader(personXml))
            {
                result = xmlSerializer.Deserialize(reader) as Person;
                if(result == null) throw new SerializationException("Deserialization of Person failed.");
            }
            return result;
        }
        public static string SerializePersonToXmlString(Person person)
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));

            using (var stringWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(writer, person);
                    return stringWriter.ToString();
                }
            }
        }

        public static string SerializePersonToXmlStringFragment(Person person)
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));

            var settings = new XmlWriterSettings { OmitXmlDeclaration = true };
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (var stringWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlSerializer.Serialize(writer, person, ns);
                    return stringWriter.ToString();
                }
            }
        }

        [XmlRoot( Namespace = "")]
        public class Person
        {
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string LastName { get; set; }
        }
    }
}
    