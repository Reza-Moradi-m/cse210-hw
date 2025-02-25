using System;
using System.Diagnostics;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private Process _mp3Player;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _mp3Player = new Process();
        _mp3Player.StartInfo.FileName = "mpg123";  // Use mpg123 instead of wmplayer
        _mp3Player.StartInfo.Arguments = "\"music.mp3\"";  // Path to MP3 file
        _mp3Player.StartInfo.CreateNoWindow = true;
        _mp3Player.StartInfo.UseShellExecute = false;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        _mp3Player.Start();  // 🔊 Start playing MP3 file in the background
        DisplaySpinner(3);

        Execute();

        Console.WriteLine($"\nGreat job! You have completed the {_name} activity.");
        Console.WriteLine($"Duration: {_duration} seconds");
        DisplaySpinner(3);

        StopMusic();  // 🛑 Stop the music when the activity ends
    }

    protected abstract void Execute();

    protected void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(300);
            Console.Write("\b \b/");
            Thread.Sleep(300);
            Console.Write("\b \b-");
            Thread.Sleep(300);
            Console.Write("\b \b\\");
            Thread.Sleep(300);
            Console.Write("\b \b");
        }
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void StopMusic()
    {
        try
        {
            _mp3Player.Kill();  // 🛑 Stop the MP3 file when the activity ends
        }
        catch (Exception)
        {
            Console.WriteLine("Music process already stopped.");
        }
    }
}