namespace Lab2;

public class StringText
{
    private static readonly char[] SentenceSeparators =  ['!', '?', '.', '\n'];

    public string Data { get; }

    public StringText(string txt)
    {
        Data = txt;
    }

    public Sentence[] GetSortedSentences()
    {
        var sentences = DivideIntoSentences();
        sentences.Sort(SentenceComparerByWordsCount);
        return sentences;
    }

    private Sentence[] DivideIntoSentences()
    {
        var strSentences = Data.Split(SentenceSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var result = new Sentence[strSentences.Length];
        var currIndex = 0;

        for (var i = 0; i < strSentences.Length; i++)
        {
            (currIndex, result[i]) = ExtractFullSentence(currIndex, strSentences[i]);
        }

        return result;
    }

    private (int currIndex, Sentence sentence) ExtractFullSentence(int currIndex, string rawSentence)
    {
        var startIndex = Data.IndexOf(rawSentence, currIndex, StringComparison.Ordinal);
        var endIndex = startIndex + rawSentence.Length;

        while (endIndex < Data.Length && SentenceSeparators.Contains(Data[endIndex]))
        {
            endIndex++;
        }

        var wholeSentence = Data.Substring(startIndex, endIndex - startIndex);
        var sentenceObj = new Sentence(wholeSentence);

        return (endIndex, sentenceObj);
    }

    private static int SentenceComparerByWordsCount(Sentence sentence1, Sentence sentence2)
    {
        return sentence1.WordsCount.CompareTo(sentence2.WordsCount);
    }
}
