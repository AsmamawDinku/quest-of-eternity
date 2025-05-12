using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore() => _score;

    public void CreateGoal()
{
    Console.WriteLine("Select goal type:\n1. Simple\n2. Eternal\n3. Checklist");

    int type;
    while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 3)
    {
        Console.Write("Invalid input. Enter 1 (Simple), 2 (Eternal), or 3 (Checklist): ");
    }

    Console.Write("Name: ");
    string name = Console.ReadLine() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
        return;
    }

    Console.Write("Description: ");
    string desc = Console.ReadLine() ?? string.Empty;

    Console.Write("Points: ");
    int points;
    while (!int.TryParse(Console.ReadLine(), out points))
    {
        Console.Write("Invalid input. Please enter a valid number for points: ");
    }

    switch (type)
    {
        case 1:
            _goals.Add(new SimpleGoal(name, desc, points));
            break;

        case 2:
            _goals.Add(new EternalGoal(name, desc, points));
            break;

        case 3:
            Console.Write("Target count: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target))
            {
                Console.Write("Invalid input. Enter a number for target count: ");
            }

            Console.Write("Bonus points: ");
            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus))
            {
                Console.Write("Invalid input. Enter a number for bonus points: ");
            }

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            break;
    }
}


    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Filename to save: ");
        string file = Console.ReadLine() ?? string.Empty;

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals)
                sw.WriteLine(g.GetStringRepresentation());
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Filename to load: ");
        string file = Console.ReadLine() ?? string.Empty;

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]))
                    {
                        // setting private field manually
                    });
                    if (bool.Parse(parts[4]))
                        ((SimpleGoal)_goals[^1]).RecordEvent();
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    ChecklistGoal cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[5]), int.Parse(parts[4]));

                    int completed = int.Parse(parts[6]);
                    for (int c = 0; c < completed; c++) cg.RecordEvent();
                    _goals.Add(cg);
                    break;
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal number to record: ");
        string input = Console.ReadLine() ?? string.Empty;
        if (!int.TryParse(input, out int index))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }
        index -= 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int points = _goals[index].RecordEvent();
        _score += points;

        Console.WriteLine($"Event recorded! You earned {points} points.");
    }
}
