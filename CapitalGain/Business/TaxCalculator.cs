using CapitalGain.Domain.Contracts;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Business
{
    public class TaxCalculator : TaxCalculatorContract
    {
        private readonly IList<Tax> _taxes = new List<Tax>();
        private int _currentQuantity;
        private decimal _currentWeightedAverage;
        private decimal _currentSellLoss;

        public IList<Tax> CalculateTaxes(IList<Trade> trades)
        {
            foreach (var trade in trades)
            {
                switch (trade.Operation)
                {
                    case "buy":
                        HandleBuyOperation(trade);
                        break;
                    case "sell":
                        HandleSellOperation(trade);
                        break;
                }
            }

            return _taxes;
        }

        private void HandleBuyOperation(Trade trade)
        {
            _currentWeightedAverage = CalculateWeightedAverage(trade.UnitCost, trade.Quantity,
                _currentWeightedAverage, _currentQuantity);
            _currentQuantity += trade.Quantity;
            _taxes.Add(new Tax { TaxValue = 0.ToString("F").Replace(',', '.') });
        }

        private void HandleSellOperation(Trade trade)
        {
            _currentQuantity -= trade.Quantity;

            var tax = 0m;

            var sellBalance = CalculateSellBalance(trade.UnitCost, trade.Quantity, _currentWeightedAverage);

            if (trade.UnitCost < _currentWeightedAverage)
            {
                _currentSellLoss += sellBalance;
            }
            else if (trade.UnitCost > _currentWeightedAverage)
            {
                if (_currentSellLoss > 0)
                {
                    if (sellBalance > _currentSellLoss)
                    {
                        sellBalance -= _currentSellLoss;
                        _currentSellLoss = 0;
                    }
                    else
                    {
                        _currentSellLoss -= sellBalance;
                        sellBalance = 0;
                    }
                }

                if (trade.UnitCost * trade.Quantity > 20000)
                {
                    tax = sellBalance * 0.2m;
                }
            }

            _taxes.Add(new Tax { TaxValue = tax.ToString("F").Replace(',', '.') });
        }

        private static decimal CalculateSellBalance(decimal unitCost, int quantity, decimal averageCost)
        {
            return
                Math.Abs(unitCost - averageCost) * quantity;
        }

        private static decimal CalculateWeightedAverage(decimal unitCost, int quantity, decimal currentWeightedAverage,
            int currentQuantity)
        {
            return Math.Round(unitCost * quantity + currentWeightedAverage * currentQuantity) /
                   (quantity + currentQuantity);
        }
    }
}