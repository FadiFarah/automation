using NUnit.Framework;
using System;
using System.Linq;
using System.Xml;

namespace XML
{
    public class BeatlesXMLTests
    {

        [OneTimeSetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void There_are_four_artists()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//Beatles.xml");
            XmlElement root_element = xmlDoc.DocumentElement;
            XmlNodeList artistsNode = root_element.GetElementsByTagName("Artist");
            Assert.That(artistsNode.Count, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//Beatles.xml");
            XmlElement root_element = xmlDoc.DocumentElement;
            XmlNodeList artistsNode = root_element.GetElementsByTagName("Artist");
            int aliveCount = 0, deadCount = 0;
            foreach(XmlNode item in artistsNode)
            {
                var isAlive = item.ChildNodes.Item(1).InnerText == "Yes" ? true : false;
                if(isAlive)
                {
                    aliveCount++;
                }
                else
                {
                    deadCount++;
                }
            }
            Assert.That(aliveCount, Is.EqualTo(2));
            Assert.That(deadCount, Is.EqualTo(2));
        }

        [Test]
        public void Ringo_plays_drums()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//Beatles.xml");
            var result = xmlDoc.SelectNodes("Beatles/Artists/*")
                .Cast<XmlNode>()
                .FirstOrDefault(element => element.Attributes.GetNamedItem("name").Value == "Ringo Starr");
            Assert.That(result.SelectSingleNode("Plays").InnerText, Is.EqualTo("Drums"));
        }

        [Test]
        public void Price_of_all_cds()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//CD_Catalog.xml");
            var result = xmlDoc.SelectNodes("CATALOG/*")
                .Cast<XmlNode>()
                .Sum(element => double.Parse(element.SelectSingleNode("PRICE").InnerText));
            Console.WriteLine(String.Format("{0:0.00}", result));
        }

        [Test]
        public void All_cds_older_than_1987()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//CD_Catalog.xml");
            var result = xmlDoc.SelectNodes("CATALOG/*")
                .Cast<XmlNode>()
                .Where(element => int.Parse(element.SelectSingleNode("YEAR").InnerText) < 1987).Sum(element => double.Parse(element.SelectSingleNode("PRICE").InnerText));
            Console.WriteLine(String.Format("{0:0.00}", result));
        }

        [Test]
        public void All_usa_cds_alphabetical_order()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..//..//..//CD_Catalog.xml");
            var result = xmlDoc.SelectNodes("CATALOG/*")
                .Cast<XmlNode>()
                .OrderBy(element => element.SelectSingleNode("TITLE").InnerText).Where(element => element.SelectSingleNode("COUNTRY").InnerText == "USA")
                .ToList();
            foreach(var item in result)
            {
                Console.WriteLine(item.SelectSingleNode("TITLE").InnerText);
            }
        }
    }
}