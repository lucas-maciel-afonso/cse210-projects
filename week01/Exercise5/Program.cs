using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = GetUserName();
        int favoriteNumber = GetFavoriteNumber();

        int squaredValue = CalculateSquare(favoriteNumber);

        DisplayResult(userName, squaredValue);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int GetFavoriteNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        return favoriteNumber;
    }

    static int CalculateSquare(int number)
    {
        int squaredValue = number * number;
        return squaredValue;
    }

    static void DisplayResult(string userName, int squaredValue)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredValue}");
    }
}