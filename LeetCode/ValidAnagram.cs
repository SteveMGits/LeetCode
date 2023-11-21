using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ValidAnagram
    {
        public static bool IsAnagram(string s, string t)
        {
            if(s == t) 
            {
                return true;
            }

            if((s == null || t == null) || s.Length != t.Length) 
            {
                return false;
            }
            
            var stringSContents = getStringContents(s);
            
            var stringTContents = new Dictionary<char, int> ();

            foreach( char stringTChar in t)
            {
                if(!(stringSContents.TryGetValue(stringTChar, out var stringSCount)))
                {
                    return false;
                }

                if(stringTContents.ContainsKey(stringTChar))
                {
                    stringTContents[stringTChar] -= 1;

                    if (stringTContents[stringTChar] < 0) 
                    { 
                        return false;
                    }
                }

                else
                {
                    stringTContents.Add(stringTChar, stringSCount - 1);
                }
            }

            if(stringTContents.Values.Any(x => x != 0))
            {
                return false;
            }

            return true;
        }

        private static Dictionary<char, int> getStringContents(string s)
        {
            var returnVal = new Dictionary<char, int>();

            foreach(char theChar in s)
            {
                if(returnVal.ContainsKey(theChar))
                {
                    returnVal[theChar] += 1;
                }
                else
                {
                    returnVal.Add(theChar, 1);
                }
            }

            return returnVal;
        }
    }

    [TestClass]
    public class ValidAnagramTests
    {
        [TestMethod]
        public void IsAnagramTest()
        {
            Assert.IsTrue(ValidAnagram.IsAnagram("anagram", "nagaram"));
        }

        [TestMethod]
        public void IsAnagram_False_Test()
        {
            Assert.IsFalse(ValidAnagram.IsAnagram("rat", "car"));
        }
    }
}
