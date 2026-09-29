class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        int wordsToHide = Math.Min(Math.Max(numberToHide, 0), visibleWords.Count);

        for (int index = 0; index < wordsToHide; index++)
        {
            int selectedIndex = Random.Shared.Next(visibleWords.Count);
            visibleWords[selectedIndex].Hide();
            visibleWords.RemoveAt(selectedIndex);
        }
    }

    public string GetDisplayText()
    {
        string displayedWords = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{displayedWords}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
