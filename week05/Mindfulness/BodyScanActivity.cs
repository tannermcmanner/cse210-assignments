using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS: This is an additional mindfulness activity (not
// required by the core specification) added to show creativity. It guides
// the user through a progressive muscle relaxation / body scan, walking
// sequentially through body parts and pausing with a countdown on each one
// until the activity's duration has elapsed. See the comment in Program.cs
// for a full description of this enhancement.
class BodyScanActivity : Activity
{
    private List<string> _bodyParts;

    public BodyScanActivity()
        : base(
            "Body Scan",
            "This activity will help you relax by having you focus on and release tension from one part of your body at a time, from your toes to your head.")
    {
        _bodyParts = new List<string>
        {
            "your toes and feet",
            "your calves and shins",
            "your knees and thighs",
            "your hips and lower back",
            "your stomach and chest",
            "your hands and arms",
            "your shoulders and neck",
            "your face and head"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int partIndex = 0;

        while (DateTime.Now < endTime)
        {
            string bodyPart = _bodyParts[partIndex % _bodyParts.Count];

            Console.WriteLine();
            Console.Write($"Focus on {bodyPart}. Breathe in, and relax any tension you feel...");
            ShowCountDown(5);
            Console.WriteLine();

            partIndex++;
        }

        DisplayEndingMessage();
    }
}
