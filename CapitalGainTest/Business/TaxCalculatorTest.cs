using CapitalGain.Business;
using CapitalGain.Domain.Entities;

namespace CapitalGainTest.Business;

public class TaxCalculatorTest
{
    [Fact]
    public void CalculateTaxes_WhenCalled_ReturnsTaxes()
    {
        // Arrange
        var trades = new List<Trade>
        {
            new Trade
            {
                Operation = "buy",
                UnitCost = 10,
                Quantity = 100
            },
            new Trade
            {
                Operation = "sell",
                UnitCost = 20,
                Quantity = 50
            }
        };
        var taxCalculator = new TaxCalculator();

        // Act
        var result = taxCalculator.CalculateTaxes(trades);

        // Assert
        Assert.NotNull(result);
    }
}