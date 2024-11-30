using System.Text;
using System.Text.Json;
using CapitalGain.Business;
using CapitalGain.Domain.Entities;
using CapitalGain.Domain.UseCases;
using CapitalGain.Helpers;

namespace CapitalGain.Data.Services
{
    public class OperationsService : IProcessOperationUseCase
    {
        public string CalculateTaxesFromUserInput(string userInput)
        {
            var operations = Helper.SplitInput(userInput);
            var result = new StringBuilder();

            foreach (var operation in operations)
            {
                var trades = JsonSerializer.Deserialize<IList<Trade>>(operation);
                var calculator = new TaxCalculator();
                var taxes = calculator.CalculateTaxes(trades);
                result.Append(JsonSerializer.Serialize(taxes));
            }

            return result.ToString();
        }
    }
}