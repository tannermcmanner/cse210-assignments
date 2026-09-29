using System.Net;
using System.Text.RegularExpressions;

class ScriptureRepository
{
    private static readonly HttpClient Client = new HttpClient();

    public async Task<Scripture> LoadScriptureAsync(ScriptureSource source)
    {
        using HttpResponseMessage response = await Client.GetAsync(source.GetUrl());
        response.EnsureSuccessStatusCode();

        string page = await response.Content.ReadAsStringAsync();
        Reference reference = source.GetReference();
        List<string> verses = new List<string>();

        for (int verseNumber = reference.GetStartVerse(); verseNumber <= reference.GetEndVerse(); verseNumber++)
        {
            string verse = ExtractVerse(page, verseNumber, reference);
            verses.Add(verse);
        }

        return new Scripture(reference, string.Join(" ", verses));
    }

    private static string ExtractVerse(string page, int verseNumber, Reference reference)
    {
        string pattern = $@"<p\b(?=[^>]*\bclass=""[^""]*\bverse\b[^""]*"")(?=[^>]*\bid=""p{verseNumber}"")[^>]*>(.*?)</p>";
        Match match = Regex.Match(page, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        if (!match.Success)
        {
            throw new InvalidDataException(
                $"The official scripture page did not contain {reference.GetDisplayText()}.");
        }

        string text = Regex.Replace(match.Groups[1].Value, "<[^>]+>", string.Empty);
        text = WebUtility.HtmlDecode(text);
        text = Regex.Replace(text, @"^\s*\d+\s*", string.Empty);
        return Regex.Replace(text, @"\s+", " ").Trim();
    }
}
