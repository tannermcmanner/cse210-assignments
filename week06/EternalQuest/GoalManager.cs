using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class GoalManager
{
    private const int PointsPerLevel = 500;
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            string choice = ReadLine("Select a choice from the menu: ");
            if (choice == null)
            {
                return;
            }

            switch (choice.Trim())
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        int level = _score / PointsPerLevel + 1;
        Console.WriteLine($"You have {_score} points and are level {level}.");
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("Your goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        string type = ReadLine("Which type of goal would you like to create? ");
        if (type == null)
        {
            return;
        }

        if (type.Trim() != "1" && type.Trim() != "2" && type.Trim() != "3")
        {
            Console.WriteLine("Please choose a goal type from 1 to 3.");
            return;
        }

        string shortName = ReadRequiredText("What is the name of your goal? ");
        if (shortName == null)
        {
            return;
        }

        string description = ReadRequiredText("What is a short description of it? ");
        if (description == null)
        {
            return;
        }

        int? points = ReadInt("What is the amount of points associated with this goal? ", 1);
        if (!points.HasValue)
        {
            return;
        }

        Goal goal;
        switch (type.Trim())
        {
            case "1":
                goal = new SimpleGoal(shortName, description, points.Value);
                break;
            case "2":
                goal = new EternalGoal(shortName, description, points.Value);
                break;
            default:
                int? target = ReadInt("How many times should this goal be accomplished for a bonus? ", 1);
                if (!target.HasValue)
                {
                    return;
                }

                int? bonus = ReadInt("What is the bonus for accomplishing it that many times? ", 0);
                if (!bonus.HasValue)
                {
                    return;
                }

                goal = new ChecklistGoal(shortName, description, points.Value, target.Value, bonus.Value);
                break;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        ListGoalNames();
        int? selection = ReadInt("Which goal did you accomplish? ", 1, _goals.Count);
        if (!selection.HasValue)
        {
            return;
        }

        Goal goal = _goals[selection.Value - 1];
        if (goal.IsComplete())
        {
            Console.WriteLine("That goal is already complete and cannot be recorded again.");
            return;
        }

        int previousLevel = _score / PointsPerLevel + 1;
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");

        int newLevel = _score / PointsPerLevel + 1;
        for (int level = previousLevel + 1; level <= newLevel; level++)
        {
            Console.WriteLine($"Level up! You reached level {level}!");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    private void SaveGoals()
    {
        string filename = ReadRequiredText("What is the filename for the goal file? ");
        if (filename == null)
        {
            return;
        }

        List<string> lines = new List<string>
        {
            $"Score|{_score.ToString(CultureInfo.InvariantCulture)}"
        };

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        try
        {
            File.WriteAllLines(filename, lines);
            Console.WriteLine("Goals saved successfully.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Unable to save goals: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Unable to save goals: {exception.Message}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Unable to save goals: {exception.Message}");
        }
        catch (NotSupportedException exception)
        {
            Console.WriteLine($"Unable to save goals: {exception.Message}");
        }
    }

    private void LoadGoals()
    {
        string filename = ReadRequiredText("What is the filename for the goal file? ");
        if (filename == null)
        {
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                throw new FormatException("The file is empty.");
            }

            string[] scoreParts = lines[0].Split('|');
            if (scoreParts.Length != 2 ||
                scoreParts[0] != "Score" ||
                !int.TryParse(scoreParts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int loadedScore) ||
                loadedScore < 0)
            {
                throw new FormatException("The score entry is invalid.");
            }

            List<Goal> loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                try
                {
                    loadedGoals.Add(Goal.FromStringRepresentation(lines[i]));
                }
                catch (FormatException exception)
                {
                    throw new FormatException($"Invalid goal on line {i + 1}: {exception.Message}", exception);
                }
                catch (ArgumentException exception)
                {
                    throw new FormatException($"Invalid goal on line {i + 1}: {exception.Message}", exception);
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Unable to load goals: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Unable to load goals: {exception.Message}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Unable to load goals: {exception.Message}");
        }
        catch (NotSupportedException exception)
        {
            Console.WriteLine($"Unable to load goals: {exception.Message}");
        }
        catch (FormatException exception)
        {
            Console.WriteLine($"Unable to load goals: {exception.Message}");
        }
    }

    private static string ReadRequiredText(string prompt)
    {
        while (true)
        {
            string value = ReadLine(prompt);
            if (value == null)
            {
                return null;
            }

            value = value.Trim();
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("This value cannot be empty.");
        }
    }

    private static int? ReadInt(string prompt, int minimum, int maximum = int.MaxValue)
    {
        while (true)
        {
            string value = ReadLine(prompt);
            if (value == null)
            {
                return null;
            }

            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int number) &&
                number >= minimum &&
                number <= maximum)
            {
                return number;
            }

            Console.WriteLine($"Enter a whole number from {minimum} to {maximum}.");
        }
    }

    private static string ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}
