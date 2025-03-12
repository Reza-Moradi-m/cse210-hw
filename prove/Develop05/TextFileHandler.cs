using System;
using System.Collections.Generic;
using System.IO;

static class TextFileHandler
{
    public static void Save(string filename, List<Goal> goals, int totalPoints)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);  // Save total points first
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.ToString());
            }
        }
    }

    public static (List<Goal>, int) Load(string filename)
    {
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length > 0)
            {
                totalPoints = int.Parse(lines[0]);  // Read total points
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    if (type == "SimpleGoal")
                        goals.Add(new SimpleGoal(name, description, points));
                    else if (type == "EternalGoal")
                        goals.Add(new EternalGoal(name, description, points));
                    else if (type == "ChecklistGoal")
                    {
                        int required = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        goals.Add(new ChecklistGoal(name, description, points, required, bonus));
                    }
                }
            }
        }

        return (goals, totalPoints);
    }
}