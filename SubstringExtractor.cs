namespace TableValuesComparer;

internal class SubstringExtractor(
    string text,
    string bodyStartPrefix,
    string bodyStartSuffix,
    string bodyEndPrefix)
{
    private readonly string _text = text;
    private readonly string _bodyStartPrefix = bodyStartPrefix;
    private readonly string _bodyStartSuffix = bodyStartSuffix;
    private readonly string _bodyEndPrefix = bodyEndPrefix;

    public IEnumerable<string> Extract()
    {
        var nextIndex = TryGetNextBody(0, out var body);

        while (nextIndex != -1)
        {
            yield return body;

            nextIndex = TryGetNextBody(nextIndex, out body);
        }
    }

    private int TryGetNextBody(int startIndex, out string body)
    {
        body = string.Empty;

        var prefixIndex = _text.IndexOf(
            _bodyStartPrefix, startIndex,
            StringComparison.InvariantCultureIgnoreCase);

        if (prefixIndex == -1)
        {
            return -1;
        }

        var sufixIndex = _text.IndexOf(
            _bodyStartSuffix,
            prefixIndex + _bodyStartPrefix.Length,
            StringComparison.InvariantCultureIgnoreCase);

        if (sufixIndex == -1)
        {
            return -1;
        }

        var endIndex = _text.IndexOf(
            _bodyEndPrefix,
            sufixIndex + _bodyStartSuffix.Length,
            StringComparison.InvariantCultureIgnoreCase);

        if (endIndex == -1)
        {
            return -1;
        }

        body = _text[(sufixIndex + 1)..endIndex];
        return endIndex + _bodyEndPrefix.Length;
    }
}
