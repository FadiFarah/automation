using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumeralsKata
{
    class RomanNumeralsKata
    {
        static Dictionary<int, string> arabicToRoman = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        static Dictionary<string, int> romanToArabic = new Dictionary<string, int>
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D", 500 },
            { "CD", 400 },
            { "C", 100 },
            { "XC", 90 },
            { "L", 50 },
            { "XL", 40 },
            { "X", 10 },
            { "IX", 9 },
            { "V", 5 },
            { "IV", 4 },
            { "I", 1 }
        };

        public static string ArabicToRoman(int arabic)
        {
            string roman = string.Empty;

            foreach (int value in arabicToRoman.Keys)
            {
                while (arabic >= value)
                {
                    roman += arabicToRoman[value];
                    arabic -= value;
                }
            }

            return roman;
        }

        public static int RomanToArabic(string roman)
        {
            var number = 0;
            for(int i = 0; i < roman.Length; i++)
            {
                if(roman.Length - i > 1)
                {
                    string str = roman[i] +""+ roman[i + 1];
                    if(romanToArabic.ContainsKey(str))
                    {
                        number += romanToArabic[str];
                        i++;
                    }
                    else
                    {
                        number += romanToArabic[roman[i].ToString()];
                    }
                }
                else
                {
                    number += romanToArabic[roman[i].ToString()];
                }
            }

            return number;
        }
    }
}
