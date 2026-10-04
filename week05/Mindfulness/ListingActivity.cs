using System;
using System.Collections.Generic;

// Chooses a random prompt, gives the user time to think, then collects
// the items the user lists until time runs out.
class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
    }

    private string GetRandomPrompt()
    {
        return "";
    }

    private List<string> GetListFromUser()
    {
        return new List<string>();
    }
}
