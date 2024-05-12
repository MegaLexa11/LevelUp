using System;
using System.Drawing;
using System.Threading.Tasks;

Console.WriteLine("Welcome to the Game!");
bool isOneMoreTry = true;
var gameRandomizer = new Random();

while (isOneMoreTry)
{
    int playersNum = GetUserPosIntValue("Enter number of players: ");

    double trapsPart = 0.4;
    int fieldSize = GetUserPosIntValue("Enter field size: ");
    // Возможно, стоило тоже выделить в отдельный метод
    Console.WriteLine($"There should be less than {(int)(fieldSize * trapsPart)} traps in field");
    int trapsAmount = GetUserPosIntValue("Enter amount of traps (there also will be some boosts in the game): ");

    while (fieldSize * trapsPart < trapsAmount)
    {
        Console.WriteLine($"There should be less than {(int)(fieldSize * trapsPart)} traps in field");
        trapsAmount = GetUserPosIntValue("Enter amount of traps (there also will be some boosts in the game): ");
    }

    int[] playerPositions = new int[playersNum];
    ConsoleColor[] playerColors = GetPlayersColors(playersNum);
    int[] trapsPositions = GetTrapsPositions(trapsAmount, fieldSize);
    int[] boostsPositions = GetBoostsPositions(trapsPositions, fieldSize);

    int diceSize = 6;
    int boostMultiplier = 2;
    bool isGameContinues = true;

    while (isGameContinues)
    {
        for (int i = 0; i < playerPositions.Length; i++)
        {
            int playerPosition = playerPositions[i];
            ConsoleColor playerColor = playerColors[i];

            playerPositions[i] = GetPlayerPostion(i, playerPosition, playerColor);

            if (playerPositions[i] == fieldSize)
            {
                Console.WriteLine("He is winner!");
                isGameContinues = false;
                break;
            }
            Console.WriteLine();
        }
    }
    Console.ResetColor();
    Console.Write("Try again (y)?: ");
    string oneMoreTry = Console.ReadLine() ?? string.Empty;
    isOneMoreTry = String.Compare(oneMoreTry.ToLower(), "y") == 0;

    int GetPlayerPostion(int playerArrNumber, int playerPosition, ConsoleColor playerColor)
    {
        int playerNumber = playerArrNumber + 1;
        StartRound(playerNumber, playerColor);

        int diceResult = gameRandomizer.Next(1, diceSize);
        int currentPostion = playerPosition + diceResult;
        WriteMoveText(playerNumber, playerColor, diceResult);

        // По идее, пока игрок движется вперед и попадает на бусты, или ловушки, то движение продолжается
        while (trapsPositions.Contains(currentPostion) || boostsPositions.Contains(currentPostion))
        {
            if (trapsPositions.Contains(currentPostion))
            {
                diceResult = gameRandomizer.Next(1, diceSize);
                WriteTrapText(playerNumber, playerColor, diceResult, currentPostion);
                currentPostion = Math.Max(currentPostion - diceResult, 0);
                // Как только игрок попал на ловушку, то все, даже если вернулся на буст, то он не должен сработать (Обычно это так работает)
                break;
            }
            else if (boostsPositions.Contains(currentPostion))
            {
                WriteBoostText(playerNumber, playerColor, diceResult * boostMultiplier, currentPostion);
                currentPostion += diceResult * boostMultiplier;
            }
        }

        currentPostion = Math.Min(currentPostion, fieldSize);
        WritePositionText(currentPostion, playerColor);
        return currentPostion;
    }
}

ConsoleColor GetRandomConsoleColor()
{   
    var consoleColors = Enum.GetValues(typeof(ConsoleColor));
    return (ConsoleColor)consoleColors.GetValue(gameRandomizer.Next(1, consoleColors.Length - 2));
}

int GetUserPosIntValue(string valueToAsk)
{
    bool isValueCorrect = false;
    int valueNum = 0;
    while (!isValueCorrect || valueNum <= 0)
    {
        Console.Write(valueToAsk);
        isValueCorrect = int.TryParse(Console.ReadLine() ?? string.Empty, out valueNum);
        if (isValueCorrect && valueNum > 0)
        {
            return valueNum;
        }
        Console.WriteLine("Incorrect input! You should use only positive numbers!");
    }
    // По сути, это костыль, иначе возникала ошибка "Не все пути к методу возвращают значение"
    return 0;
}

