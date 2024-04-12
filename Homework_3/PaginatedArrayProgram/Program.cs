using PaginatedArrayProgram;

PaginatedArray<int> intArr = new PaginatedArray<int>(11, 2);
for (int i = 0; i < intArr.Size(); i++) 
{
    intArr[i] = i + 1;
}

int[] page = intArr.getPageData(6);

foreach (int i in page)
{
    Console.Write($"{i} ");
}