using System;

class Entry
{
    public string entryDate;
    public string prompt;
    public string response;

    public Entry(string date, string prompt, string response)
    {
        this.entryDate = date;
        this.prompt = prompt;
        this.response = response;
    }

    public Entry(string prompt)
    {
        this.entryDate = DateTime.Now.ToShortDateString();
        this.prompt = prompt;
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        this.response = Console.ReadLine();
    }
}