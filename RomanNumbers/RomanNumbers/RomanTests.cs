using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace RomanNumbers
{
    public class RomanTests
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void SimpleTest(string roman, int expected)
        {
            var romanNumbers = new RomanToIntSwitch();

            int result = romanNumbers.RomanToInt(roman);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void SimpleTestMap(string roman, int expected)
        {
            var romanNumbers = new RomanToIntMap();

            int result = romanNumbers.RomanToInt(roman);

            Assert.Equal(expected, result);
        }
    }
}
