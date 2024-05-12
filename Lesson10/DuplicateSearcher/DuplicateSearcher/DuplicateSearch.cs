using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearcher
{
    internal static class DuplicateSearch
    {
        public static int Search(string baseStr, string duplicateStr)
        {
            int duplicateCount = 0;
            int indexOfSubstr = 0;
            int slicePos = 0;
            while (true)
            {
                indexOfSubstr = baseStr.AsSpan()[slicePos..].IndexOf(duplicateStr);
                if (indexOfSubstr != -1) 
                {
                    duplicateCount++;
                    slicePos += indexOfSubstr + duplicateStr.Length;
                }
                else
                {
                    break;
                }
            }
            return duplicateCount;
        }

    }
}
