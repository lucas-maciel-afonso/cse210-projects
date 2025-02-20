using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Maria Andrade", "Algebra");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Jonas Winter", "Exponents", "1.5", "10-20");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Peter Walls", "Economy of Brazil", "The Period of Colonization");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}