class BodyScanActivity : Activity
{
    private string[] BodyParts = {
        "feet", "calves", "thighs", "hips", "lower back", "upper back", "chest", "shoulders", "arms", "hands", "neck", "face", "head"
    };

    public BodyScanActivity() : base("Body Scan Meditation", "This activity will guide you through a body scan meditation to help you release tension and increase mindfulness by focusing on different parts of your body.")
    {
    }

    public void Run()
    {
        StartMessage();
        PrepareToBegin();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(Duration);

        int index = 0;
        while (DateTime.Now < futureTime && index < BodyParts.Length)
        {
            Console.WriteLine($"Focus on your {BodyParts[index]}. Notice any sensations, tension, or relaxation.");
            PauseWithAnimation(5); 
            index++;
        }

        EndMessage();
    }
}