using Mascarate.Configurations;
using Mascarate.Exceptions;
using Mascarate.Extensions;

namespace Mascarate.Tests.Configurations;

public class GlobalConfigTests
{
    [Fact]
    public void Configure_WhenShouldThrowExceptionIsFalse_ThenShouldntThrowExceptionAndReturnNull()
    {
        #region Assert
        GlobalConfig.Configure(options => options.ShouldThrowFailureExceptions = false);
        #endregion

        #region Act
        var result = "".Mascarate("###");
        #endregion

        #region Assert
        Assert.Null(result);
        #endregion
    }
    
    [Theory]
    [InlineData("", typeof(ArgumentNullException))]
    [InlineData("1234", typeof(MissingValuesException))]
    public void Configure_WhenShouldThrowExceptionIsTrue_ThenShouldThrowException(string input, Type exceptionType)
    {
        #region Assert
        GlobalConfig.Configure(options => options.ShouldThrowFailureExceptions = true);
        #endregion

        #region Act
        void Action() => input.Mascarate("###");
        #endregion

        #region Assert
        Assert.Throws(exceptionType, Action);
        #endregion
    }
}