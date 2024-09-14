// See https://aka.ms/new-console-template for more information
using TableValuesComparer;

const string fileNameWithTables = "Tables.txt";

Console.WriteLine("Table Values Comparer");

if (!File.Exists(fileNameWithTables))
{
    Console.WriteLine("Please place the tables file named \"Tables.txt\" in the directory where the program is placed");
    Console.ReadLine();

    return;
}

var tableText = await File.ReadAllTextAsync(fileNameWithTables);

var distinctTablesCount = tableText.GetTables().Distinct().Count();

if (distinctTablesCount == 0)
{
    Console.WriteLine("There are no tables in the file");
    Console.ReadLine();
    return;
}

if (distinctTablesCount == 1)
{
    Console.WriteLine("All the tables in the file are the same");
    Console.ReadLine();
    return;
}

Console.WriteLine($"There are {distinctTablesCount} different tables in the file");
Console.ReadLine();