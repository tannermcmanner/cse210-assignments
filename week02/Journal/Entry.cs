using System;

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string Date
    {
        get { return _date; }
    }

    public string PromptText
    {
        get { return _promptText; }
    }

    public string EntryText
    {
        get { return _entryText; }
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    // Converts this entry into a single line that can be written to a file.
    // Uses "~|~" as a separator since it is unlikely to appear in a journal entry.
    public string ToFileString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    // Rebuilds an Entry from a single line that was previously saved with ToFileString().
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("~|~");
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
