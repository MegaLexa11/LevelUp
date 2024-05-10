using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateChecker.Extensions
{
    internal static class ArrayExtension
    {
        public static T RarestEl<T>(this T[] arr)
        {
            var elDict = new Dictionary<T, int>();

            foreach (T el in arr)
            {
                if (elDict.ContainsKey(el))
                {
                    elDict[el] += 1;
                }
                else
                {
                    elDict[el] = 1;
                }
            }

            T rarestEl = elDict.FirstOrDefault().Key;
            int occurencies = elDict[rarestEl];

            foreach (var pair in elDict)
            {
                if (pair.Value < occurencies)
                {
                    rarestEl = pair.Key;
                    occurencies = pair.Value;
                }
            }
            return rarestEl;
        }
    }
}
