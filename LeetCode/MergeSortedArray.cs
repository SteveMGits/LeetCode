using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopInterview150
{
    public static class MergeSortedArray
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (m + n != nums1.Length)
            {
                throw new ArgumentException("Not enough elements in nums1!");
            }

            // No elements in second array to copy
            if (n == 0)
            {
                return;
            }

            // no elements in first array to merge, just copy second array
            // Array not passed by reference so we need to overwrite the values
            if (m == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    nums1[i] = nums2[i];
                }

                return;
            }


            var newQueue = new Queue<int>(); // Ultimate solution - replace this with single value, if this has value, replace nums2 at some index with this value, store next value here

            var nums1Index = 0;
            var nums2Index = 0;

            while (nums1Index < m)
            {
                if (nums2Index >= n || nums1[nums1Index] <= nums2[nums2Index])
                {
                    nums1Index = writeNums1ToList(newQueue, nums1, nums1Index);
                }

                else if (nums1[nums1Index] >= nums2[nums2Index])
                {
                    nums2Index = writeNums2ToList(newQueue, nums2, nums2Index);
                }
            }

            if (nums1Index >= m)
            {
                // I've read everything from nums 1, empty the queue and drop the rest of nums 2 behind that
                
                var nums1WriteStartIndex = finishWriteFromQueue(newQueue, nums1, m);

                while (nums1WriteStartIndex < nums1.Length)
                {
                    nums1[nums1WriteStartIndex] = nums2[nums2Index];
                    nums1WriteStartIndex += 1;
                    nums2Index += 1;
                }
            }

            else
            {
                //I've read everything from nums2 - empty the queue into nums 1

                finishWriteFromQueue(newQueue, nums1, m);
            }
        }

        private static int writeNums1ToList(Queue<int> newQueue, int[] nums1, int nums1Index)
        {
            if(newQueue.Count != 0)
            {
                newQueue.Enqueue(nums1[nums1Index]);
                nums1[nums1Index] = newQueue.Dequeue();
            }

            return nums1Index + 1;
        }

        private static int writeNums2ToList(Queue<int> newQueue, int[] nums2, int nums2Index)
        {
            newQueue.Enqueue(nums2[nums2Index]);
            return nums2Index + 1;
        }

        private static int finishWriteFromQueue(Queue<int> newQueue, int[] nums1, int nums1WriteStart)
        {
            foreach (int num in newQueue)
            {
                nums1[nums1WriteStart] = num;
                nums1WriteStart += 1;
            }

            return nums1WriteStart;
        }
    }


    [TestClass]
    public class MergeSortedArrayTests
    {
        [TestMethod]
        public void Merge_Test()
        {
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };

            MergeSortedArray.Merge(nums1, 3, new int[] { 2, 5, 6 }, 3);

            checkResult(nums1, new int[] { 1, 2, 2, 3, 5, 6 });
        }

        [TestMethod]
        public void Merge_Nums1ZeroElemTest()
        {
            var nums1 = new int[] { 0, 0 };

            MergeSortedArray.Merge(nums1, 0, new int[] { 2, 5 }, 2);

            checkResult(nums1, new int[] { 2, 5 });
        }

        [TestMethod]
        public void Merge_Nums2ZeroElemTest()
        {
            var nums1 = new int[] { 3, 4 };

            MergeSortedArray.Merge(nums1, 2, new int[] { }, 0);

            checkResult(nums1, new int[] { 3, 4 });
        }

        [TestMethod]
        public void Merge_AllZeroElemTest()
        {
            var nums1 = new int[] { };

            MergeSortedArray.Merge(nums1, 0, new int[] { }, 0);

            checkResult(nums1, new int[] { });
        }

        [TestMethod]
        public void Merge_NegativeElemTest()
        {
            var nums1 = new int[] { -10, -5, -3, -3, -2, 0, 0, 0, 0 };

            MergeSortedArray.Merge(nums1, 5, new int[] { -8, -5, -4, -3 }, 4);

            checkResult(nums1, new int[] { -10, -8, -5, -5, -4, -3, -3, -3, -2 });
        }

        private void checkResult(int[] actual, int[] expected)
        {
            Assert.AreEqual(actual.Length, expected.Length);

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}

