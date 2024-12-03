using System.Text.Json;
using CapitalGain.Data.Services;
using CapitalGain.Domain.Contracts;
using CapitalGain.Domain.Entities;
using CapitalGain.Helpers;
using Moq;

namespace CapitalGainTest.Data.Services;

public class OperationsServiceTest
{
    [Fact]
    public void CalculateTaxesFromUserInput_ValidInput_ReturnsExpectedResult()
    {
        var userInput =
            "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100}, {\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}, {\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}]";
        var expectedOutput = "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"}]";

        var service = new OperationsService();

        var result = service.CalculateTaxesFromUserInput(userInput);

        Assert.Equal(expectedOutput, result);
    }
}