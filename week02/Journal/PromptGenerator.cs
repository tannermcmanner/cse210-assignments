using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What's one thing I accomplished today?",
            "What's one thing I did for someone else today?",
            "Name something good that happened today.",
            "What's one thing I could have done better today?",
            "Name something I did physically active today.",
            "How did I see the hand of the Lord in my life today?"
        };

        _random = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
