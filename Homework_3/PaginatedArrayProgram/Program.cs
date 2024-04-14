using PaginatedArrayProgram;

PaginatedArray<int> intArr = new PaginatedArray<int>(13, 3);
for (int i = 0; i < intArr.Length; i++) 
{
    intArr.addVal(i + 1, i);
}

int[] page = intArr[5];

foreach (int i in page)
{
    Console.Write($"{i} ");
}