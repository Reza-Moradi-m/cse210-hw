using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entriesList = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        _entriesList.Add(entry);
    }

    // Display all entries in the journal
    public void DisplayEntries()
    {
        foreach (Entry entry in _entriesList)
        {
            Console.WriteLine($"Date: {entry.EntryDate}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine("-------------------------------");
        }
    }

    // Save all journal entries to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entriesList)
            {
                outputFile.WriteLine($"{entry.EntryDate}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    // Load journal entries from a file
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _entriesList.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entriesList.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    // Search for entries by date
    public void SearchByDate(string date)
    {
        bool found = false;
        foreach (Entry entry in _entriesList)
        {
            if (entry.EntryDate == date)
            {
                Console.WriteLine($"Date: {entry.EntryDate}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine("-------------------------------");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No entries found for the given date.");
        }
    }
}