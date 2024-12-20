﻿using CapitalGain.Helpers;

namespace CapitalGainTest.Helpers;

public class HelperTest
{
    [Fact]
    public void SplitInput_Test()
    {
        // Arrange
        string input = "[BUY][PETR4][100][10][SELL][PETR4][50][20]";
        List<string> expected = new List<string> { "[BUY]", "[PETR4]", "[100]", "[10]", "[SELL]", "[PETR4]", "[50]", "[20]" };

        // Act
        List<string> result = Helper.SplitInput(input);

        // Assert
        Assert.Equal(expected, result);
    }
}