class Running : Activity
{
    private readonly double _distanceInMiles;

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles)
        : base(date, lengthInMinutes)
    {
        if (distanceInMiles <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distanceInMiles), "Distance must be greater than zero.");
        }

        _distanceInMiles = distanceInMiles;
    }

    protected override string ActivityName => "Running";

    public override double GetDistance()
    {
        return _distanceInMiles;
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
