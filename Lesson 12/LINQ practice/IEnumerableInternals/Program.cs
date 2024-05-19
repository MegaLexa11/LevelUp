// ПРИМЕР 1
// Обход массива строк через интерфейс IEnumerable<string>

// Интерфейс IEnumerable предоставляет контракт, согласно которому объект (например, коллекция) можно проитерировать.
// Единственный метод этого интерфейса возвращает объект IEnumerator, который "знает", как итерироваться по объекту.

using IEnumerableInternals;

IEnumerable<string> words = ["so", "glad", "to", "learn", "LINQ"];

// IEnumerator является IDisposable-объектом - объектом, потенциально содержащим неуправляемые объекты. По этой причине
// при явном создании экземпляра энумератора стоит обернуть его в конструкцию using (см. Lesson 18).
using IEnumerator<string> enumerator = words.GetEnumerator();

// IEnumerator инкапсулирует логику обхода IEnumerable-объекта внутри метода MoveNext. Пока MoveNext возвращает true,
// мы не достигли конца итерируемого объекта.
while (enumerator.MoveNext())
{
    // Значение свойства Current всегда указывает на текущий элемент в итерируемом объекте.
    Console.WriteLine(enumerator.Current);
}

// ПРИМЕР 2 - кастомная реализация IEnumerator
var set = new RandomNumbersSet(5);
foreach (var item in set)
{
    Console.Write(item + " ");
}