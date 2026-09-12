using System;

// Exceeding Requirements: This program includes a sixth prompt, "How did I see the hand of the Lord in my life today?", which goes beyond the minimum requirement.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine($"Journal saved to {saveFilename}.");
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine($"Journal loaded from {loadFilename}.");
                    break;

                case "5":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("That is not a valid selection. Please try again.");
                    break;
            }
        }
    }
}