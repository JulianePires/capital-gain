using CapitalGain.Domain.Contracts;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Business
{
    public class TaxCalculator : TaxCalculatorContract
    {
        private readonly IList<Tax> _taxes = new List<Tax>();
        private int _currentQuantity;
        private decimal _currentBuyUnitCost;
        private decimal _currentWeightedAverage;
        private decimal _currentSellLoss;
        private bool _recalculateAverage = true;

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
            _currentBuyUnitCost = trade.UnitCost;
            _currentQuantity += trade.Quantity;
            _recalculateAverage = true;
            _taxes.Add(new Tax { TaxValue = 0m });
        }

        private void HandleSellOperation(Trade trade)
        {
            if (_recalculateAverage)
            {
                _currentWeightedAverage = CalculateWeightedAverage(trade.UnitCost, trade.Quantity,
                    _currentWeightedAverage, _currentQuantity);
                _recalculateAverage = false;
            }

            var tax = 0m;
            var sellBalance = CalculateSellBalance(trade.UnitCost, trade.Quantity, _currentBuyUnitCost);

            if (trade.UnitCost < _currentWeightedAverage)
            {
                _currentSellLoss += sellBalance;
            }
            else if (trade.UnitCost > _currentWeightedAverage)
            {
                if (trade.UnitCost * trade.Quantity > 20000)
                {
                    tax = sellBalance * 0.2m;
                }

                if (_currentSellLoss > 0)
                {
                    _currentSellLoss = DeductLossFromProfit(sellBalance, _currentSellLoss);
                }
            }

            _taxes.Add(new Tax { TaxValue = tax });
            _currentQuantity -= trade.Quantity;
        }

        private static decimal DeductLossFromProfit(decimal sellBalance, decimal currentSellLoss)
        {
            return sellBalance > currentSellLoss ? 0 : currentSellLoss - sellBalance;
        }

        private static decimal CalculateSellBalance(decimal sellPrice, int quantity, decimal currentBuyUnitCost)
        {
            return Math.Abs(currentBuyUnitCost - sellPrice) * quantity;
        }

        private static decimal CalculateWeightedAverage(decimal unitCost, int quantity, decimal currentWeightedAverage,
            int currentQuantity)
        {
            return (unitCost * quantity + currentWeightedAverage * currentQuantity) /
                   (quantity + currentQuantity);
        }
    }
}