using NUnit.Framework;
using System;
using System.IO;

namespace Fizzbuzz
{
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void Setup()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void RunFizzBuzz_Test()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            _fizzBuzz.RunFizzBuzz(15);
            string console = output.ToString();
            Assert.AreEqual(string.Format("1{0}2{0}fizz{0}4{0}buzz{0}fizz{0}7{0}8{0}fizz{0}buzz{0}11{0}fizz{0}13{0}14{0}fizzbuzz{0}", Environment.NewLine), console);
        }
    }
}