
using DynamicArrayProgram;

DynamicArray<string> IntArr =  new();
IntArr.Add("1");
IntArr.Add("2");
IntArr.Add("3");
IntArr.Add("4");
IntArr.Add("5");
IntArr.Add("6");
IntArr.Add("7");
IntArr.Add("8");
IntArr.Add("9");

IntArr.Remove("5");
IntArr.Remove("7");

foreach (string i in IntArr)
{ 
    Console.WriteLine(i);
}

int index = IntArr.Search("6");
Console.WriteLine(index);
string item = IntArr[2];
Console.WriteLine(item);
