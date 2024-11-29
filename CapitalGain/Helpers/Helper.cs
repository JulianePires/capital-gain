namespace CapitalGain.Helpers;

public static class Helper
{
    public static List<string> SplitInput(string input)
    {
        return input.Split("\n").ToList();
    }
}