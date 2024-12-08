using Mascarate.Exceptions;
using Mascarate.Extensions;

namespace Mascarate.Tests.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void Mascarate_ParameterStringIsNull_ThrowsArgumentNullException()
    {
        #region Arrange
        string? nullString = null;
        #endregion
        
        #region Act
        void Action() => "Test for masking".Mascarate(nullString);
        #endregion
        
        #region Assert
        Assert.Throws<ArgumentNullException>(Action);
        #endregion
    }
    
    [Theory]
    [InlineData("###.###.###-##", "12345678910", "123.456.789-10")]
    [InlineData("###-###", "123456", "123-456")]
    [InlineData("###.###", "456789", "456.789")]
    public void Mascarate_WhenMaskIsNumericCorrectAndValueIsNumericOnly_ShouldReturnValuesWithMask(
        string mask,
        string value,
        string expectedResult
    )
    {
        // No Arrange Needed

        #region Act
        var result = value.Mascarate(mask);
        #endregion

        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }

    [Theory]
    [InlineData("12@@@", "JOH", "12JOH")]
    [InlineData("12@@@", "JES", "12JES")]
    [InlineData("12@@@", "BAB", "12BAB")]
    public void Mascarate_WhenMaskIsWithLettersAndValueIsLettersOnly_ShouldReturnValuesWithMask(
        string mask,
        string value,
        string expectedResult
    )
    {
        // No Arrange Needed
        
        #region Act
        var result = value.Mascarate(mask);
        #endregion

        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }
    
    [Fact]
    public void Mascarate_WhenMaskIsNumericCorrectAndValueIsNotNumericOnly_ShouldThrowArgumentException()
    {
        #region Arrange
        const string mask = "###.###.###-##";
        const string numbers = "1234567891.";
        var expectedResult = "The value '.' is invalid for the mask type 'Numbers' (code: '#')." +
                Environment.NewLine +
                "Expected values: 0-9.";
        #endregion

        #region Act
        var exception = Assert.Throws<InvalidValueForMaskTypeException>(() => numbers.Mascarate(mask));
        #endregion

        #region Assert
        Assert.Equal(expectedResult, exception.Message);
        #endregion
    }

    [Fact]
    public void Mascarate_WhenMaskIsNotInTheRightLengthWithValue_ShouldThrow()
    {
        #region Arrange
        const string mask = "##-##";
        const string numbers = "123";
        #endregion

        #region Act
        var exception = Assert.Throws<MissingValuesException>(() => numbers.Mascarate(mask));
        #endregion

        #region Assert
        Assert.Equal("The input value length does not match the number of mask placeholders.", exception.Message);
        #endregion
    }

    [Theory]
    [InlineData("###.###.###-##", "123.456.789-10", "12345678910")]
    [InlineData("###-###", "123-456", "123456")]
    [InlineData("###.###", "456.789", "456789")]
    public void UnMascarate_WhenMaskIsNumericCorrectAndValueIsNumericOnly_ShouldReturnValuesWithoutMask(
        string mask,
        string value,
        string expectedResult
    )
    {
        // Non Arrange Needed
        
        #region Act
        var result = value.UnMascarate(mask);
        #endregion
        
        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }
}