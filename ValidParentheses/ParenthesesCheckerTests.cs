using System;
using Xunit;

namespace ValidParentheses
{
    public class ParenthesesCheckerTests
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("{[]}", true)]
        [InlineData("]", false)]
        public void Test(string text, bool expected)
        {
            var checker = new ParenthesesChecker();

            bool result = checker.IsValid(text);

            Assert.Equal(expected, result);
        }
    }
}
