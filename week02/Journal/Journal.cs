using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Write an entry first!");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new List<Entry>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                loadedEntries.Add(Entry.FromFileString(line));
            }
        }

        // Replace the current entries only after the file has loaded successfully.
        _entries = loadedEntries;
    }
}
