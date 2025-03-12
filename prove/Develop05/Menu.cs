using System;
using System.Collections.Generic;

class Menu
{
    private List<Goal> _goalList = new List<Goal>();
    private int _totalPoints = 0;  // Track total points

    public void DisplayMenu()
    {
        Console.WriteLine($"\n===== Eternal Quest Menu =====");
        Console.WriteLine($"Total Points: {_totalPoints}");  // Display points at every menu prompt
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. Record Event");
        Console.WriteLine("3. Display Goals");
        Console.WriteLine("4. Save Goals");
        Console.WriteLine("5. Load Goals");
        Console.WriteLine("6. Exit");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type: 1. Simple 2. Eternal 3. Checklist");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Description: ");
        string description = Console.ReadLine();
        Console.Write("Enter Points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
            _goalList.Add(new SimpleGoal(name, description, points));
        else if (choice == 2)
            _goalList.Add(new EternalGoal(name, description, points));
        else if (choice == 3)
        {
            Console.Write("Enter Completion Requirement: ");
            int required = int.Parse(Console.ReadLine());
            Console.Write("Enter Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goalList.Add(new ChecklistGoal(name, description, points, required, bonus));
        }
    }

    public void RecordGoalEvent()
    {
        DisplayGoals();
        Console.Write("Select goal number to mark complete: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        int earnedPoints = _goalList[index].RecordEvent();
        _totalPoints += earnedPoints;  // Update total points
        Console.WriteLine($"You earned {earnedPoints} points!");
        Console.WriteLine($"Total Points: {_totalPoints}");  // Show updated points
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\n===== Goals =====");
        Console.WriteLine($"Total Points: {_totalPoints}");  // Show points before listing goals
        for (int i = 0; i < _goalList.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goalList[i].Display();
        }
    }

    public void Save()
    {
        TextFileHandler.Save("goals.txt", _goalList, _totalPoints);
    }

    public void Load()
    {
        (_goalList, _totalPoints) = TextFileHandler.Load("goals.txt");
    }
}