namespace EkartApi.Models;

public class EKartCartItem
{
    public int Id{get;set;}

    public string? ProductName {get; set;}

    public decimal UnitPrice {get; set;}

    public decimal GrandTotal {get; set;}

    public int Quantity {get; set;}
}