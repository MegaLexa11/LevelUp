using GenericFileStorage;

var storage = new FileDataStorage("items.txt");

IContainsId numItem = new IntWithId(1);
IContainsId strItem = new StrWithId("a");
IContainsId strItem2 = new StrWithId("b");

IContainsId[] items = [numItem, strItem];


await storage.Save(items, true);

await storage.Save(strItem2);

/*var restoredItems = await storage.Fetch();
foreach (var item in restoredItems)
{
    Console.WriteLine(item);
}*/