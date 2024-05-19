using LinqViaQuerySyntax;

int[] numbers = [12, -45, 78, -1, 83];

string[] names = ["Aleksandr", "Aleksey", "Vasiliy"];

Student[] abstractStudents = [
    new Student(1, "Vladimir"),
    new Student(2, "Petr"),
    new Student(3, "Stepan"),
];

Where();
// Select();
// Group();
// Join();
// UseSeveralMethods();

// 1. Фильтрация
void Where()
{
    var studentsWithNameFromA =
        from item in names
        where item.StartsWith("a", StringComparison.OrdinalIgnoreCase)
        select item;
    
    PrintItems(studentsWithNameFromA, "studentsWithNameFromA");
}

// 2. Маппинг - создание новых объектов на основании существующих
void Select()
{
    var incremented =
        from number in numbers
        select number + 1;
    PrintItems(incremented, "incremented");
        
    
    var id = 0;
    // Переменная id "захватывается" скоупом лямбда-выражения - такой приём называется "замыкание".
    var students =
        from name in names
        select new Student(++id, name);
    PrintItems(students, "students");
}

// 3. Сгруппировать коллекцию
void Group()
{
    var groups =
        from name in names
        group name by name.First();
    
    foreach (var group in groups)
    {
        PrintItems(group.AsEnumerable(), group.Key.ToString());
    }
}

// 4. Соединение множеств
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

    var studentsWithGrades =
        from student in abstractStudents
        join grade in grades on student.Id equals grade.StudentId
        select new StudentWithGrade(student.Id, student.Name, grade.Value);
    
    PrintItems(studentsWithGrades, "studentsWithGrades");
}

// 5. Комбинация методов LINQ
void UseSeveralMethods()
{
    var id = 0;
    var studentsWithNameFromADesc =
        from name in names
        where name.StartsWith("a", StringComparison.OrdinalIgnoreCase)
        orderby name descending
        select new Student(++id, name);
        
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