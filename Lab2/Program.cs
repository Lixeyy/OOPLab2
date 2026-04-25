namespace Lab2;

internal class Program
{
    private static void Main(string[] args)
    {
        var text = new StringText("!!!Hello, Team! Hi!!! Fruits: banana,apple,orange. Animals:red parrot;green Monkey\n Years — twenty-one... ?What next?");
        var sortedSentences = text.GetSortedSentences();

        Console.WriteLine($"1. Text:\n{text.Data}\n");
        Console.WriteLine($"2. Sorted sentences:\n{string.Join("\n", sortedSentences)}");

        Console.ReadKey();
    }
}

