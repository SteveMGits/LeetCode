using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public class MajorityElement
    {
        public static int GetMajorityElement(int[] nums)
        {
            if(nums.Length == 1)
            {
                return nums[0];
            }
            
            var foundElems = new Dictionary<int, int>();
            var majorityCount = Math.Floor(nums.Length / 2.0);

            for (int i = 0; i < nums.Length; i++) 
            {
                if (foundElems.ContainsKey(nums[i]))
                {
                    var newCount = foundElems[nums[i]] + 1;
                    if (newCount > majorityCount)
                    {
                        return nums[i];
                    }
                    
                    foundElems[nums[i]] = newCount;
                }

                else
                {
                    foundElems.Add(nums[i], 1);
                }
            }

            throw new ArgumentException("Provided array has no majority element");
        }
    }

    [TestClass]
    public class MajorityElementTests
    {
        public static readonly string ArgException = "Provided array has no majority element";

        [TestMethod]
        public void Example1Test()
        {
            Assert.AreEqual(3, MajorityElement.GetMajorityElement(new int[] { 3, 2, 3 }));
        }

        [TestMethod]
        public void Example2Test()
        {
            Assert.AreEqual(2, MajorityElement.GetMajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 }));
        }

        [TestMethod]
        public void LeadingMajority()
        {
            Assert.AreEqual(0, MajorityElement.GetMajorityElement(new int[] { 0, 0, 0, 2, 2 }));
        }

        [TestMethod]
        public void TrailingMajority()
        {
            Assert.AreEqual(-4, MajorityElement.GetMajorityElement(new int[] { -3, -3, -3, -4, -4, -4, -4 }));
        }

        [TestMethod]
        public void NoMajorityEvenCount()
        {
            Assert.ThrowsException<ArgumentException>(
                () => MajorityElement.GetMajorityElement(new int[] { -3, -3, -3, -4, -4, -4 }),
                ArgException
                );
        }

        [TestMethod]
        public void NoMajorityOddCount()
        {
            Assert.ThrowsException<ArgumentException>(
                () => MajorityElement.GetMajorityElement(new int[] { -3, -3, -3, 7, -4, -4, -4, -4 }),
                ArgException
                );
        }

        [TestMethod]
        public void NoMajorityAllUnique()
        {
            Assert.ThrowsException<ArgumentException>(
                () => MajorityElement.GetMajorityElement(new int[] { 1, 2, 3, 4, 5 }),
                ArgException
                );
        }

        [TestMethod]
        public void NoMajorityOnlyPlurality()
        {
            Assert.ThrowsException<ArgumentException>(
                () => MajorityElement.GetMajorityElement(new int[] { 3, 3, 3, 5, 6, 7, 8, 3, 10 }),
                ArgException
                );
        }

        [TestMethod]
        public void SingleElement()
        {
            Assert.AreEqual(1, MajorityElement.GetMajorityElement(new int[] { 1 }));
        }

        [TestMethod]
        public void TwoMatchingElement()
        {
            Assert.AreEqual(1, MajorityElement.GetMajorityElement(new int[] { 1, 1 }));
        }

        [TestMethod]
        public void TwoDifferentElement()
        {
            Assert.ThrowsException<ArgumentException>(
                () => MajorityElement.GetMajorityElement(new int[] { 5, 10 }),
                ArgException
                );
        }
    }
}
