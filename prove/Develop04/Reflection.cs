using System;
using System.Collections.Generic;
using System.Threading;

class Reflection : Activity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn from this?",
        "How can you apply this in other situations?",
        "How can you keep this in mind for the future?"
    };

    public Reflection() : base("Reflection", "This activity helps you reflect on moments of strength and resilience.") { }

    protected override void Execute()
    {
        Random random = new Random();
        Console.WriteLine("\n" + _prompts[random.Next(_prompts.Count)]);
        DisplaySpinner(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_questions[random.Next(_questions.Count)]);
            DisplaySpinner(5);
        }
    }
}