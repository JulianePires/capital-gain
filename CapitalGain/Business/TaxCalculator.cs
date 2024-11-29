using CapitalGain.Domain.Contracts;
using CapitalGain.Domain.Entities;

namespace CapitalGain.Business;

public class TaxCalculator : TaxCalculatorContract
{
    public IList<Tax> CalculateTaxes(IList<Trade> trades)
    {
        throw new NotImplementedException();
    }
}