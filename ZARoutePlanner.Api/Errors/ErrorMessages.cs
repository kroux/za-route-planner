namespace ZARoutePlanner.Api.Errors;

public static class ErrorMessages
{
    public static string StationDoesNotExistMessage(string station) =>
        $"The specified station `{station}` does not exist.";
}