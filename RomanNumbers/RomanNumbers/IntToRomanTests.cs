using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RomanNumbers
{
    public class IntToRomanTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(5, "V")]
        [InlineData(4, "IV")]
        [InlineData(58, "LVIII")]
        [InlineData(9, "IX")]
        [InlineData(1994, "MCMXCIV")]
        public void Test(int num, string expected)
        {
            var converter = new IntToRomanConverter();

            string result = converter.IntToRoman(num);

            Assert.Equal(expected, result);
        }
    }
}
