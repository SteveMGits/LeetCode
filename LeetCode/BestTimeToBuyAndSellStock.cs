using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterview150
{
    public static class BestTimeToBuyAndSellStock
    {
        public static int MaxProfit(int[] prices)
        {
            if(prices == null || prices.Length < 2)
            {
                return 0;
            }
            
            var maxProfit = 0;

            int lowestSeenBuyPrice = prices[0];
            int highestNextSalePriceIndex = 0;
            
            for(int buyPriceIndex = 0; buyPriceIndex < prices.Length - 1; buyPriceIndex++) 
            {
                if (prices[buyPriceIndex] > lowestSeenBuyPrice)
                {
                    continue;
                }
                else
                {
                    lowestSeenBuyPrice = prices[buyPriceIndex];
                }

                if(buyPriceIndex >= highestNextSalePriceIndex)
                {
                    highestNextSalePriceIndex = buyPriceIndex + 1;
                    for (int sellPriceIndex = buyPriceIndex + 2; sellPriceIndex < prices.Length; sellPriceIndex++)
                    {
                        if (prices[sellPriceIndex] >= prices[highestNextSalePriceIndex])
                        {
                            highestNextSalePriceIndex = sellPriceIndex;
                        }
                    }
                }

                var potentialProfit = prices[highestNextSalePriceIndex] - lowestSeenBuyPrice;
                if (potentialProfit > maxProfit)
                {
                    maxProfit = potentialProfit;
                }
            }

            return maxProfit;
        }
    }

    [TestClass]
    public class BestTimeToBuyAndSellStockTests
    {
        [TestMethod]
        public void Example1()
        {
            Assert.AreEqual(5, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }

        [TestMethod]
        public void Example2()
        {
            Assert.AreEqual(0, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 7, 6, 4, 3, 1 }));
        }

        [TestMethod]
        public void NullPrices()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.AreEqual(0, BestTimeToBuyAndSellStock.MaxProfit(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void EmptyPrices()
        {
            Assert.AreEqual(0, BestTimeToBuyAndSellStock.MaxProfit(new int[] { }));
        }

        [TestMethod]
        public void OnePrice()
        {
            Assert.AreEqual(0, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 20 }));
        }

        [TestMethod]
        public void LowestBuyPriceAfterHighestSalePriceIsMoreProfit()
        {
            Assert.AreEqual(98, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 30, 25, 20, 100, 50, 1, 45, 99 }));
        }

        [TestMethod]
        public void LowerBuyPriceAfterHighestSalePriceIsLessProfit()
        {
            Assert.AreEqual(95, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 5, 5, 10, 20, 100, 10, 0, 2 }));
        }

        [TestMethod]
        public void MaxProfitIsFirstAndLastOfThree()
        {
            Assert.AreEqual(3, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 1, 2, 4 }));
        }

        [TestMethod]
        public void MaxProfitIsSecondAndLastOfThree()
        {
            Assert.AreEqual(3, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 2, 1, 4 }));
        }

        [TestMethod]
        public void ShortCircuitTrailingSmallValues()
        {
            Assert.AreEqual(3, BestTimeToBuyAndSellStock.MaxProfit(new int[] { 5, 3, 6, 5, 4, 3, 2, 1, 3 }));
        }
    }

}
