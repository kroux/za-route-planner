namespace ZARoutePlanner.Core.Test;

public static class TestUtils
{
    public static void IsArgumentNullException(Exception exception, string parameter)
    {
        Assert.IsType<ArgumentNullException>(exception);
        Assert.Equal(parameter, ((ArgumentNullException)exception).ParamName);
    }
}