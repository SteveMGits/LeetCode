using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Solution
    {
        public static int solution(int[] A)
        {
            if(A == null || A.Length == 0)
            {
                return 1;
            }
            
            var sorted = A.Select(x => x).OrderBy(x => x).ToArray();

            if (sorted[sorted.Length - 1] <= 0 )
            {
                return 1;
            }

            for(int i = 0; i < sorted.Length - 1; i++) 
            {
                if (sorted[i] < 1)
                {
                    continue;
                }
                
                if ((sorted[i + 1] - sorted[i]) > 1)
                {
                    return sorted[i] + 1;
                }
            }

            return (sorted[sorted.Length - 1]) + 1;
        }
    }

    [TestClass]
    public class SolutionTest
    {
        [TestMethod]
        public void Case1()
        {
            var result = Solution.solution(new int[] { 1, 3, 6, 4, 1, 2 });

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Case2()
        {
            var result = Solution.solution(new int[] { 1, 2, 3 });

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Case3()
        {
            var result = Solution.solution(new int[] { -1, -3 });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Case4()
        {
            var result = Solution.solution(null);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Case5()
        {
            var result = Solution.solution(new int[] { });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Case6()
        {
            var result = Solution.solution(new int[] { -1, -3 , -5, 10, 5, 6, 3, 1, -1, -7, -50, 30 });

            Assert.AreEqual(2, result);
        }
    }
}
