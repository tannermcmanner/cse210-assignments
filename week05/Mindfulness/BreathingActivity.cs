using System;

// Guides the user through timed "breathe in" and "breathe out" cycles
// until the activity's duration has elapsed.
class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCountDown(4);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
