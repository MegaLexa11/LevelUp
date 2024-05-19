using Practice;
using System.Data.Common;

var nomenclature = new Nomenclature();

// 1. Вывести товар с самой высокой ценой

var maxPriceRecord = nomenclature.PriceHistory
    .Where(item => item.Value.History.Count > 0)
    .ToDictionary(
        kvp => kvp.Key,
        kvp => kvp.Value.History.Max(item => item.Price))
    .OrderByDescending(kvp => kvp.Value)
    .FirstOrDefault();

var maxPriceItem = nomenclature.Items.FirstOrDefault(item => item.Id.Equals(maxPriceRecord.Key));
Console.WriteLine($"ID: {maxPriceItem?.Id}, Name: {maxPriceItem?.Name}, Price: {maxPriceRecord.Value}");
Console.WriteLine();


// 2. Вывести список товаров категории "Товары для спорта" в порядке по убыванию


var sportItems = nomenclature.Items.Where(item => item.Category.Name == "Товары для спорта").OrderBy(item => item.Name);
foreach(var sportItem in sportItems)
{
    Console.WriteLine(sportItem);
}
Console.WriteLine();

// 3. Вывести самый дешевый товар категории "Офисные товары и канцелярия"

var officeItems = nomenclature.Items.Where(item => item.Category.Name == "Офисные товары и канцелярия");
var officeItemsWithPrice = officeItems.Join(
    nomenclature.PriceHistory.Where(item => item.Value.History.Count > 0),
    i => i.Id,
    ph => ph.Key,
    (i, ph) => new { ID = i.Id, Name = i.Name, Price = ph.Value.History.Min(item => item.Price) }).OrderBy(item => item.Price);
var cheapestItem = officeItemsWithPrice.FirstOrDefault();
Console.WriteLine(cheapestItem);
Console.WriteLine();


// 4. Вывести товары, у которых отсутствует цена в истории цен

var itemsWithoutPrice = nomenclature.Items.Where(item => nomenclature.PriceHistory[item.Id].History.Count() == 0);
foreach (var item in itemsWithoutPrice)
{
    Console.WriteLine(item);
}
Console.WriteLine();


// 5. Вывести товары, у которых цена менялась наибольшее количество раз
var itemsWithFrequentPrice = nomenclature.Items.Where(
    item => nomenclature.PriceHistory[item.Id].History.Count() == 
        nomenclature.PriceHistory.Max(item => item.Value.History.Count()));
foreach (var item in itemsWithFrequentPrice)
{
    Console.WriteLine(item);
}
Console.WriteLine();

// 6. Вывести товары, у которых цена менялась наименьшее количество времени назад
var itemsWithPrice = nomenclature.PriceHistory.Where(item => item.Value.History.Count > 0).ToDictionary();
var MinDayDifference = itemsWithPrice.Min(item => item.Value.History.
    Min(item => (DateTime.Today - item.Date).TotalDays));

var LastUpadatedPriceItems = nomenclature.Items
    .Where(item => nomenclature.PriceHistory[item.Id].History.Count() > 0) // Наверно, не самое изящное решение, но работает
    .Where(item => nomenclature.PriceHistory[item.Id].History
        .Min(item => (DateTime.Today - item.Date).TotalDays) == MinDayDifference);

foreach (var item in LastUpadatedPriceItems)
{
    Console.WriteLine(item);
}
Console.WriteLine();

// 7. Вывести день, в который произошло наибольшее количество изменений цен товаров, и количество таких изменений
// Тут мозг отказался подумать
var productPriceChangeDateDict = nomenclature.PriceHistory.Select(Item => Item.Value.History.Select(item => item.Date)); 
Console.WriteLine(productPriceChangeDateDict.Count());
Console.WriteLine();

// 8. Вывести перечень категорий с их средней ценой за товар

//Тут получилось только по шагам
var itemsWithPriceHistory = nomenclature.PriceHistory.Where(item => item.Value.History.Count > 0);
var itemIdWithLastPrice = itemsWithPriceHistory.Select(item => new
{
    Id = item.Key,
    Price = (from p in item.Value.History
    orderby p.Date descending
    select p.Price).FirstOrDefault()
});

var categoriesWithPrice = nomenclature.Items.Join(
    itemIdWithLastPrice,
    i => i.Id,
    ip => ip.Id,
    (i, ip) => new { Category = i.Category.Name, Price = ip.Price }
    ).GroupBy(item => item.Category);

var categoriesWithAvgPrice = categoriesWithPrice.Select(item => new {Category = item.Key, AvgPrice = item.Average(item => item.Price)});
foreach (var item in categoriesWithAvgPrice)
{
    Console.WriteLine(item);
}
Console.WriteLine();


// 9. Вывести товары категорий "Игрушки" и "Товары для спорта" дороже 500 рублей

string[] categoryNames = ["Игрушки", "Товары для спорта"];
int priceToCheck = 500;

// Используем здесь выборки из предыдущего задания: itemsWithPriceHistory, itemIdWithLastPrice

var categoriesWithItemsAndPrices = nomenclature.Items.Join(
    itemIdWithLastPrice,
    i => i.Id,
    ip => ip.Id,
    (i, ip) => new { Category = i.Category.Name, Name = i.Name, Price = ip.Price }
    );

var CategoriesWithItemsFilteredByPrice = categoriesWithItemsAndPrices.Where(item => categoryNames.Contains(item.Category) && item.Price > priceToCheck);
foreach (var item in CategoriesWithItemsFilteredByPrice)
{
    Console.WriteLine(item);
}
