using System.Text.RegularExpressions;

namespace CapitalGain.Helpers;

public static class Helper
{
    public static List<string> SplitInput(string input)
    {
        var matches = Regex.Matches(input, @"[^\]]*\]");
        return matches.Select(m => m.Value).ToList();
    }
}