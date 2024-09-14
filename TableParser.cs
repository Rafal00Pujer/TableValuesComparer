namespace TableValuesComparer;

internal static class TableParser
{
    const string TableRowStartPrefixPattern = "<tr";
    const string TableRowStartSuffixPattern = ">";
    const string TableRowEndPattern = "</tr>";

    public static Body<Body<string>> ParseTable(this string tableText)
    {
        var rowsExtractor = new SubstringExtractor(
            tableText,
            TableRowStartPrefixPattern,
            TableRowStartSuffixPattern,
            TableRowEndPattern);

        var rows = rowsExtractor.Extract().Select(x => x.ParseRow());

        return new Body<Body<string>>(rows);
    }
}
