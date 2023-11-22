using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public static class ValidPalindrome
    {
        public static bool IsPalindrome(string s)
        {
            // Per directions, null is not a valid s
            
            s = removeNonAlphanumericCharacters(s);

            if (s.Length <= 1)
            {
                return true;
            }

            int leftIndex, rightIndex;

            if (s.Length % 2 == 0)
            {
                leftIndex = s.Length / 2 - 1;
                rightIndex = s.Length / 2;
            }
            else // Ignore middle character for odd length strings
            {
                leftIndex = s.Length / 2 - 1;
                rightIndex = s.Length / 2 + 1;
            }

            bool isPalindrome = true;

            do
            {
                if (s[leftIndex] != s[rightIndex])
                {
                    isPalindrome = false;
                }
                else
                {
                    leftIndex--;
                    rightIndex++;
                }
            }

            while (isPalindrome && leftIndex >= 0);

            return isPalindrome;
        }

        private static string removeNonAlphanumericCharacters(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var character in s)
            {
                if(char.IsLetter(character))
                {
                    sb.Append(char.ToLower(character));
                }

                else if (char.IsDigit(character))
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }
    }

    [TestClass]
    public class ValidPalindromeTests
    {
        [TestMethod]
        public void Example1()
        {
            Assert.IsTrue(ValidPalindrome.IsPalindrome("A man, a plan, a canal: Panama"));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.IsFalse(ValidPalindrome.IsPalindrome("race a car"));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.IsTrue(ValidPalindrome.IsPalindrome(" "));
        }

        [TestMethod]
        public void TacoCat()
        {
            Assert.IsTrue(ValidPalindrome.IsPalindrome("tacocat"));
        }

        [TestMethod]
        public void Peep()
        {
            Assert.IsTrue(ValidPalindrome.IsPalindrome("peep"));
        }

        [TestMethod]
        public void SingleCharacter()
        {
            Assert.IsTrue(ValidPalindrome.IsPalindrome(" :a{} "));
        }
    }
}
