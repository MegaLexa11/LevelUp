using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Practice;

public class FileStorage(string filePath) : IProductsStorage
{
    public async Task Save(IEnumerable<ProductItem> productItems)
    {
        // Создаём поток записи в файл
        await using var stream = File.OpenWrite(filePath);
        
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

    public Task Save(ProductItem productItems)
    {
        throw new NotImplementedException();
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

    public Task<IEnumerable<ProductItem>> FetchByName(string productName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductItem>> FetchByCategory(string productCategory)
    {
        throw new NotImplementedException();
    }
}