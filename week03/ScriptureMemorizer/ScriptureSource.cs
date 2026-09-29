class ScriptureSource
{
    private readonly Reference _reference;
    private readonly string _url;

    public ScriptureSource(Reference reference, string url)
    {
        _reference = reference;
        _url = url;
    }

    public Reference GetReference()
    {
        return _reference;
    }

    public string GetUrl()
    {
        return _url;
    }
}
