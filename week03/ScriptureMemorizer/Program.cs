// Exceeding requirements: Randomly practices a library of seven selected scriptures, downloads their text from the official Church scripture site, and avoids repeating a scripture until each one in the library has been practiced.
using System.Net.Http;

class Program
{
    static async Task Main(string[] args)
    {
        List<ScriptureSource> sources = ScriptureCatalog.GetSources()
            .OrderBy(_ => Random.Shared.Next())
            .ToList();
        ScriptureRepository repository = new ScriptureRepository();

        for (int index = 0; index < sources.Count; index++)
        {
            ScriptureSource source = sources[index];
            Scripture scripture;

            try
            {
                scripture = await repository.LoadScriptureAsync(source);
            }
            catch (Exception exception) when (
                exception is HttpRequestException or InvalidDataException)
            {
                Console.WriteLine($"Could not load {source.GetReference().GetDisplayText()}.");
                Console.WriteLine(exception.Message);
                return;
            }

            PracticeScripture(scripture, index + 1, sources.Count);
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Scripture hidden. Moving to the next passage...");
                Console.WriteLine("Press Enter to continue or type quit to end.");
                if (Console.ReadLine()?.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase) == true)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        ClearConsole();
        Console.WriteLine("You practiced all seven scriptures. Well done!");
    }

    private static void PracticeScripture(Scripture scripture, int current, int total)
    {
        while (!scripture.IsCompletelyHidden())
        {
            ClearConsole();
            Console.WriteLine($"Scripture {current} of {total}");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide up to three words, or type quit to end.");

            string input = Console.ReadLine();
            if (input?.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase) == true)
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        ClearConsole();
        Console.WriteLine($"Scripture {current} of {total}");
        Console.WriteLine(scripture.GetDisplayText());
    }

    private static void ClearConsole()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}
