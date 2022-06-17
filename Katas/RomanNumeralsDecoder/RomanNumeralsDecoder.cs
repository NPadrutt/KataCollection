using System.Collections.Generic;
using NUnit.Framework;

namespace Katas.RomanNumeralsDecoder;

internal sealed class RomanNumeralsDecoder
{
    private class RomanDecode
    {
        private static Dictionary<char, int> romanToArabic = new Dictionary<char, int>{
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
      
        public static int Solution(string roman)
        {
            int value = 0;
            for(int i = 0; i < roman.Length; i++)
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
    
    [TestFixture]
    public class RomanDecodeTests
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(21, "XXI")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1954, "MCMLIV")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(2014, "MMXIV")]
        public void Test(int expected, string roman)
        {
            Assert.AreEqual(expected, RomanDecode.Solution(roman));
        }
    }
}