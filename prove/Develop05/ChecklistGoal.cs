class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _requiredCount = requiredCount;
        _bonusPoints = bonusPoints;
    }

    // Override base method
    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted >= _requiredCount)
        {
            _isComplete = true;
            return _points + _bonusPoints;  // Award bonus on final completion
        }
        return _points;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _requiredCount;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(_isComplete ? "X" : " ")}] {_goalName} - {_description} ({_points} points each, {_bonusPoints} bonus at {_requiredCount} completions) - Completed {_timesCompleted}/{_requiredCount}");
    }
}