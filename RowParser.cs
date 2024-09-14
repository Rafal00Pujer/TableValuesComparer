namespace TableValuesComparer;

internal static class RowParser
{
    const string TableColumnStartPrefixPattern = "<td";
    const string TableColumnStartSuffixPattern = ">";
    const string TableColumnEndPattern = "</td>";

    public static Body<string> ParseRow(this string rowText)
    {
        var columnsExtractor = new SubstringExtractor(
            rowText,
            TableColumnStartPrefixPattern,
            TableColumnStartSuffixPattern,
            TableColumnEndPattern);

        var columns = columnsExtractor.Extract();

        return new Body<string>(columns);
    }
}
