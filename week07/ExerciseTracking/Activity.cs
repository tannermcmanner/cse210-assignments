using System.Globalization;

abstract class Activity
{
    private readonly DateTime _date;
    private readonly int _lengthInMinutes;

    protected Activity(DateTime date, int lengthInMinutes)
    {
        if (lengthInMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lengthInMinutes), "Activity length must be greater than zero.");
        }

        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    protected int LengthInMinutes => _lengthInMinutes;

    protected abstract string ActivityName { get; }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)} {ActivityName} " +
               $"({_lengthInMinutes} min) - Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
