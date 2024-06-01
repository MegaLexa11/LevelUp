using Practice;

var productItems = new[]
{
    new ProductItem(Guid.NewGuid(), "Мяч", "Инвентарь"),
    new ProductItem(Guid.NewGuid(), "Ворота", "Инвентарь"),
    new ProductItem(Guid.NewGuid(), "Вратарские перчатки", "Аммуниция"),
    new ProductItem(Guid.NewGuid(), "Бутсы", "Аммуниция"),
    new ProductItem(Guid.NewGuid(), "Щитки", "Аммуниция"),
};

//var filePath = "C:\\Users\\kukh9\\Desktop\\LevelUp\\products.txt";
var filePath = "products.txt";
IProductsStorage fileStorage = new FileStorage(filePath);

// Сохраняем товары в файл
await fileStorage.Save(productItems);

var restoredItems = await fileStorage.Fetch();
foreach (var item in restoredItems)
{
    Console.WriteLine(item);
}

