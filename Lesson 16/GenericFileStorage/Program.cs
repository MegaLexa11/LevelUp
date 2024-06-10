using GenericFileStorage;

var storage1 = new FileDataStorage<StrWithId>("items.txt");

StrWithId strItem = new StrWithId("a");
StrWithId strItem2 = new StrWithId("b");

StrWithId[] items = [strItem, strItem2];
Console.WriteLine(strItem.Id);

await storage1.Save(items, true);

storage1 = new FileDataStorage<StrWithId>("items.txt");
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
