using JetBrains.Annotations;
using Xunit;

namespace Lab2.Tests;

[TestSubject(typeof(StringText))]
public class StringTextTest
{
    [Fact]
    public void Data_ShouldReturnInputText()
    {
        // Arrange
        var data = "Grammar is cool!  Thank you... ";
        var textObj = new StringText(data);

        // Act
        var result = textObj.Data;

        // Assert
        Assert.Equal(data, result);
    }

    [Fact]
    public void GetSortedSentences_WhenTextIsEmpty_ShouldReturnEmptyArray()
    {
        // Arrange
        var textObj = new StringText("");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetSortedSentences_WhenTextHasTrailingSpaces_ShouldReturnTrimmedSentence()
    {
        // Arrange
        var textObj = new StringText(" Hello World! ");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Single(result);
        Assert.Equal("Hello World!", result[0].Data);
        Assert.Equal(2, result[0].WordsCount);
    }

    [Fact]
    public void GetSortedSentences_WhenSentencesSeparatedBySingleSeparators_ShouldReturnSortedSentencesWithSeparators()
    {
        // Arrange
        var textObj = new StringText("Hi! Is it Ok? Red, blue, green - are colors. Check;Test.The end");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Equal(5, result.Length);
        Assert.Equal("Hi!", result[0].Data);
        Assert.Equal("Check;Test.", result[1].Data);
        Assert.Equal("The end", result[2].Data);
        Assert.Equal("Is it Ok?", result[3].Data);
        Assert.Equal("Red, blue, green - are colors.", result[4].Data);
    }

    [Fact]
    public void GetSortedSentences_WhenSentencesSeparatedByMultipleSeparators_ShouldReturnSentencesWithAllSeparators()
    {
        // Arrange
        var textObj = new StringText("Let start...  What?!   It is amazing!!!! The end.");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Equal(4, result.Length);
        Assert.Equal("What?!", result[0].Data);
        Assert.Equal("Let start...", result[1].Data);
        Assert.Equal("The end.", result[2].Data);
        Assert.Equal("It is amazing!!!!", result[3].Data);
    }

    [Fact]
    public void GetSortedSentences_WhenTextHasEmptySentences_ShouldOmitThem()
    {
        // Arrange
        var textObj = new StringText("!Що буде далі? . Не знаю. ?");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Equal(2, result.Length);
        Assert.Equal("Не знаю.", result[0].Data);
        Assert.Equal("Що буде далі?", result[1].Data);
    }

    [Fact]
    public void GetSortedSentences_ShouldNotChangeData()
    {
        // Arrange
        var textObj = new StringText("Привіт усім!  Я Олексій. Усе ");

        // Act
        var result = textObj.GetSortedSentences();
        var textData = textObj.Data;

        // Assert
        Assert.Equal("Привіт усім!  Я Олексій. Усе ", textData);
        Assert.Equal("Усе", result[0].Data);
    }
}
