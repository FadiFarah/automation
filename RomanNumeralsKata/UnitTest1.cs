using NUnit.Framework;

namespace RomanNumeralsKata
{
    public class RomanNumeralsKataTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ArabicToRomanFive()
        {
            Assert.AreEqual("V", RomanNumeralsKata.ArabicToRoman(5));
        }

        [Test]
        public void ArabicToRomanSix()
        {
            Assert.AreEqual("VI", RomanNumeralsKata.ArabicToRoman(6));
        }

        [Test]
        public void ArabicToRomanHugeNumber()
        {
            Assert.AreEqual("MMMMCMLXXVI", RomanNumeralsKata.ArabicToRoman(4976));
        }

        [Test]
        public void RomanToArabicFive()
        {
            Assert.AreEqual(5, RomanNumeralsKata.RomanToArabic("V"));
        }

        [Test]
        public void RomanToArabicSix()
        {
            Assert.AreEqual(6, RomanNumeralsKata.RomanToArabic("VI"));
        }

        [Test]
        public void RomanToArabic()
        {
            Assert.AreEqual(4976, RomanNumeralsKata.RomanToArabic("MMMMCMLXXVI"));
        }
    }
}