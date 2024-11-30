using System.Text.Json.Serialization;

namespace CapitalGain.Domain.Entities;

public class Tax
{
    private string _taxValue;

    [JsonPropertyName("tax")]
    public string TaxValue
    {
        get => _taxValue;
        set => _taxValue = value;
    }
}