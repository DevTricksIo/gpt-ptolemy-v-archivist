using ConsoleArchivist.Helpers;

namespace ConsoleArchivistTester;

public class StringExtensionTests
{
    [Theory]
    [InlineData("true")]
    [InlineData("TRUE")]
    [InlineData("tRuE")]
    public void CheckTrueString_Success(string str)
    {
        //Arrange
        //Act
        //Assert
        Assert.True(str.Boolify());
    }

    [Theory]
    [InlineData("false")]
    [InlineData("FALSE")]
    [InlineData("fAlSe")]
    public void CheckFalseString_Success(string str)
    {
        //Arrange
        //Act
        //Assert
        Assert.False(str.Boolify());
    }

    [Theory]
    [InlineData("")]
    [InlineData("null")]
    [InlineData("I don't know")]
    [InlineData(null)]
    public void CheckNullString_Success(string str)
    {
        //Arrange
        //Act
        //Assert
        Assert.False(str.Boolify());
    }
}
