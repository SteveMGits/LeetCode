using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RemoveDuplicatesFromSortedArray
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums.Length;
            }

            var numberOfUniques = 1;
            var previousIndexDeltaToCheck = 1;
            for (int i = 1; i < nums.Length; i++)
            {   
                if (nums[i] == nums[i - previousIndexDeltaToCheck])
                {
                    nums[i] = int.MinValue;
                    previousIndexDeltaToCheck += 1;
                }
                else
                {
                    numberOfUniques += 1;
                    previousIndexDeltaToCheck = 1;
                }

                // We're at the last unique value
                if (nums[i] == nums[nums.Length - 1])
                {
                    break;
                }
            }

            var writeIndex = 1;
            for (int readIndex = 1; readIndex < nums.Length && writeIndex < numberOfUniques; readIndex++)
            {
                if (nums[readIndex] != int.MinValue)
                {
                    nums[writeIndex] = nums[readIndex];
                    writeIndex += 1;
                }
            }

            return numberOfUniques;
        }
    }

    [TestClass]
    public class RemoveDuplicatesFromSortedArrayTests
    {
        [TestMethod]
        public void RemoveDuplicates_Case1_Test()
        {
            var nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(5, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { 0, 1, 2, 3, 4 }, false));
        }

        [TestMethod]
        public void RemoveDuplicates_Case2_Test()
        {
            var nums = new int[] { 1, 1, 2 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(2, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { 1, 2 }, false));
        }

        [TestMethod]
        public void RemoveDuplicates_TwoDuplicates_Test()
        {
            var nums = new int[] { 1, 1 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(1, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { 1 }, false));
        }

        [TestMethod]
        public void RemoveDuplicates_ThreeDuplicates_Test()
        {
            var nums = new int[] { 1, 1, 1 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(1, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { 1 }, false));
        }

        [TestMethod]
        public void RemoveDuplicates_TwoUnique_Test()
        {
            var nums = new int[] { 1, 2 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(2, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { 1, 2 }, false));
        }

        [TestMethod]
        public void RemoveDuplicates_TailDuplicates_Test()
        {
            var nums = new int[] { 0, 0, 2, 2, 2, 2, 3, 4, 5, 5, 5, 6, 6, 8, 8, 10, 10, 10, 12, 13, 20, 20, 20 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(11, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { 0, 2, 3, 4, 5, 6, 8, 10, 12, 13, 20 }, false));
        }

        [TestMethod]
        public void RemoveDuplicates_NegativeValues_Test()
        {
            var nums = new int[] { -10, -10, -8, -7, -3, -3, -1 };

            var result = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);

            Assert.AreEqual(5, result);
            Assert.IsTrue(TestUtils.AreArraysTheSame<int>(nums, new int[] { -10, -8, -7, -3, -1 }, false));
        }
    }
}
