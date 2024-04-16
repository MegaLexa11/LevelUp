using PaginatedArrayProgram;

PaginatedArray<int> intArr = new PaginatedArray<int>(13, 3);
for (int i = 0; i < intArr.Length; i++) 
{
    intArr.AddVal(i + 1, i);
}

int[] page = intArr[3];

foreach (int i in page)
{
    Console.Write($"{i} ");
}