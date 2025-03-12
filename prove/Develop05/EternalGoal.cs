class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) {}

    // Override base method
    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals never complete
    }

    public override void Display()
    {
        Console.WriteLine($"[∞] {_goalName} - {_description} ({_points} points per completion)");
    }
}