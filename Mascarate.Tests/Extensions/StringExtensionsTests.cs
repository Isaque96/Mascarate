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
    
    [Fact]
    public void FormatMask_WhenMaskIsNumericCorrectAndValueIsNumericOnly_ShouldReturnValuesWithMask()
    {
        #region Arrange
        const string mask = "###.###.###-##";
        const string numbers = "12345678910";
        const string expectedResult = "123.456.789-10";
        #endregion

        #region Act
        var result = numbers.Mascarate(mask);
        #endregion

        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }
    
    [Fact]
    public void FormatMask_WhenMaskIsNumericCorrectAndValueIsNotNumericOnly_ShouldThrowArgumentException()
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
}