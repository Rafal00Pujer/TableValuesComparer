namespace TableValuesComparer;

internal static class FileParser
{
    const string TableBodyStartPrefixPattern = "<tbody";
    const string TableBodyStartSuffixPattern = ">";
    const string TableBodyEndPattern = "</tbody>";

    public static IEnumerable<Body<Body<string>>> GetTables(this string fileText)
    {
        var tablesExtractor = new SubstringExtractor(
            fileText,
            TableBodyStartPrefixPattern,
            TableBodyStartSuffixPattern,
            TableBodyEndPattern);

        var tables = tablesExtractor.Extract().Select(x => x.ParseTable());

        return tables;
    }
}
