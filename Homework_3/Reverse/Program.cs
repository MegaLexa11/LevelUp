Console.Write("Enter some text to get it reversed: ");
string userText = Console.ReadLine() ?? string.Empty;
char[] reversed = new char [userText.Length];

for (int i = 0; i <= userText.Length / 2; i++)
{
    reversed[i] = userText[userText.Length - i - 1];
    if (i != userText.Length / 2) reversed[userText.Length - i - 1] = userText[i];
}

string reversedStr = new string(reversed);
Console.WriteLine(reversedStr);