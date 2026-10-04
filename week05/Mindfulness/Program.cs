// Exceeding Requirements: I added a fourth kind of mindfulness activity: the Body Scan Activity. It guides the user through a progressive muscle relaxation exercise, focusing on and releasing tension from different body parts (toes, legs, torso, arms, shoulders, and head) with a countdown pause after each one, repeating until the chosen duration has passed.

using System;
class Program
{
    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start body scan activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            // Console.ReadLine() returns null if the input stream has ended
            // (for example, piped input ran out), so quit instead of looping.
            if (choice == null)
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;

                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;

                case "4":
                    BodyScanActivity bodyScanActivity = new BodyScanActivity();
                    bodyScanActivity.Run();
                    break;

                case "5":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}