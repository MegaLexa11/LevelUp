using Practice;

var nomenclature = new Nomenclature();

// 1. Вывести товар с самой высокой ценой

// 2. Вывести список товаров категории "Товары для спорта" в порядке по убыванию

// 3. Вывести самый дешевый товар категории "Офисные товары и канцелярия"

// 4. Вывести товары, у которых отсутствует цена в истории цен

// 5. Вывести товары, у которых цена менялась наибольшее количество раз

// 6. Вывести товары, у которых цена менялась наименьшее количество времени назад

// 7. Вывести день, в который произошло наибольшее количество изменений цен товаров, и количество таких изменений

var mostFrequentDate = nomenclature.PriceHistory
    .SelectMany(item => item.Value.History)
    .GroupBy(item => item.Date)
    .Select(item => new { Date = item.Key, ItemsChanged = item.Count() }) // Немного натянутое решение, но, возможно, так лучше воспринимается
    .GroupBy(item => item.ItemsChanged)
    .OrderByDescending(item => item.Key)
    .FirstOrDefault();
    

foreach(var item in mostFrequentDate)
{
    Console.WriteLine(item.Date);
}


Console.WriteLine();

// 8. Вывести перечень категорий с их средней ценой за товар
// По сути, еще в прошлое дз удалось сделать через анонимные типы, было бы логично сделать без них, но что-то другая реализация вообще в голове не рождается
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

var categoriesWithAvgPrice = categoriesWithPrice.Select(item => new { Category = item.Key, AvgPrice = item.Average(item => item.Price) });
foreach (var item in categoriesWithAvgPrice)
{
    Console.WriteLine(item);
}
Console.WriteLine();

// 9. Вывести товары категорий "Игрушки" и "Товары для спорта" дороже 500 рублей

