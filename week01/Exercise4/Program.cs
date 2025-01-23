using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int number = -1;
        while (number != 0)
        {
            Console.Write("Enter a list of numbers, type 0 when finished: ");
            number = Convert.ToInt32(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = 0;
        float average = 0;
        int largestNumber = 0;

        foreach (int n in numbers)
        {
            sum += n;
            average += n;
            if (n > largestNumber) { largestNumber = n; }
            Console.WriteLine(n);
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average / numbers.Count}");
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}