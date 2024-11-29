using CapitalGain.Data.Services;

namespace CapitalGainTest.Data.Services;

public class OperationsServiceTest
{
    [Fact]
    public void CalculateTaxes_Test()
    {
        // Arrange
        var operationsService = new OperationsService();
        var input =
            "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100},\n{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50},\n{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}]";
        var expected = "[{\"tax\": 0.00},{\"tax\": 0.00},{\"tax\": 0.00}]\n";

        // Act
        var result = operationsService.CalculateTaxes(input);

        // Assert
        Assert.Equal(expected, result);
    }
}