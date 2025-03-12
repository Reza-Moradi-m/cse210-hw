class SimpleGoal : Goal
{
    private bool _status;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _status = false;
    }

    public override int RecordEvent()
    {
        if (!_status)
        {
            _status = true;
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _status;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(_status ? "X" : " ")}] {_goalName} - {_description} ({_points} points)");
    }
}