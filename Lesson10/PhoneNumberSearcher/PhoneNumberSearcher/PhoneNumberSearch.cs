﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneNumberSearcher
{
    internal class PhoneNumberSearch
    {
        public static MatchCollection Search(string strToSearch)
        {
            // Есть стойкое ощущение, что мог сделать что-то не то... Но, по идее, если системой предусмотрены методы работы подобные, то они должны быть наименее затратными?
            // Хотя, с другой стороны, программа возвращает MatchCollection, что может потреблять больше памяти, чем массив строк - но, опять же, изобретать заново регулярки звучит, как что-то сомнительное
            string phonePattern = @"\+[0-9]{1}-[0-9]{3}-[0-9]{3}-[0-9]{4}";
            var stringResult = Regex.Matches(strToSearch, phonePattern);
            return stringResult;
        }

        public static List<string> SearchOptimized(string strToSearch)
        // Явно не то, что ожидалось от спанов, надо еще подумать
        {
            // Есть стойкое ощущение, что мог сделать что-то не то... Но, по идее, если системой предусмотрены методы работы подобные, то они должны быть наименее затратными?
            // Хотя, с другой стороны, программа возвращает MatchCollection, что может потреблять больше памяти, чем массив строк - но, опять же, изобретать заново регулярки звучит, как что-то сомнительное
            string phonePattern = @"\+[0-9]{1}-[0-9]{3}-[0-9]{3}-[0-9]{4}";
            var phoneLength = 15;
            var stringResult = Regex.EnumerateMatches(strToSearch, phonePattern);
            var phones = new List<string>();
            foreach (ValueMatch match in stringResult)
            {
                phones.Add((strToSearch.AsSpan().Slice(match.Index, phoneLength)).ToString());
            }
            return phones;
        }
    }
}