ConsoleColor[] GetPlayersColors(int playersAmount)
{
    ConsoleColor[] playerColors = new ConsoleColor[playersAmount];
    for (int i = 0; i < playerColors.Length; i++)
    {
        playerColors[i] = GetRandomConsoleColor();
    }
    return playerColors;
}

// Тут метод не переделывал, раз, по сути, основная задача заключалась в некой декомпозиции кода
int[] GetTrapsPositions(int trapsAmount, int fieldSize)
{
    int[] trapsPositions = new int[trapsAmount];
    for (int i = 0; i < trapsPositions.Length; i++)
    {
        bool isCellBlocked = true;
        while (isCellBlocked)
        {
            int trapPosition = gameRandomizer.Next(1, fieldSize);
            // Часть условия, чтобы не было случая, когда более 6 ловушек идет подряд, и игра, по сути, становится непроходимой
            isCellBlocked = trapsPositions.Contains(trapPosition) || trapsPositions.Contains(trapPosition - 1) || trapsPositions.Contains(trapPosition + 1);
            if (!isCellBlocked)
            {
                trapsPositions[i] = trapPosition;
            }
        }
    }
    return trapsPositions;
}

int[] GetBoostsPositions(int[] trapsArray, int fieldSize) 
{
    double boostsDifference = 0.5;
    int boostsAmount = (int)(trapsArray.Length * boostsDifference);
    int[] boostsPositions = new int[boostsAmount];

    for (int i = 0; i < boostsPositions.Length; i++)
    {
        bool isCellBlocked = true;
        while (isCellBlocked)
        {
            int boostPosition = gameRandomizer.Next(1, fieldSize);
            isCellBlocked = trapsArray.Contains(boostPosition) || boostsPositions.Contains(boostPosition);
            if (!isCellBlocked)
            {
                boostsPositions[i] = boostPosition;
            }
        }

    }
    return boostsPositions;
}

void StartRound(int playerNumber, ConsoleColor playerColor)
{
    Console.ForegroundColor = playerColor;
    Console.WriteLine($"Player's {playerNumber} turn!");
    Console.ResetColor();
    Console.Write("Press Enter to throw a dice: ");
    Console.ReadLine();
}

void WriteMoveText(int playerNumber, ConsoleColor playerColor, int diceResult)
{
    Console.ForegroundColor = playerColor;
    Console.Write($"Player {playerNumber} ");
    Console.ResetColor();
    Console.Write("moved on ");
    Console.ForegroundColor = playerColor;
    Console.Write($"{diceResult} ");
    Console.ResetColor();
    Console.WriteLine("squares");
}

void WritePositionText(int playerPostion, ConsoleColor playerColor)
{
    Console.ResetColor();
    Console.Write("His position is ");
    Console.ForegroundColor = playerColor;
    Console.Write($"{playerPostion} ");
    Console.ResetColor();
    Console.WriteLine("now.");
}

void WriteBoostText(int playerNumber, ConsoleColor playerColor, int diceResult, int boostPosition)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write($"Wow, It's a boost on {boostPosition}! ");
    Console.ResetColor();
    Console.ForegroundColor = playerColor;
    Console.Write($"Player {playerNumber} ");
    Console.ResetColor();
    Console.Write("moved forward on ");
    Console.ForegroundColor = playerColor;
    Console.WriteLine($"{diceResult}.");
}

void WriteTrapText(int playerNumber, ConsoleColor playerColor, int diceResult, int trapPosition)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write($"Oh, It's a trap on {trapPosition}! ");
    Console.ResetColor();
    Console.ForegroundColor = playerColor;
    Console.Write($"Player {playerNumber} ");
    Console.ResetColor();
    Console.Write("moved backwards on ");
    Console.ForegroundColor = playerColor;
    Console.WriteLine($"{diceResult}.");
}