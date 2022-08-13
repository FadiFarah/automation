using System;
using System.Collections.Generic;
using System.Text;

namespace Fizzbuzz
{
    class FizzBuzz
    {
        public void RunFizzBuzz(int until)
        {
            for (int i = 1; i <= until; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
