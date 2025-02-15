using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Understanding C#", "Code Academy", 600);
        Video video2 = new Video("AI Trends in 2025", "Tech World", 720);
        Video video3 = new Video("Best Travel Destinations", "ExplorerX", 480);

        // Add comments to videos
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "I finally understand C# basics!"));

        video2.AddComment(new Comment("David", "AI is evolving so fast!"));
        video2.AddComment(new Comment("Eve", "I wonder what the next big breakthrough will be."));
        video2.AddComment(new Comment("Frank", "Very insightful talk!"));

        video3.AddComment(new Comment("Grace", "I want to visit all these places!"));
        video3.AddComment(new Comment("Hannah", "This video gave me wanderlust."));
        video3.AddComment(new Comment("Isaac", "Nice recommendations!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}