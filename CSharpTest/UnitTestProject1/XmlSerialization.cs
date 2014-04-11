using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace IAmTest
{

    [TestClass]
    public class XmlSerialization
    {
        public class SerializedMe
        {
            [XmlAttribute()]
            public string Name { get; set; }
            [XmlAttribute(attributeName:"BaseID")]
            public int Id { get; set; }
            [XmlElement(ElementName="aaa",DataType="int")]
            public int[] items { get; set; }
        }

        List<SerializedMe> GetSerializedObject()
        {
            List<SerializedMe> loading = new List<SerializedMe>();
            foreach (var i in System.Linq.Enumerable.Range(0, 20))
            {
                loading.Add(new SerializedMe { Name = "Ruth " + i.ToString(), Id = i ,items =new int[] {1,3}});
            }
            return loading;
        }

        [TestMethod]
        public void Serialized()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializedMe>));
            var location =   Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            using (var stream = new FileStream(Path.Combine(location,"hello.xml"),FileMode.Create))
            {
               serializer.Serialize(stream,
                   GetSerializedObject());
            }
            

        }
    }
}
