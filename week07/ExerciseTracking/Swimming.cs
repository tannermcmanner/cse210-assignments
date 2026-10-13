class Swimming : Activity
{
    private const double LapLengthInMiles = 50.0 / 1000 * 0.62;
    private readonly int _numberOfLaps;

    public Swimming(DateTime date, int lengthInMinutes, int numberOfLaps)
        : base(date, lengthInMinutes)
    {
        if (numberOfLaps <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfLaps), "Number of laps must be greater than zero.");
        }

        _numberOfLaps = numberOfLaps;
    }

    protected override string ActivityName => "Swimming";

    public override double GetDistance()
    {
        return _numberOfLaps * LapLengthInMiles;
    }

    public override double GetSpeed()
    {
        return GetDistance() / LengthInMinutes * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }
}
