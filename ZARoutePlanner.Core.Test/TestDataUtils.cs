namespace ZARoutePlanner.Core.Test;

internal static class TestDataUtils
{
    private const string DataDirectory = "Data";

    internal static string Lines1FilePath => Path.Combine(DataDirectory, "lines-1.json");

    internal static string Lines1Json => File.ReadAllText(Lines1FilePath);

    internal static Graph Lines1Graph => GraphBuilder.FromJson(Lines1Json);
}