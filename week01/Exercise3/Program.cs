using System;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int magicNumber = rnd.Next(1, 100);

        int guess = -1;
        while (magicNumber != guess)
        {
            Console.Write("What is your guess?");
            guess = Convert.ToInt32(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}

// Random rnd = new Random();
// int month  = rnd.Next(1, 13);  // creates a number between 1 and 12
// int dice   = rnd.Next(1, 7);   // creates a number between 1 and 6
// int card   = rnd.Next(52);     // creates a number between 0 and 51