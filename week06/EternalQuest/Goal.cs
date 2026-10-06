using System;
using System.Globalization;
using System.Text;

abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string shortName, string description, int points)
    {
        if (string.IsNullOrWhiteSpace(shortName))
        {
            throw new ArgumentException("A goal name is required.", nameof(shortName));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("A goal description is required.", nameof(description));
        }

        if (points <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points must be greater than zero.");
        }

        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    public static Goal FromStringRepresentation(string representation)
    {
        string[] parts = representation.Split('|');
        if (parts.Length < 4)
        {
            throw new FormatException("A goal entry is missing required fields.");
        }

        string shortName = Decode(parts[1]);
        string description = Decode(parts[2]);
        int points = ParseInt(parts[3], "points");

        switch (parts[0])
        {
            case "SimpleGoal":
                if (parts.Length != 5 || !bool.TryParse(parts[4], out bool isComplete))
                {
                    throw new FormatException("The simple goal entry is invalid.");
                }

                return new SimpleGoal(shortName, description, points, isComplete);

            case "EternalGoal":
                if (parts.Length != 4)
                {
                    throw new FormatException("The eternal goal entry is invalid.");
                }

                return new EternalGoal(shortName, description, points);

            case "ChecklistGoal":
                if (parts.Length != 7)
                {
                    throw new FormatException("The checklist goal entry is invalid.");
                }

                return new ChecklistGoal(
                    shortName,
                    description,
                    points,
                    ParseInt(parts[4], "completed count"),
                    ParseInt(parts[5], "target"),
                    ParseInt(parts[6], "bonus"));

            default:
                throw new FormatException($"Unknown goal type '{parts[0]}'.");
        }
    }

    protected string GetCommonStringRepresentation(string goalType)
    {
        return $"{goalType}|{Encode(_shortName)}|{Encode(_description)}|{_points.ToString(CultureInfo.InvariantCulture)}";
    }

    private static string Encode(string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    private static string Decode(string value)
    {
        try
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
        catch (FormatException exception)
        {
            throw new FormatException("A goal entry contains invalid text data.", exception);
        }
    }

    private static int ParseInt(string value, string fieldName)
    {
        if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
        {
            throw new FormatException($"A goal entry contains an invalid {fieldName} value.");
        }

        return result;
    }
}
