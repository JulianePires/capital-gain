using CapitalGain.Business;
using CapitalGain.Domain.Entities;

namespace CapitalGainTest.Business
{
    public class TaxCalculatorTest
    {
        [Fact]
        public void CalculateTaxes_BuyOperation_AddsZeroTax()
        {
            var trades = new List<Trade>
            {
                new() { Operation = "buy", UnitCost = 10.00m, Quantity = 100 }
            };
            var taxCalculator = new TaxCalculator();

            var result = taxCalculator.CalculateTaxes(trades);

            Assert.Single(result);
            Assert.Equal("0,00", result[0].TaxValue);
        }

        [Fact]
        public void CalculateTaxes_SellOperation_CalculatesTaxCorrectly()
        {
            var trades = new List<Trade>
            {
                new() { Operation = "buy", UnitCost = 10.00m, Quantity = 100 },
                new() { Operation = "sell", UnitCost = 15.00m, Quantity = 50 }
            };
            var taxCalculator = new TaxCalculator();

            var result = taxCalculator.CalculateTaxes(trades);

            Assert.Equal(2, result.Count);
            Assert.Equal("0,00", result[0].TaxValue);
            Assert.Equal("0,00", result[1].TaxValue); // Assuming no tax
        }

        [Fact]
        public void CalculateTaxes_SellOperationWithHighValue_CalculatesTaxCorrectly()
        {
            var trades = new List<Trade>
            {
                new() { Operation = "buy", UnitCost = 10.00m, Quantity = 100 },
                new() { Operation = "sell", UnitCost = 25.00m, Quantity = 1000 }
            };
            var taxCalculator = new TaxCalculator();

            var result = taxCalculator.CalculateTaxes(trades);

            Assert.Equal(2, result.Count);
            Assert.Equal("0,00", result[0].TaxValue);
            Assert.Equal("3000,00", result[1].TaxValue); // Assuming 20% tax on profit
        }

        [Fact]
        public void CalculateTaxes_SellOperationWithLoss_AccumulatesLossCorrectly()
        {
            var trades = new List<Trade>
            {
                new() { Operation = "buy", UnitCost = 20.00m, Quantity = 100 },
                new() { Operation = "sell", UnitCost = 15.00m, Quantity = 50 }
            };
            var taxCalculator = new TaxCalculator();

            var result = taxCalculator.CalculateTaxes(trades);

            Assert.Equal(2, result.Count);
            Assert.Equal("0,00", result[0].TaxValue);
            Assert.Equal("0,00", result[1].TaxValue); // Assuming no tax due to loss
        }
    }
}