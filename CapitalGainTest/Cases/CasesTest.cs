using CapitalGain.Data.Services;
using CapitalGain.Domain.Contracts;
using CapitalGain.Domain.UseCases;

namespace CapitalGainTest.Cases;

public class CasesTest
{
    IProcessOperationUseCase _service = new OperationsService();

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}]")]
    public void CaseTest1(string input)
    {
        const string expectedOutput = "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 500}]")]
    public void CaseTest2(string input)
    {
        const string expectedOutput = "[{\"tax\": 0.00},{\"tax\": 10000.00},{\"tax\": 0.00}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }
}