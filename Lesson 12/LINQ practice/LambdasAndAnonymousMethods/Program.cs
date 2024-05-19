/* Лямбда-выражение - это самостоятельный блок кода, представляющий из себя способ реализации анонимного метода.
Анонимные методы, в свою очередь, могут использоваться для локальных вычислений, а также могут быть переиспользованы
посредством механизма делегатов (см. Lesson 13)*/

/* В данном примере лямбда-выражение (анонимный метод) находится справа от оператора присванивания.
Лямбда-выражение состоит из левой и правой частей, разделенных символом =>.
В левой части лямбда-выражения описываются входные параметры, в правой - логика их обработки.
*/

var lambda = (string item) => item.StartsWith("a", StringComparison.OrdinalIgnoreCase);

// Представим, что у нас есть некоторый массив имён. Выберем из него имена, начинающиеся на букву 'a'.
string[] names = ["Aleksandr", "Aleksey", "Vasiliy"];

// Вариант 1 - используем вышеописанное лямбда-выражение
var aNames = names.Where(lambda);
PrintNames(aNames);

/* Вариант 2 - используем лямбда-выражение напрямую как параметр метода Where.
Обратите внимание, что тип параметра указывать не обязательно - компилятор выведет его из типа коллекции,
на котором вызывается метод Where.
*/
aNames = names.Where(item => item.StartsWith("a", StringComparison.OrdinalIgnoreCase));
PrintNames(aNames);

// Вариант 3 - выделим логику фильтрации
aNames = names.Where(Filter);
PrintNames(aNames);

// Метод, использующийся в качестве MethodGroup, должен совпадать по сигнатуре с параметром метода Where -
// он должен принимать единичный объект string и возвращать bool.
bool Filter(string item)
{
    return item.StartsWith("a", StringComparison.OrdinalIgnoreCase);
}

// Метод Where является одним из extension-методов механизма LINQ.

void PrintNames(IEnumerable<string> items)
{
    foreach (var name in items)
    {
        Console.WriteLine(name);
    }
    
    Console.WriteLine();
}


