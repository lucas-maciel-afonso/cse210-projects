using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int userInput = Convert.ToInt32(Console.ReadLine());

        // A >= 90
        // B >= 80
        // C >= 70
        // D >= 60
        // F < 60

        if (userInput >= 90)
        {
            Console.WriteLine($"Congratulations on your A grade, you passed the class");
        }
        else if (userInput >= 80)
        {
            Console.WriteLine($"Congratulations on your B grade, you passed the class");
        }
        else if (userInput >= 70)
        {
            Console.WriteLine($"Congratulations on your C grade, you passed the class");
        }
        else if (userInput >= 60)
        {
            Console.WriteLine($"You got a F grade, you failed the class");
        }
        else if (userInput < 60)
        {
            Console.WriteLine($"You got a F grade, you failed the class");
        }
    }
}