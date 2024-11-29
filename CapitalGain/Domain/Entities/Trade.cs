using System.Text.Json.Serialization;

namespace CapitalGain.Domain.Entities;

public class Trade
{
    private string _operation;
    private decimal _unitCost;
    private int _quantity;
    
    [JsonPropertyName("operation")]
    public string Operation { get => _operation; set => _operation = value; }
    
    [JsonPropertyName("unit-cost")]
    public decimal UnitCost { get => _unitCost; set => _unitCost = value; }
    
    [JsonPropertyName("quantity")]
    public int Quantity { get => _quantity; set => _quantity = value; }
}