namespace EkartApi.Models;

public class EKartCartItem
{
    public int Id{get;set;}

    public string? ProductName {get; set;}
    
    public string? ImageUrl {get; set;}

    public decimal UnitPrice {get; set;}

    public decimal SubTotal {get; set;}

    public int Quantity {get; set;}
}