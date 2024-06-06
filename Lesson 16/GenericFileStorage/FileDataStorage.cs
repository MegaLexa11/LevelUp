using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal class FileDataStorag<T>(string filePath): IDataStorage<T>
    {
        public async Task Save(IEnumerable<T> items, bool IsOverwrite)
        {
            if (!IsOverwrite)
            {
                var existingItems = await Fetch();
                var ItemsToAdd = items.
                    Where(item => !existingItems.Select(exItem => exItem.Id).
                    Contains(item.Id));
                items = existingItems.Concat(ItemsToAdd);
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
            var content = JsonSerializer.Serialize(items, options);

            // Конвертируем JSON в байты
            var bytes = Encoding.UTF8.GetBytes(content);

            // Записываем в файл
            await stream.WriteAsync(bytes);
        }

        public async Task Save(T Item)
        {
            var existingItems = await Fetch();
            if (!existingItems.Any(itemEx => itemEx.Id == Item.Id))
            {
                await using var stream = File.OpenWrite(filePath);

                existingItems = existingItems.Append(Item);

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

        public async Task<IEnumerable<T>> Fetch()
        {
            // Читаем содержимое файла
            var content = await File.ReadAllTextAsync(filePath);

            // Десериализуем в IEnumerable<ProductItem>
            var items = JsonSerializer.Deserialize<IEnumerable<IContainsId>>(content)
                               ?? Enumerable.Empty<IContainsId>();

            // Возвращаем нужные нам объекты
            return items;
        }

        public async Task<IEnumerable<T>> FetchById(Guid Id)
        {
            var items = await Fetch();
            return items.Where(item => item.Id == Id);
        }
    }
}
