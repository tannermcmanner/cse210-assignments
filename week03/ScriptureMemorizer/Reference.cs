class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int _endVerse;

    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse)
    {
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        if (string.IsNullOrWhiteSpace(book))
        {
            throw new ArgumentException("A book name is required.", nameof(book));
        }

        if (chapter < 1 || startVerse < 1 || endVerse < startVerse)
        {
            throw new ArgumentOutOfRangeException(nameof(chapter), "Chapter and verses must be positive, and the end verse cannot precede the start verse.");
        }

        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        string verseRange = _startVerse == _endVerse
            ? _startVerse.ToString()
            : $"{_startVerse}-{_endVerse}";
        return $"{_book} {_chapter}:{verseRange}";
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }
}
