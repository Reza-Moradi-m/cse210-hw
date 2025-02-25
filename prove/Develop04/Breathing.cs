using System;
using System.Threading;

class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity helps you relax by guiding your breathing. Clear your mind and focus on each breath.") { }

    protected override void Execute()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            DisplayCountdown(4);
            Console.WriteLine("Breathe out...");
            DisplayCountdown(4);
        }
    }
}