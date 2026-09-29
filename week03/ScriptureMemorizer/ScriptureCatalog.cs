class ScriptureCatalog
{
    public static IReadOnlyList<ScriptureSource> GetSources()
    {
        return new List<ScriptureSource>
        {
            new ScriptureSource(
                new Reference("Doctrine and Covenants", 78, 17, 19),
                "https://www.churchofjesuschrist.org/study/scriptures/dc-testament/dc/78?lang=eng"),
            new ScriptureSource(
                new Reference("Alma", 38, 5),
                "https://www.churchofjesuschrist.org/study/scriptures/bofm/alma/38?lang=eng"),
            new ScriptureSource(
                new Reference("Mosiah", 4, 9),
                "https://www.churchofjesuschrist.org/study/scriptures/bofm/mosiah/4?lang=eng"),
            new ScriptureSource(
                new Reference("Isaiah", 55, 8, 9),
                "https://www.churchofjesuschrist.org/study/scriptures/ot/isa/55?lang=eng"),
            new ScriptureSource(
                new Reference("Jacob", 4, 8),
                "https://www.churchofjesuschrist.org/study/scriptures/bofm/jacob/4?lang=eng"),
            new ScriptureSource(
                new Reference("1 Nephi", 11, 17),
                "https://www.churchofjesuschrist.org/study/scriptures/bofm/1-ne/11?lang=eng"),
            new ScriptureSource(
                new Reference("1 Corinthians", 2, 9),
                "https://www.churchofjesuschrist.org/study/scriptures/nt/1-cor/2?lang=eng")
        }.AsReadOnly();
    }
}
