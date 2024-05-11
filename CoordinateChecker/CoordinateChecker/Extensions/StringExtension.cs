using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateChecker.Extensions
{
    internal static class StringExtension
    {
        // Чтобы узнавать, каким осям параллельна плоскость
        public static string AllNotIncluded(this string baseStr, string compareStr)
        {
            char[] charArr = new char[compareStr.Length];
            int lastIndexAddeed = 0;
            foreach (char c in compareStr) 
            {
                if (!baseStr.Contains(c) && !charArr.Contains(c))
                {
                    charArr[lastIndexAddeed++] = c;
                }
            }

            char[] resultCharArr = new char[lastIndexAddeed];
            Array.Copy(charArr, resultCharArr, lastIndexAddeed);

            return new string(resultCharArr);
        }
    }
}
