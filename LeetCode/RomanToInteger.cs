using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public static class RomanToInteger
    {
        public static int RomanToInt(string s)
        {
            var total = 0;

            for(int i = 0; i < s.Length; i++) 
            {
                switch(s[i]) 
                {
                    case 'I':
                        if (i < s.Length - 1 && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                        {
                            total -= 1;
                        }
                        else
                        {
                            total += values[s[i]];
                        }
                        break;
                    case 'X':
                        if (i < s.Length - 1 && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                        {
                            total -= 10;
                        }
                        else
                        {
                            total += values[s[i]];
                        }
                        break;
                    case 'C':
                        if (i < s.Length - 1 && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                        {
                            total -= 100;
                        }
                        else
                        {
                            total += values[s[i]];
                        }
                        break;
                    default:
                        total += values[s[i]];
                        break;
                }
            }

            return total;
        }

        private static readonly Dictionary<char, int> values = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
    }

    [TestClass]
    public class RomanToIntegerTests
    {
        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual(3, RomanToInteger.RomanToInt("III"));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual(58, RomanToInteger.RomanToInt("LVIII"));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.AreEqual(1994, RomanToInteger.RomanToInt("MCMXCIV"));
        }
    }

}
