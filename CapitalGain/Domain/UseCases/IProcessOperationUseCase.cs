using CapitalGain.Domain.Entities;

namespace CapitalGain.Domain.UseCases;

public interface IProcessOperationUseCase
{
    string CalculateTaxesFromUserInput(string userInput);
}