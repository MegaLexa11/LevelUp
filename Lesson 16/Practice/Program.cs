using Practice;

var productItems = new[]
{
    new ProductItem(Guid.NewGuid(), "Мяч", "Инвентарь"),
    new ProductItem(Guid.NewGuid(), "Ворота", "Инвентарь"),
    new ProductItem(Guid.NewGuid(), "Вратарские перчатки", "Аммуниция"),
    new ProductItem(Guid.NewGuid(), "Бутсы", "Аммуниция"),
    new ProductItem(Guid.NewGuid(), "Щитки", "Аммуниция"),
    new ProductItem(Guid.NewGuid(), "Шорты", "Аммуниция"),
    new ProductItem(Guid.NewGuid(), "Наколенники", "Аммуниция"),
};

var productItem1 = new ProductItem(Guid.NewGuid(), "Сетка", "Инвентарь");

var filePath = "products.txt";
IProductsStorage fileStorage = new FileStorage(filePath);

// Сохраняем товары в файл
//await fileStorage.Save(productItems, true);
await fileStorage.Save(productItems, true);

await fileStorage.Save(productItem1);

var restoredItems = await fileStorage.Fetch();
foreach (var item in restoredItems)
{
    Console.WriteLine(item);
}

var sneakers = await fileStorage.FetchByName("Бутсы");
foreach (var item in sneakers)
{
    Console.WriteLine(item.Name);
}

var inventory = await fileStorage.FetchByCategory("Инвентарь");
foreach (var item in inventory)
{
    Console.WriteLine(item.Name);
}


