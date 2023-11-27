using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public static class IntegerToRoman
    {
        public static string IntToRoman(int num)
        {
            var valueRemaining = num;

            var returnString = new StringBuilder();

            while (valueRemaining > 0)
            {
                valueRemaining = appendChar(returnString, valueRemaining, values.Last(x => x.Key <= valueRemaining).Key);
            }

            return returnString.ToString();
        }

        private static int appendChar(StringBuilder returnString, int valueRemaining, int valueToCheck)
        {
            if (valueRemaining >= valueToCheck)
            {
                returnString.Append(values[valueToCheck]);

                return valueRemaining - valueToCheck;
            }

            return valueRemaining;
        }

        // Sorted dictionary to ease updating code and requiring it to be sorted. Can convert to something simpler to improve runtime performance.
        private static readonly SortedDictionary<int, string> values = new SortedDictionary<int, string>()
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX" },
            { 10, "X" },
            { 40, "XL" },
            { 50, "L" },
            { 90, "XC" },
            { 100, "C" },
            { 400, "CD" },
            { 500, "D" },
            { 900, "CM" },
            { 1000, "M" }
        };
    }

    [TestClass]
    public class IntegerToRomanTests
    {
        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual("III", IntegerToRoman.IntToRoman(3));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual("LVIII", IntegerToRoman.IntToRoman(58));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.AreEqual("MCMXCIV", IntegerToRoman.IntToRoman(1994));
        }

        [TestMethod]
        public void Check20()
        {
            Assert.AreEqual("XX", IntegerToRoman.IntToRoman(20));
        }

    }

}
