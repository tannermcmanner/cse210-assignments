using System;

// Base class containing the attributes and behaviors shared by every
// mindfulness activity (Breathing, Reflecting, and Listing).
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
    }

    public void DisplayEndingMessage()
    {
    }

    public void ShowSpinner(int seconds)
    {
    }

    public void ShowCountDown(int seconds)
    {
    }
}
