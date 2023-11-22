using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopInterview150
{
    public static class TwoSumClass
    {
        public static int[] TwoSumOld(int[] nums, int target) // Memory optimized but only barely
        {
            for (int skip = 0; skip < nums.Length - 1; skip++)
            {
                for (int i = skip + 1; i < nums.Length; i++)
                {
                    if (nums[skip] + nums[i] == target)
                    {
                        return new int[2] { skip, i };
                    }
                }
            }

            throw new ArgumentException("Bad args!");
        }

        public static int[] TwoSum(int[] nums, int target) // Runtime optimized
        {
            var objectDict = new Dictionary<int, object>(); // value, index 1, index 2 (don't need more than that)

            for (int i = 0; i < nums.Length; i++)
            {
                if (objectDict.TryGetValue(nums[i], out var index))
                {
                    if (index.GetType() == typeof(int))
                    {
                        var oldIndex = (int)index;

                        objectDict[nums[i]] = new int[2] { oldIndex, i };
                    }
                }
                else
                {
                    objectDict.Add(nums[i], i);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var valueNeeded = target - nums[i];

                if (objectDict.TryGetValue(valueNeeded, out var index))
                {
                    if (index.GetType() == typeof(int))
                    {
                        if ((int)index == i)
                        {
                            continue;
                        }

                        return new int[2] { i, (int)index };
                    }
                    else
                    {
                        var indexes = (int[])index;

                        var returnIndex = indexes[0] != i ? indexes[0] : indexes[1];

                        return new int[2] { i, returnIndex };
                    }
                }
            }

            throw new ArgumentException("Bad args!");
        }
    }

    [TestClass]
    public class TwoSumTests
    {
        [TestMethod]
        public void TwoSumTest_SimpleList()
        {
            this.doTwoSumTest(new int[] { 1, 2, 3 }, 5, 1, 2);
        }

        [TestMethod]
        public void TwoSumTest_OneZero()
        {
            this.doTwoSumTest(new int[] { 5, 10, 0, 23, 64 }, 23, 2, 3);
        }

        [TestMethod]
        public void TwoSumTest_TwoZeroes()
        {
            this.doTwoSumTest(new int[] { 5, 10, 0, 23, 64, 0 }, 0, 2, 5);
        }

        private void doTwoSumTest(int[] nums, int target, int expectedIndex1, int expectedIndex2)
        {
            var result = TwoSumClass.TwoSum(nums, target);

            Assert.AreEqual(result[0], expectedIndex1);
            Assert.AreEqual(result[1], expectedIndex2);
        }
    }
}
