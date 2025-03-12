using System;

abstract class Goal
{
    protected string _goalName;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _goalName = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    // Using virtual to allow overriding
    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual bool IsComplete()
    {
        return _isComplete;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{_goalName} - {_description} ({_points} points)");
    }

    public override string ToString()
    {
        return $"{GetType().Name}|{_goalName}|{_description}|{_points}|{_isComplete}";
    }
}