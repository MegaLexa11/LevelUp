
using DynamicArrayProgram;

DynamicArray<string> intArr =  new();
intArr.Add("1");
intArr.Add("2");
intArr.Add("3");
intArr.Add("4");
intArr.Add("5");
intArr.Add("6");
intArr.Add("7");
intArr.Add("8");
intArr.Add("9");

intArr.Remove("5");
intArr.Remove("7");

foreach (string i in intArr)
{ 
    Console.WriteLine(i);
}

int index = intArr.Search("6");
Console.WriteLine(index);
string item = intArr[2];
Console.WriteLine(item);
