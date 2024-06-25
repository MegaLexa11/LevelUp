
using DuplicateSearcher;

string baseStr = "This is the test string with a lot of useless information. This is for test purposes!";
string subStr = "es";

//int indexOfSubstr = baseStr[84..].IndexOf(subStr);
//Console.WriteLine(indexOfSubstr);

int subEntries = DuplicateSearch.Search(baseStr, subStr);
Console.WriteLine(subEntries);