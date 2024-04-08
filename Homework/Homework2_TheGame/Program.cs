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

    if (isPlayersCorrect && isSizeCorrect && isTrapsCorrect)
    {
        int diceSize = 6;
        int boostSize = 2;
        bool ifgameContinues = true;
        bool isCellBlocked = true;
        int diceResult, trapPosition, boostPosition;

        int[] playerPositions = new int[playersNum];
        ConsoleColor[] playerColors = new ConsoleColor[playersNum];
        for (int i = 0; i < playerPositions.Length; i++)
        {
            playerPositions[i] = 0;
            playerColors[i] = GetRandomConsoleColor();
        }

        int[] trapsPositions = new int[trapsAmount];
        for (int i = 0; i < trapsPositions.Length; i++)
        {
            while (isCellBlocked)
            {
                trapPosition = gameRandomizer.Next(1, fieldSize);
                isCellBlocked = trapsPositions.Contains(trapPosition);
                if (!isCellBlocked)
                {
                    trapsPositions[i] = trapPosition;
                }
            }
            
        }

        isCellBlocked = true;
        int[] boostsPositions = new int[trapsAmount - 2];
        for (int i = 0; i < boostsPositions.Length; i++)
        {
            while (isCellBlocked) 
            {
                boostPosition = gameRandomizer.Next(1, fieldSize);
                isCellBlocked = trapsPositions.Contains(boostPosition) && boostsPositions.Contains(boostPosition);
                if (!isCellBlocked)
                {
                    boostsPositions[i] = boostPosition;
                }
            }
             
        }

        Console.WriteLine("The game starts!");
        while (ifgameContinues)
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
                if (playerPositions[i] >= fieldSize)
                {
                    Console.WriteLine("He is winner!");
                    ifgameContinues = false;
                    break;
                }
                else if (trapsPositions.Contains(playerPositions[i]))
                {
                    diceResult = gameRandomizer.Next(1, diceSize);
                    playerPositions[i] -= diceResult;
                    if (playerPositions[i] < 0) 
                    {
                        playerPositions[i] = 0;
                    }
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Oh, It's a trap! ");
                    Console.ResetColor();
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"Player {i + 1} ");
                    Console.ResetColor();
                    Console.Write("moved backwards on ");
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"{diceResult}. ");
                    Console.ResetColor();
                    Console.Write("His position is ");
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"{playerPositions[i]} ");
                    Console.ResetColor();
                    Console.WriteLine("now");
                }
                else if (boostsPositions.Contains(playerPositions[i]))
                {
                    playerPositions[i] += diceResult * boostSize;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Wow, It's a boost! ");
                    Console.ResetColor();
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"Player {i + 1} ");
                    Console.ResetColor();
                    Console.Write("moved forward on ");
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"{diceResult * boostSize}. ");
                    Console.ResetColor();
                    Console.Write("His position is ");
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"{playerPositions[i]} ");
                    Console.ResetColor();
                    Console.WriteLine("now");
                }
                else
                {
                    Console.Write("His position is ");
                    Console.ForegroundColor = playerColors[i];
                    Console.Write($"{playerPositions[i]} ");
                    Console.ResetColor();
                    Console.WriteLine("now");
                }
                Console.WriteLine();
            }
        }
    }
    else 
    {
        Console.WriteLine("Incorrect Input!");
        Console.WriteLine();
        continue;
    }
    Console.ResetColor();
    Console.Write("Try again? Y/anything: ");
    string oneMoreTry = Console.ReadLine() ?? string.Empty;
    isOneMoreTry = String.Compare(oneMoreTry, "Y") == 0;
}

ConsoleColor GetRandomConsoleColor()
{   
    var consoleColors = Enum.GetValues(typeof(ConsoleColor));
    return (ConsoleColor)consoleColors.GetValue(gameRandomizer.Next(1, consoleColors.Length - 2));
}