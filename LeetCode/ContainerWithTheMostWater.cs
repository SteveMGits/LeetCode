using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ContainerWithTheMostWater
    {
        public static int MaxArea(int[] height)
        {
            var startIndex = 0;
            var endIndex = height.Length - 1;

            var biggestAreaSeen = 0;

            while(startIndex != endIndex)
            {
                var currentArea = getActualArea(height, startIndex, endIndex);

                if(currentArea > biggestAreaSeen)
                {
                    biggestAreaSeen = currentArea;
                }

                if (height[startIndex] > height[endIndex])
                {
                    endIndex -= 1;
                }
                else
                {
                    startIndex += 1;
                }
            }

            return biggestAreaSeen;
        }


        public static int MaxAreaOld(int[] height)
        {
            if(height.Length == 2)
            {
                return getActualArea(height, 0, 1);
            }

            var biggestAreaSeen = 0;

            var tallestStartWall = 0;

            for(int startIndex = 0; startIndex < height.Length - 1; startIndex++)
            {
                if (height[startIndex] == 0)
                {
                    continue;
                }

                if(tallestStartWall >= height[startIndex])
                {
                    continue;
                }
                else
                {
                    tallestStartWall = height[startIndex];
                }

                var biggestPossibleAreaForStartIndex = getBiggestPossibleArea(height, startIndex);

                if(biggestAreaSeen > biggestPossibleAreaForStartIndex)
                {
                    continue;
                }

                var tallestEndWall = 0;

                for (int endIndex = height.Length - 1; endIndex > startIndex; endIndex--) 
                {   
                    if(tallestEndWall >= height[startIndex])
                    {
                        break;
                    }
                    
                    if (height[endIndex] == 0 || height[endIndex] < tallestEndWall)
                    {
                        continue;
                    }

                    if (height[endIndex] > tallestEndWall)
                    {
                        tallestEndWall = height[endIndex];
                    }

                    var biggestPossibleAreaForEndIndex = getBiggestPossibleArea(height, startIndex, endIndex);

                    if(biggestPossibleAreaForEndIndex < biggestAreaSeen)
                    {
                        break;
                    }

                    var currentArea = getActualArea(height, startIndex, endIndex);

                    if(currentArea > biggestAreaSeen)
                    {
                        biggestAreaSeen = currentArea;
                    }
                }              
            }

            return biggestAreaSeen;
        }

        private static int getActualArea(int[] heightArray, int startIndex, int endIndex) 
        {
            var height = Math.Min(heightArray[startIndex], heightArray[endIndex]);
            var width = Math.Abs(endIndex - startIndex);

            return height * width;
        }

        private static int getBiggestPossibleArea(int[] heightArray, int startIndex)
        {
            var height = heightArray[startIndex];
            var width = heightArray.Length - startIndex;

            return height * width;
        }

        private static int getBiggestPossibleArea(int[] heightArray, int startIndex, int endIndex)
        {
            var height = heightArray[startIndex];
            var width = Math.Abs(endIndex - startIndex);

            return height * width;
        }
    }

    [TestClass]
    public class ContainerWithTheMostWaterTests
    {
        [TestMethod]
        public void MaxArea_Case1_Test()
        {
            var result = ContainerWithTheMostWater.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });

            Assert.AreEqual(49, result);
        }

        [TestMethod]
        public void MaxArea_Case2_Test()
        {
            var result = ContainerWithTheMostWater.MaxArea(new int[] { 1, 1 });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MaxArea_TallSkinnyBucket_Test()
        {
            var result = ContainerWithTheMostWater.MaxArea(new int[] { 1, 3, 2, 5, 25, 24, 5 });

            Assert.AreEqual(24, result);
        }
    }
}
