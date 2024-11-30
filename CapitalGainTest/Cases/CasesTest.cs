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
        const string expectedOutput = "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 500}]")]
    public void CaseTest2(string input)
    {
        const string expectedOutput = "[{\"tax\":\"0.00\"},{\"tax\":\"10000.00\"},{\"tax\":\"0.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100}, {\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}, {\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}] [{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}, {\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 5000}, {\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000}]")]
    public void CaseTest1Plus2(string input)
    {
        const string expectedOutput =
            "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"}][{\"tax\":\"0.00\"},{\"tax\":\"10000.00\"},{\"tax\":\"0.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 3000}]")]
    public void CaseTest3(string input)
    {
        const string expectedOutput = "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"1000.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000}]")]
    public void CaseTest4(string input)
    {
        const string expectedOutput = "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 5000}]")]
    public void CaseTest5(string input)
    {
        const string expectedOutput =
            "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"10000.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000},{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}]")]
    public void CaseTest6(string input)
    {
        const string expectedOutput =
            "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"3000.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000},{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000},{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000},{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 5000},{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 4350},{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 650}]")]
    public void CaseTest7(string input)
    {
        const string expectedOutput =
            "[{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"3000.00\"},{\"tax\":\"0.00\"},{\"tax\":\"0.00\"},{\"tax\":\"3700.00\"},{\"tax\":\"0.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(
        "[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000},{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}]")]
    public void CaseTest8(string input)
    {
        const string expectedOutput =
            "[{\"tax\":\"0.00\"},{\"tax\":\"80000.00\"},{\"tax\":\"0.00\"},{\"tax\":\"60000.00\"}]";
        var result = _service.CalculateTaxesFromUserInput(input);
        Assert.Equal(expectedOutput, result);
    }
}