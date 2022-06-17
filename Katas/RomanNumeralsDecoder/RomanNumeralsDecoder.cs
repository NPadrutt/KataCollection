using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Katas.RomanNumeralsDecoder;

public sealed class RomanNumeralsDecoder
{
    private class RomanDecode
    {
        private static readonly Dictionary<char, int> romanToArabic = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int Solution(string roman)
        {
            var value = 0;
            for (var i = 0; i < roman.Length; i++)
            {
                var currentNumber = romanToArabic[roman[i]];

                var nextIndex = i + 1;
                if (nextIndex != roman.Length)
                {
                    var nextNumber = romanToArabic[roman[nextIndex]];

                    if (nextNumber > currentNumber)
                    {
                        value += nextNumber - currentNumber;
                        i++;
                        continue;
                    }
                }

                value += currentNumber;
            }

            return value;
        }
    }

    public class RomanDecodeTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(4, "IV")]
        [InlineData(21, "XXI")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        [InlineData(1954, "MCMLIV")]
        [InlineData(1990, "MCMXC")]
        [InlineData(2008, "MMVIII")]
        [InlineData(2014, "MMXIV")]
        public void Test(int expected, string roman)
        {
            expected.Should().Be(RomanDecode.Solution(roman));
        }
    }
}