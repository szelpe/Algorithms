using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumbers
{
    class IntToRomanConverter
    {
        private static List<(string, int)> digits = new List<(string, int)>() {
                 ( "M", 1000 ),
                 ( "CM", 900 ),
                 ( "D", 500 ),
                 ( "CD", 400 ),
                 ( "C", 100 ),
                 ( "XC", 90 ),
                 ( "L", 50 ),
                 ( "XL", 40 ),
                 ( "X", 10 ),
                 ( "IX", 9 ),
                 ( "V", 5 ),
                 ( "IV", 4 ),
                 ( "III", 3 ),
                 ( "II", 2 ),
                 ( "I", 1 ),
        };

        public string IntToRoman(int num)
        {
            var builder = new StringBuilder();
            int remaining = num;
            foreach (var (digit, value) in digits)
            {
                for (int i = 0; remaining >= value; i++)
                {
                    builder.Append(digit);
                    remaining -= value;
                }
            }

            return builder.ToString();
        }
    }
}
