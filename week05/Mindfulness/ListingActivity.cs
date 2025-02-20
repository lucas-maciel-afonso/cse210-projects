class ListingActivity : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        StartMessage();
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Length)]);
        PrepareToBegin();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(Duration);

        int itemCount = 0;
        while (DateTime.Now < futureTime)
        {
            Console.Write("List an item: ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items!");
        EndMessage();
    }
}