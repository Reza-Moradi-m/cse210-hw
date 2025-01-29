using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> entriesList = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entriesList.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entriesList)
        {
            Console.WriteLine($"Date: {entry.entryDate}");
            Console.WriteLine($"Prompt: {entry.prompt}");
            Console.WriteLine($"Response: {entry.response}");
            Console.WriteLine("-------------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entriesList)
            {
                outputFile.WriteLine($"{entry.entryDate}|{entry.prompt}|{entry.response}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            entriesList.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    entriesList.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    // Exceeding Requirement: Search entries by date
    public void SearchByDate(string date)
    {
        bool found = false;
        foreach (Entry entry in entriesList)
        {
            if (entry.entryDate == date)
            {
                Console.WriteLine($"Date: {entry.entryDate}");
                Console.WriteLine($"Prompt: {entry.prompt}");
                Console.WriteLine($"Response: {entry.response}");
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