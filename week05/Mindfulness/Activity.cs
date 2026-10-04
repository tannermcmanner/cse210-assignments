using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

// Base class containing the attributes and behaviors shared by every
// mindfulness activity (Breathing, Reflecting, Listing, and BodyScan).
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
        ClearScreen();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        int.TryParse(Console.ReadLine(), out _duration);

        ClearScreen();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // Console.Clear() throws if the console output has been redirected (for
    // example, to a file or pipe), so this guards against that scenario.
    private void ClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex % frames.Count]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex++;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int secondsLeft = seconds; secondsLeft > 0; secondsLeft--)
        {
            Console.Write(secondsLeft);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
