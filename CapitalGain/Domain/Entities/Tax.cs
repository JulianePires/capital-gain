using System.Text.Json.Serialization;

namespace CapitalGain.Domain.Entities;

public class Tax
{
    private decimal _taxValue;

    [JsonPropertyName("tax")]
    public decimal TaxValue
    {
        get => _taxValue;
        set => _taxValue = value;
    }
}