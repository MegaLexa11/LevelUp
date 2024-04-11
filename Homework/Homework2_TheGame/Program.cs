using System;
using System.Drawing;

Console.WriteLine("Welcome to the Game!");
bool isOneMoreTry = true;
var gameRandomizer = new Random();

while (isOneMoreTry)
{
    Console.Write("Enter number of players: ");
    bool isPlayersCorrect = int.TryParse(Console.ReadLine() ?? string.Empty, out int playersNum);

    Console.Write("Enter field size: ");
    bool isSizeCorrect = int.TryParse(Console.ReadLine() ?? string.Empty, out int fieldSize);

    Console.Write("Enter amount of traps (there also will be some boosts in the game): ");
    bool isTrapsCorrect = int.TryParse(Console.ReadLine() ?? string.Empty, out int trapsAmount);

    double trapsPart = 0.4;

    if (!(isPlayersCorrect && isSizeCorrect && isTrapsCorrect) || playersNum <= 0 || fieldSize <= 0 || trapsAmount <= 0)
    {
        Console.WriteLine("Incorrect Input! You should use only positive numbers");
        Console.WriteLine();
        continue;
    }

    if (fieldSize * trapsPart < trapsAmount)
    {
        Console.WriteLine("Amount of traps should be less than a 40% of the field size!");
        Console.WriteLine();
        continue;
    }

    int diceSize = 6;
    int boostMultiplier = 2;
    int boostsDifference = 2;
    bool isGameContinues = true;
    bool isCellBlocked;
    int diceResult, trapPosition, boostPosition;

    int[] playerPositions = new int[playersNum];
    ConsoleColor[] playerColors = new ConsoleColor[playersNum];
    for (int i = 0; i < playerPositions.Length; i++)
    {
        playerColors[i] = GetRandomConsoleColor();
    }

    int[] trapsPositions = new int[trapsAmount];
    for (int i = 0; i < trapsPositions.Length; i++)
    {
        isCellBlocked = true;
        while (isCellBlocked)
        {
            trapPosition = gameRandomizer.Next(1, fieldSize);
            // Часть условия, чтобы не было случая, когда более 6 ловушек идет подряд, и игра, по сути, становится непроходимой
            isCellBlocked = trapsPositions.Contains(trapPosition) || trapsPositions.Contains(trapPosition - 1) || trapsPositions.Contains(trapPosition + 1);
            if (!isCellBlocked)
            {
                trapsPositions[i] = trapPosition;
            }
        }
    }

    int boostsAmount = trapsAmount - boostsDifference;
    int boostPlacesLeft = fieldSize - trapsAmount;
    if (boostsAmount > boostPlacesLeft)
    {
        boostsAmount = boostPlacesLeft;
    }
    else if (boostsAmount < 0)
    {
        boostsAmount = 0;
    }
    int[] boostsPositions;

    boostsPositions = new int[boostsAmount];
    for (int i = 0; i < boostsPositions.Length; i++)
    {
        isCellBlocked = true;
        while (isCellBlocked)
        {
            boostPosition = gameRandomizer.Next(1, fieldSize);
            isCellBlocked = trapsPositions.Contains(boostPosition) || boostsPositions.Contains(boostPosition);
            if (!isCellBlocked)
            {
                boostsPositions[i] = boostPosition;
            }
        }

    }

    foreach (int pos in trapsPositions) 
    {
        Console.Write($"{pos} ");
    }
    Console.WriteLine();
    foreach (int pos in boostsPositions)
    {
        Console.Write($"{pos} ");
    }
    Console.WriteLine();

    while (isGameContinues)
    {
        for (int i = 0; i < playerPositions.Length; i++)
        {
            Console.ForegroundColor = playerColors[i];
            Console.WriteLine($"Player's {i + 1} turn!");
            Console.ResetColor();
            Console.Write("Press Enter to throw a dice: ");
            Console.ReadLine();

            diceResult = gameRandomizer.Next(1, diceSize);
            playerPositions[i] += diceResult;
            Console.ForegroundColor = playerColors[i];
            Console.Write($"Player {i + 1} ");
            Console.ResetColor();
            Console.Write("moved on ");
            Console.ForegroundColor = playerColors[i];
            Console.Write($"{diceResult} ");
            Console.ResetColor();
            Console.WriteLine("squares");

            // По идее, пока игрок движется вперед и попадает на бусты, или ловушки, то движение продолжается
            while (trapsPositions.Contains(playerPositions[i]) || boostsPositions.Contains(playerPositions[i]))
            {
                if (trapsPositions.Contains(playerPositions[i]))
                {
                    diceResult = gameRandomizer.Next(1, diceSize);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"Oh, It's a trap on {playerPositions[i]}! ");
                    Console.ResetColor();
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"Player {i + 1} ");
                    Console.ResetColor();
                    Console.Write("moved backwards on ");
                    Console.ForegroundColor = playerColors[i];
                    Console.WriteLine($"{diceResult}.");
                    playerPositions[i] -= diceResult;
                    if (playerPositions[i] < 0)
                    {
                        playerPositions[i] = 0;
                    }
                    // Как только игрок попал на ловушку, то все, даже если вернулся на буст, то он не должен сработать (Обычно это так работает)
                    break;
                }
                else if (boostsPositions.Contains(playerPositions[i]))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"Wow, It's a boost on {playerPositions[i]}! ");
                    Console.ResetColor();
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"Player {i + 1} ");
                    Console.ResetColor();
                    Console.Write("moved forward on ");
                    Console.ForegroundColor = playerColors[i];
                    Console.WriteLine($"{diceResult * boostMultiplier}.");
                    playerPositions[i] += diceResult * boostMultiplier;

                }
            }

            if (playerPositions[i] >= fieldSize)
            {
                Console.WriteLine("He is winner!");
                isGameContinues = false;
                break;
            }
            Console.ResetColor();
            Console.Write("His position is ");
            Console.ForegroundColor = playerColors[i];
            Console.Write($"{playerPositions[i]} ");
            Console.ResetColor();
            Console.WriteLine("now");
            Console.WriteLine();

        }
    }
    Console.ResetColor();
    Console.Write("Try again (Y)?: ");
    string oneMoreTry = Console.ReadLine() ?? string.Empty;
    isOneMoreTry = String.Compare(oneMoreTry, "Y") == 0;
}

ConsoleColor GetRandomConsoleColor()
{   
    var consoleColors = Enum.GetValues(typeof(ConsoleColor));
    return (ConsoleColor)consoleColors.GetValue(gameRandomizer.Next(1, consoleColors.Length - 2));
}