class Cycling : Activity
{
    private readonly double _speedInMilesPerHour;

    public Cycling(DateTime date, int lengthInMinutes, double speedInMilesPerHour)
        : base(date, lengthInMinutes)
    {
        if (speedInMilesPerHour <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speedInMilesPerHour), "Speed must be greater than zero.");
        }

        _speedInMilesPerHour = speedInMilesPerHour;
    }

    protected override string ActivityName => "Cycling";

    public override double GetDistance()
    {
        return _speedInMilesPerHour * LengthInMinutes / 60;
    }

    public override double GetSpeed()
    {
        return _speedInMilesPerHour;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}
