using System;

class Entry
{
    public string EntryDate { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    // Constructor for creating an entry from user input
    public Entry(string prompt)
    {
        EntryDate = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Console.WriteLine($"Prompt: {Prompt}");
        Console.Write("Your response: ");
        Response = Console.ReadLine();
    }

    // Constructor for creating an entry from loaded data
    public Entry(string date, string prompt, string response)
    {
        EntryDate = date;
        Prompt = prompt;
        Response = response;
    }
}