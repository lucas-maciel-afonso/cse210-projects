class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Author}: {Text}";
    }
}

// Explaining Override ToString()

// Comment comment = new Comment("Alice", "Great explanation!");
// Console.WriteLine(comment);

// Standard output would be: 
// CommentNamespace.Comment

// If I use Override ToString() the Output will be:
// Alice: Great explanation!