using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace ComboTests
{
    public class Tests
    {
        private JToken jsonBeatles;
        private JToken jsonMCU;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(@"..//..//..//Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonBeatles = JObject.Load(reader);
            }
            using (var sr = new StreamReader(@"..//..//..//MCU.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonMCU = JArray.Load(reader);
            }
        }

        [Test]
        public void Paul_plays_bass()
        {
            //XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//Beatles.xml");
            var result = xmlDoc.SelectNodes("Beatles/Artists/*")
                .Cast<XmlNode>()
                .FirstOrDefault(element => element.Attributes.GetNamedItem("name").Value == "Paul McCartney");
            Assert.That(result.SelectSingleNode("Plays").InnerText, Is.EqualTo("Bass"));

            //JSON
            JObject json = JObject.Parse(jsonBeatles.ToString());
            var artists = (JArray)json["Beatles"]["Artists"];
            var paul = artists.FirstOrDefault(i => i["Name"].ToString() == "Paul McCartney");
            Assert.That(paul["Plays"].ToString(), Is.EqualTo("Bass"));
        }

        [Test]
        public void marvel_movies_heroes()
        {
            var jsonString = JsonConvert.SerializeObject(jsonMCU);
            Assert.IsTrue(jsonString.Contains("{\"name\":\"Thor\"}"));
            Assert.IsTrue(jsonString.Contains("{\"name\":\"Black Widow\"}"));
            Assert.IsTrue(jsonString.Contains("{\"name\":\"Cap\"}"));
            Assert.IsTrue(jsonString.Contains("{\"name\":\"Hulk\"}"));
            Assert.IsTrue(jsonString.Contains("{\"name\":\"Iron Man\"}"));

            //Prove that Ant-Man was not in Avengers
            var avengers = JsonConvert.DeserializeObject<List<MCU>>(jsonMCU.ToString()).FirstOrDefault(m => m.Title == "Avengers");
            Assert.IsFalse(avengers.Heroes.Contains(new Hero { Name = "Ant-Man"}));
        }
    }
}