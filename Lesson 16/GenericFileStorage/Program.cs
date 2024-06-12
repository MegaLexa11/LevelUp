using GenericFileStorage;

var storage1 = new FileDataStorage<StrWithId>("items.txt");

StrWithId strItem = new StrWithId("F");
StrWithId strItem2 = new StrWithId("C");

StrWithId[] items = [strItem, strItem2];
Console.WriteLine(strItem.Id);
Console.WriteLine(strItem.Value);
Console.WriteLine(strItem2.Id);
Console.WriteLine(strItem2.Value);
Console.WriteLine();


await storage1.Save(items, false);

var restoredItems = await storage1.Fetch();
foreach (var item in restoredItems)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Value);
}
Console.WriteLine();


var foundItems = await storage1.FetchById(strItem.Id);
foreach (var item in foundItems)
{
    Console.WriteLine($"{item.Id} {item.Value}");
}
