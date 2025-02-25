using System;
using System.Collections.Generic;
using System.Threading;

class Listing : Activity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing() : base("Listing", "This activity helps you reflect on the good things in your life by listing as many as you can.") { }

    protected override void Execute()
    {
        Random random = new Random();
        Console.WriteLine("\n" + _prompts[random.Next(_prompts.Count)]);
        Console.WriteLine("Start listing items:");
        DisplaySpinner(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        List<string> responses = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                responses.Add(response);
            }
        }

        Console.WriteLine($"You listed {responses.Count} items!");
    }
}