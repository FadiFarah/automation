using NUnit.Framework;
using System;

namespace Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void Zero()
        {
            calc.Press("0");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "0");

        }
        [Test]
        public void OneDigit()
        {
            calc.Press("3");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "3");
        }

        [Test]
        public void MultipleDigits()
        {
            calc.Press("2");
            calc.Press("3");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "23");
        }

        [Test]
        public void MultipleZeros()
        {
            calc.Press("0");
            calc.Press("0");
            calc.Press("0");
            calc.Press("5");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "5");
        }

        [Test]
        public void NumberOperand()
        {
            calc.Press("3");
            calc.Press("+");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "3");
        }

        [Test]
        public void Equal()
        {
            calc.Press("13");
            calc.Press("/");
            calc.Press("5");
            calc.Press("=");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "5");
        }

        [Test]
        public void NumberOperandNumber()
        {
            calc.Press("3");
            calc.Press("+");
            calc.Press("2");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "2");
        }

        [Test]
        public void TwoOperands()
        {
            calc.Press("3");
            calc.Press("+");
            calc.Press("4");
            calc.Press("*");
            calc.Press("2");
            calc.Press("=");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "11");
        }

        [Test]
        public void HugeNumberWithMoreThan5Digits()
        {
            calc.Press("1");
            calc.Press("2");
            calc.Press("3");
            calc.Press("4");
            calc.Press("5");
            calc.Press("6");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "23456");
        }

        [Test]
        public void MultipleOperands()
        {
            calc.Press("+");
            calc.Press("+");
            calc.Press("+");
            calc.Press("1");
            calc.Press("+");
            calc.Press("+");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "1");
        }

        [Test]
        public void ClearScreen()
        {
            calc.Press("1");
            calc.Press("2");
            calc.Press("+");
            calc.Press("1");
            calc.Press("C");
            var str = calc.GetDisplay();
            Console.WriteLine(str);
            Assert.AreEqual(str, "0");
        }
    }
}