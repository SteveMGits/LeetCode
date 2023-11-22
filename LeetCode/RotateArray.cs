using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public static class RotateArray
    {
        public static void Rotate(int[] nums, int k)
        {
            if(nums.Length == 1)
            {
                return;
            }

            if(k >= nums.Length)
            {
                k = k % nums.Length;
                
                if(k == 0) 
                {
                    return;
                }
            }
            
            // space efficient - read one thing, shuffle everything else, replace thing, repeat

            // time efficient - read everything from k inclusive to the end of the array into queue, then read the beginning, then replace
            // TODO - only queue the overlap necessary based on value of k
            
            var queue = new Queue<int>();

            for (int i = nums.Length - k; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < nums.Length - k; i++)
            {
                queue.Enqueue(nums[i]);
            }

            int index = 0;
            while (queue.TryPeek(out int result))
            {
                nums[index] = queue.Dequeue();
                index++;
            }
        }
    }

    [TestClass]
    public class RotateArrayTests
    {
        [TestMethod]
        public void Example1()
        {
            var start = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 5, 6, 7, 1, 2, 3, 4 };

            RotateArray.Rotate(start, 3);

            Assert.IsTrue(doArraysMatch(start, expected));
        }

        [TestMethod]
        public void Example2()
        {
            var start = new int[] { -1, -100, 3, 99 };
            var expected = new int[] { 3, 99, -1, -100 };

            RotateArray.Rotate(start, 2);

            Assert.IsTrue(doArraysMatch(start, expected));
        }

        [TestMethod]
        public void basicEventCount()
        {
            var start = new int[] { 1, 2, 3, 4 };
            var expected = new int[] { 3, 4, 1, 2 };

            RotateArray.Rotate(start, 2);

            Assert.IsTrue(doArraysMatch(start, expected));
        }

        [TestMethod]
        public void basicEventCount2() // TODO - rename
        {
            var start = new int[] { 1, 2, 3, 4 };
            var expected = new int[] { 2, 3, 4, 1};

            RotateArray.Rotate(start, 3);

            Assert.IsTrue(doArraysMatch(start, expected));
        }

        [TestMethod]
        public void KIsLengthOfArray()
        {
            var start = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            RotateArray.Rotate(start, 7);

            Assert.IsTrue(doArraysMatch(start, expected));
        }

        [TestMethod]
        public void KIsMultipleOfLengthOfArray()
        {
            var start = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            RotateArray.Rotate(start, 14);

            Assert.IsTrue(doArraysMatch(start, expected));
        }

        [TestMethod]
        public void KIsLargerThanArray()
        {
            var start = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var expected = new int[] { 5, 6, 7, 1, 2, 3, 4 };

            RotateArray.Rotate(start, 10);

            Assert.IsTrue(doArraysMatch(start, expected));
        }


        private bool doArraysMatch(int[] array1, int[] array2)
        {
            for(int i =  0; i < array1.Length; i++) 
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
