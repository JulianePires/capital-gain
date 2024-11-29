using System.Text.Json.Serialization;

namespace CapitalGain.Domain.Entities;

public class Tax
{
    [JsonPropertyName("tax")]
    public decimal TaxValue { get; set; }
}