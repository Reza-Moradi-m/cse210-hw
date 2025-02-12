using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("Error: No scriptures found in the file.");
            return;
        }

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        bool allHidden = false;

        while (true)
        {
            Console.Clear();

            if (allHidden)
            {
                Console.WriteLine("\nAll words are hidden. Memorization complete!");
                Console.WriteLine("\nPress Enter one more time to reveal the full scripture...");
                Console.ReadLine();
                
                Console.Clear();
                Console.WriteLine("\nFinal Scripture:\n");
                scripture.RevealAll();  
                Console.WriteLine("\nPress Enter to exit...");
                Console.ReadLine();
                return; 
            }

            scripture.DisplayScripture();

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                return; 

            scripture.HideWords();

            if (scripture.IsAllHidden())
                allHidden = true;
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Error: Scriptures file not found.");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length < 4) continue;  // Skip invalid lines

            string book = parts[0];
            string chapter = parts[1];
            string verse = parts[2];
            string text = parts[3];

            Reference reference;
            if (string.IsNullOrWhiteSpace(verse))
                reference = new Reference(book, chapter);
            else if (verse.Contains("-"))
            {
                string[] verseRange = verse.Split('-');
                reference = new Reference(book, chapter, verseRange[0], verseRange[1]);
            }
            else
                reference = new Reference(book, chapter, verse);

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}