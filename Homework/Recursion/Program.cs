Console.Write("Please, enter some numbers divided by space: ");
string numsStr = Console.ReadLine() ?? string.Empty;
string[] numsMassive = numsStr.Split();


int[] intNums = new int[numsMassive.Length];
for (int i = 0; i < numsMassive.Length; i++)
{
    bool isParsed = int.TryParse(numsMassive[i], out int num);
    if (isParsed)
    {
        intNums[i] = num;
    }
};

Console.WriteLine($"Result: {Sum(intNums.Length - 1)}");

int Sum(int currentInd)
{
    if (currentInd == 0)
    {
        return intNums[currentInd];
    }

    return intNums[currentInd] + Sum(currentInd - 1);
}