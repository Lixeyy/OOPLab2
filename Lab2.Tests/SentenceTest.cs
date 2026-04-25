using JetBrains.Annotations;
using Lab2;
using Xunit;

namespace Lab2.Tests;

[TestSubject(typeof(Sentence))]
public class SentenceTest
{
    [Fact]
    public void Data_ShouldReturnInputText()
    {
        // Arrange
        var text = "hello world";
        var sentence = new Sentence(text);
        
        // Act
        var result = sentence.Data;

        // Assert
        Assert.Equal(text, result);
    }
    
    [Fact]
    public void WordsCount_WhenDataIsEmpty_ShouldReturnZero()
    {
        // Arrange
        var sentence = "";
        var sentenceObj = new Sentence(sentence);

        // Act
        var result = sentenceObj.WordsCount;

        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void WordsCount_WhenDataHasWordsSeparatedBySpaces_ShouldReturnCorrectNumber()
    {
        // Arrange
        var sentence = "My name is Alex.";
        var sentenceObj = new Sentence(sentence);

        // Act
        var result = sentenceObj.WordsCount;

        // Assert
        Assert.Equal(4, result);
    }
    
    [Fact]
    public void WordsCount_WhenDataHasDifferentSeparators_ShouldReturnCorrectNumber()
    {
        // Arrange
        var sentence = "Fruits:bananas,mango-marakuyas;apples — cool food!";
        var sentenceObj = new Sentence(sentence);

        // Act
        var result = sentenceObj.WordsCount;

        // Assert
        Assert.Equal(6, result);
    }
}