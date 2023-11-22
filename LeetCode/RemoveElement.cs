using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopInterview150
{
    public class RemoveElementClass
    {
        public static int RemoveElement(int[] nums, int val)
        {
            var backIndex = nums.Length - 1;
            var currentIndex = 0;

            while (currentIndex <= backIndex)
            {
                if (nums[currentIndex] != val)
                {
                    currentIndex += 1;
                }

                else
                {
                    nums[currentIndex] = nums[backIndex];
                    backIndex -= 1;
                }
            }

            return backIndex + 1;
        }
    }

    [TestClass]
    public class RemoveElementTests
    {
        [TestMethod]
        public void RemoveElementTest() 
        {
            var result = RemoveElementClass.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);
            // SJM TODO - asserts?
        }
    }
}
