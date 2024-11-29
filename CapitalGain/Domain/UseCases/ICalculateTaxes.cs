using CapitalGain.Domain.Entities;

namespace CapitalGain.Domain.UseCases;

public interface ICalculateTaxes
{
    string CalculateTaxes(string userInput);
}