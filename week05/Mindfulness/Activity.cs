class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name} Activity!");
        Console.WriteLine(Description);
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("Good job!");
        PauseWithAnimation(2);
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        PauseWithAnimation(3);
    }

    public void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        PauseWithAnimation(3);
    }
}