using CapitalGain.Domain.Entities;

namespace CapitalGain.Domain.Contracts;

public interface TaxCalculatorContract
{
    IList<Tax> CalculateTaxes(IList<Trade> trades);
}