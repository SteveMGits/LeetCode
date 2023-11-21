using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class RemoveDuplicatesFromSortedArray2
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if(nums.Length <= 2)
            {
                return nums.Length;
            }

            var lastSeen = nums[0];
            var lastSeenCount = 1;
            var writeIndex = 1;

            for(int i = 1; i < nums.Length; i++) 
            {
                if (nums[i] == lastSeen)
                {
                    lastSeenCount += 1;

                    if(lastSeenCount <= 2)
                    {
                        nums[writeIndex] = nums[i];
                        writeIndex += 1;
                    }
                }
                else
                {
                    lastSeenCount = 1;
                    lastSeen = nums[i];
                    nums[writeIndex] = nums[i];
                    writeIndex += 1;
                }
            }

            return writeIndex;
        }
    }

    [TestClass]
    public class RemoveDuplicatesFromSortedArray2Tests
    {
        [TestMethod]
        public void Example1Test()
        {
            var startArray = new int[] { 1, 1, 1, 2, 2, 3 };
            var result = RemoveDuplicatesFromSortedArray2.RemoveDuplicates(startArray);
            Assert.IsTrue(AreArraysMatched(new int[] { 1, 1, 2, 2, 3 }, startArray, 5), $"Actual array: {string.Join(',', startArray)}");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Example2Test()
        {
            var startArray = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
            var result = RemoveDuplicatesFromSortedArray2.RemoveDuplicates(startArray);
            Assert.IsTrue(AreArraysMatched(new int[] { 0, 0, 1, 1, 2, 3, 3 }, startArray, 5), $"Actual array: {string.Join(',', startArray)}");
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void EmptyArray()
        {
            var startArray = new int[] { };
            var result = RemoveDuplicatesFromSortedArray2.RemoveDuplicates(startArray);
            Assert.IsTrue(AreArraysMatched(new int[] { }, startArray, 0), $"Actual array: {string.Join(',', startArray)}");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SingleElementArray()
        {
            var startArray = new int[] { 1 };
            var result = RemoveDuplicatesFromSortedArray2.RemoveDuplicates(startArray);
            Assert.IsTrue(AreArraysMatched(new int[] { 1 }, startArray, 1), $"Actual array: {string.Join(',', startArray)}");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TwoElementArray()
        {
            var startArray = new int[] { 1, 2};
            var result = RemoveDuplicatesFromSortedArray2.RemoveDuplicates(startArray);
            Assert.IsTrue(AreArraysMatched(new int[] { 1, 2 }, startArray, 2), $"Actual array: {string.Join(',', startArray)}");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ManyDuplicates()
        {
            var startArray = new int[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 10, 10, 20, 20, 20, 20, 20, 20, 20, 20, 50};
            var result = RemoveDuplicatesFromSortedArray2.RemoveDuplicates(startArray);
            Assert.IsTrue(AreArraysMatched(new int[] { 1, 1, 2, 2, 10, 10, 20, 20, 50 }, startArray, 9), $"Actual array: {string.Join(',', startArray)}");
            Assert.AreEqual(9, result);
        }

        private bool AreArraysMatched(int[] expectedArray, int[] actualArray, int k)
        {
            for(int i = 0; i < k; i++) 
            {
                if (expectedArray[i] != actualArray[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
