using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public static class RansomNote
    {
        // This is O(N) as is, but could further optimize by building magazineInventory first and
        // short circuit if/when ransomeNoteInventory build exceeds magazine.
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            if(ransomNote.Length > magazine.Length) 
            {
                return false;
            }

            var ransomNoteInventory = getStringInventory(ransomNote);
            var magazineInventory = getStringInventory(magazine);

            foreach(var item in ransomNoteInventory)
            {
                if(magazineInventory.TryGetValue(item.Key, out var magazineInventoryValue))
                {
                    if(item.Value > magazineInventoryValue)
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }

            return true;
        }

        private static Dictionary<char, int> getStringInventory(string s)
        {
            var returnDict = new Dictionary<char, int>();

            foreach(char c in s)
            {
                if(returnDict.TryGetValue(c, out int value))
                {
                    returnDict[c] = returnDict[c] + 1;
                }
                else
                {
                    returnDict.Add(c, 1);
                }
            }

            return returnDict;
        }
    }

    [TestClass]
    public class RansomeNoteTests
    {
        [TestMethod]
        public void Example1()
        {
            Assert.IsFalse(RansomNote.CanConstruct("a", "b"));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.IsFalse(RansomNote.CanConstruct("aa", "ab"));
        }

        [TestMethod]
        public void Example3()
        {
            Assert.IsTrue(RansomNote.CanConstruct("aa", "aab"));
        }

        [TestMethod]
        public void RansomeNoteLongerThanMagazine()
        {
            Assert.IsFalse(RansomNote.CanConstruct("asdasasdasasdasasdas", "asdas"));
        }

        [TestMethod]
        public void LongStrings()
        {
            Assert.IsTrue(RansomNote.CanConstruct(
                "lemonchickenlemonchicken", 
                "lemonchickenlemonchickenlemonchickenlemonchickenlemonchickenlemonchickenwordslongstringwordsssss"));
        }


    }

}
