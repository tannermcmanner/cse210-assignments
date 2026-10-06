class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : this(shortName, description, points, 0, target, bonus)
    {
    }

    internal ChecklistGoal(string shortName, string description, int points, int amountCompleted, int target, int bonus)
        : base(shortName, description, points)
    {
        if (target <= 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(target), "The target must be greater than zero.");
        }

        if (amountCompleted < 0 || amountCompleted > target)
        {
            throw new System.ArgumentOutOfRangeException(nameof(amountCompleted), "Completed count must be between zero and the target.");
        }

        if (bonus < 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(bonus), "The bonus cannot be negative.");
        }

        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        return GetPoints() + (IsComplete() ? _bonus : 0);
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} (Completed {_amountCompleted}/{_target} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetCommonStringRepresentation("ChecklistGoal")}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
