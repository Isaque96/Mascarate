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
}