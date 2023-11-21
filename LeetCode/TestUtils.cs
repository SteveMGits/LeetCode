using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class TestUtils
    {
        public static bool AreArraysTheSame<T>(T[] array1, T[] array2, bool shouldCompareLength)
        {
            if(array1 == null || array2 == null)
            {
                // SJM TODO - better message or coalesce null arrays
                throw new ArgumentNullException("Null array as arg!");
            }
            
            if (shouldCompareLength && array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length && i < array2.Length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(array1[i], array2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
