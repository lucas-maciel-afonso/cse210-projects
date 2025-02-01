class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response));
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        entries.Clear();
        foreach (var line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    public void ExportToCSV(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response");
            foreach (var entry in entries)
            {
                writer.WriteLine($"\"{entry.Date}\",\"{entry.Prompt.Replace("\"", "\"\"")}\",\"{entry.Response.Replace("\"", "\"\"")}\"");
            }
        }
        Console.WriteLine("Journal exported to CSV successfully.");
    }
}
