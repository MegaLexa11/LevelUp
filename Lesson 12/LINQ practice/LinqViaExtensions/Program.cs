using LinqViaExtensions;

int[] numbers = [12, -45, 78, -1, 83];

string[] names = ["Aleksandr", "Aleksey", "Vasiliy"];

IStudent[] abstractStudents = [
    new Student(1, "Vladimir"),
    new Student(2, "Petr"),
    new Student(3, "Stepan"),
];

Where();
// Select();
// FirstAndLast();
// Take();
// Skip();
// Group();
// Intersect();
// Except();
// Distinct();
// Cast();
// Sort();
//Join();
//UseSeveralMethods();

// 1. Фильтрация
void Where()
{
    var negative = numbers.Where(item => item < 0);
    PrintItems(negative, "negative");

    // Условия фильтрации можно комбинировать
    var rangeOne = numbers.Where(item => item > 0 && item < 100);
    PrintItems(rangeOne, "rangeOne");

    // Можно использовать шаблонные выражения (pattern)
    var rangeTwo = numbers.Where(item => item is > 0 and < 100);
    PrintItems(rangeTwo, "rangeTwo");
}

// 2. Маппинг - создание новых объектов на основании существующих
void Select()
{
    var incremented = numbers.Select(item => ++item);
    PrintItems(incremented, "incremented");
    
    var id = 0;
    // Переменная id "захватывается" скоупом лямбда-выражения - такой приём называется "замыкание".
    var students = names.Select(name => new Student(++id, name));
    PrintItems(students, "students");
}

// 3. Получение первого/последнего элемента коллекции
void FirstAndLast()
{
    var first = names.First(); // Получение первого элемента
    Console.WriteLine(first); // Aleksandr

    var firstNameFromV = names.First(name => name.StartsWith("a", StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(firstNameFromV); // Vasiliy

    // System.InvalidOperationException: Sequence contains no matching element - нет имени на s
    // var firstNameFromS = names.First(name => name.StartsWith("s", StringComparison.OrdinalIgnoreCase));

    // Безопасный поиск - вернёт null, если по заданному условию не найдётся элемента в коллекции
    var firstNameFromS = names.FirstOrDefault(name => name.StartsWith("s", StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(firstNameFromS is null); // true

    var last = names.Last();
    Console.WriteLine(last); // Vasiliy

    var lastNameFromA = names.LastOrDefault(name => name.StartsWith("a", StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(lastNameFromA); // Aleksey
}

// 4. Взять первые N элементов
void Take()
{
    var firstTwo = names.Take(2);
    PrintItems(firstTwo, "firstTwo");
}

// 5. Пропустить первые N элементов
void Skip()
{
    var lastOnes = names.Skip(1);
    PrintItems(lastOnes, "lastOnes");
}

// 6. Сгруппировать коллекцию
void Group()
{
    var groups = names.GroupBy(name => name.First()).ToArray();
    Console.WriteLine(groups.Length); // 2
    foreach (var group in groups)
    {
        PrintItems(group.AsEnumerable(), group.Key.ToString());
    }
}

// 7. Пересечение множеств
void Intersect()
{
    string[] anotherNames = ["Aleksandr", "Ivan", "Vladimir"];
    var commonItems = names.Intersect(anotherNames);
    PrintItems(commonItems, "commonItems");
}

// 8. Исключение элементов второго множества из первого
void Except()
{
    string[] anotherNames = ["Aleksandr", "Ivan", "Vladimir"];
    var uniqueNamesInFirstCollection = names.Except(anotherNames);
    PrintItems(uniqueNamesInFirstCollection, "uniqueNamesInFirstCollection");
}

// 9. Уникальные элементы
void Distinct()
{
    int[] nonUniqueNumbers = [1, 0, 0, 1, 0, 1];
    var unique = nonUniqueNumbers.Distinct();
    PrintItems(unique, "unique");
}

// 10. Приведение к типу
void Cast()
{
    var students = abstractStudents.Cast<Student>();
    PrintItems(students, "students");
}

// 11. Сортировка
void Sort()
{
    string[] words = ["this", "is", "the", "non", "sorted", "words"];
    
    var sortedByAsc = words.Order();
    PrintItems(sortedByAsc, "sortedByAsc");
    
    var sortedByDesc = words.OrderDescending();
    PrintItems(sortedByDesc, "sortedByDesc");

    var sortedByNameAsc = abstractStudents.OrderBy(item => item.Name);
    PrintItems(sortedByNameAsc, "sortedByNameAsc");
    
    var sortedByNameDesc = abstractStudents.OrderByDescending(item => item.Name);
    PrintItems(sortedByNameDesc, "sortedByNameAsc");
    
    // Также есть опция сортировки по нескольким полям - для этого используйте методы ThenBy, ThenByDescending
}

// 12. Соединение множеств
void Join()
{
    Grade[] grades =
    [
        new Grade(1, 5),
        new Grade(2, 4),
        new Grade(3, 3),
        new Grade(4, 4),
        new Grade(5, 5),
    ];

    var students = abstractStudents.Cast<Student>();
    var studentsWithGrades = students.Join(
        grades,
        st => st.Id,
        g => g.StudentId,
        (st, g) => new StudentWithGrade(st.Id, st.Name, g.Value));
    
    PrintItems(studentsWithGrades, "studentsWithGrades");
}

// 12. Комбинация методов LINQ
void UseSeveralMethods()
{
    var id = 0;
    var studentsWithNameFromADesc = names
        .Select(name => new Student(++id, name))
        .Where(st => st.Name.StartsWith("a", StringComparison.OrdinalIgnoreCase))
        .OrderByDescending(st => st.Name);
    PrintItems(studentsWithNameFromADesc, "studentsWithNameFromADesc");
}

void PrintItems<T>(IEnumerable<T> items, string comment)
{
    Console.WriteLine($"==={comment}:");
    
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
    
    Console.WriteLine();
    Console.ReadLine();
}