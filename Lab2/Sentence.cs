namespace Lab2;

public class Sentence
{
    private static readonly char[] WordSeparators =  [' ', ':', '–', '—', ',', ';'];

    public string Data { get; }

    public int WordsCount { get; }

    public Sentence(string sentenceStr)
    {
        Data = sentenceStr;
        var words = Data.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
        WordsCount = words.Length;
    }
}
