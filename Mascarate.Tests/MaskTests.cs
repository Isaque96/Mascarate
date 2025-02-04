namespace Mascarate.Tests;

public class MaskTests
{
    [Fact]
    public void Apply_WhenMaskIsNumericCorrectAndValueIsNumericOnly_ShouldReturnValuesWithMask()
    {
        #region Arrange
        const string mask = "###.###.###-##";
        const string value = "12345678910";
        const string expectedResult = "123.456.789-10";
        #endregion

        #region Act
        var result = Mask.Apply(value, mask);
        #endregion

        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }
    
    [Fact]
    public void Remove_WhenMaskIsNumericCorrectAndValueIsNumericOnly_ShouldReturnValuesWithoutMask()
    {
        #region Arrange
        const string mask = "###.###.###-##";
        const string value = "123.456.789-10";
        const string expectedResult = "12345678910";
        #endregion

        #region Act
        var result = Mask.Remove(value, mask);
        #endregion

        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }
    
    [Fact]
    public void Remove_WhenMaskIsNumericCorrectAndNoMaskParameterIsPassed_ShouldReturnValuesWithoutMask()
    {
        #region Arrange
        const string value = "123.456.789-10";
        const string expectedResult = "12345678910";
        #endregion

        #region Act
        var result = Mask.Remove(value);
        #endregion

        #region Assert
        Assert.Equal(expectedResult, result);
        #endregion
    }
    
    [Fact]
    public void Validate_WhenMaskIsNumericCorrectAndValueIsNumericOnly_ShouldReturnTrue()
    {
        #region Arrange
        const string mask = "###.###.###-##";
        const string value = "123.456.789-10";
        #endregion

        #region Act
        var result = Mask.Validate(value, mask);
        #endregion

        #region Assert
        Assert.True(result);
        #endregion
    }
}