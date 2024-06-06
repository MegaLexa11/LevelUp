using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Practice;

public class FileStorage(string filePath) : IProductsStorage
{
    public async Task Save(IEnumerable<ProductItem> productItems, bool IsOverwrite)
    {
        if (!IsOverwrite)
        {
            var existingItems = await Fetch();
            var ItemsToAdd = productItems.
                Where(item => !existingItems.Select(exItem => exItem.Id).
                Contains(item.Id));
            productItems = existingItems.Concat(ItemsToAdd);
        }

        // Создаём поток записи в файл
        //await using var stream = File.OpenWrite(filePath);
        await using var stream = File.Create(filePath);

        // Сериализуем список продуктов в JSON
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        var content = JsonSerializer.Serialize(productItems, options);
        
        // Конвертируем JSON в байты
        var bytes = Encoding.UTF8.GetBytes(content);
        
        // Записываем в файл
        await stream.WriteAsync(bytes);
    }

    public async Task Save(ProductItem productItem)
    {
        var existingItems = await Fetch();
        if (!existingItems.Any(item => item.Id == productItem.Id))
        {
            await using var stream = File.OpenWrite(filePath);

            existingItems = existingItems.Append(productItem);

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var content = JsonSerializer.Serialize(existingItems, options);
            var bytes = Encoding.UTF8.GetBytes(content);

            await stream.WriteAsync(bytes);
        }
        
    }

    public async Task<IEnumerable<ProductItem>> Fetch()
    {
        // Читаем содержимое файла
        var content = await File.ReadAllTextAsync(filePath);
        
        // Десериализуем в IEnumerable<ProductItem>
        var productItems = JsonSerializer.Deserialize<IEnumerable<ProductItem>>(content)
                           ?? Enumerable.Empty<ProductItem>();

        // Возвращаем нужные нам объекты
        return productItems;
    }

    public async Task<IEnumerable<ProductItem>> FetchByName(string productName)
    {
        var productItems = await Fetch();
        return productItems.Where(item => item.Name == productName);
    }

    public async Task<IEnumerable<ProductItem>> FetchByCategory(string productCategory)
    {
        var productItems = await Fetch();

        return productItems.Where(item => item.Category == productCategory);
    }
}