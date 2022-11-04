using EkartApi.Models;

public class EKartCartRepository : IEKartCartRepository
{
    private List<EKartCartItem> _CartItem;
    public EKartCartRepository()
    {
        _CartItem = new List<EKartCartItem>();
        _CartItem.Add(new EKartCartItem
        {
            Id = 1,
            ProductName = "Kiara Guest Chair",
            UnitPrice = 12000,
            Quantity = 2,
            GrandTotal = 24000
        });
    }

    public List<EKartCartItem> GetCartItems()
    {
        return _CartItem;
    }
    public List<EKartCartItem> CreateCartItem(EKartCartItem EKartCartItem)
    {
        int NoOfRecords = _CartItem.Count();
        EKartCartItem.Id = 1;
        if (NoOfRecords > 0)
        {
            EKartCartItem.Id = _CartItem.Max(p => p.Id) + 1;
        }
        _CartItem.Add(EKartCartItem);
        return _CartItem;

    }

    public List<EKartCartItem> UpdateCartItem(EKartCartItem EKartCartItem)
    {
        int i = _CartItem.FindIndex(p => p.Id == EKartCartItem.Id);
        if (i >= 0)
        {
            _CartItem[i].ProductName = EKartCartItem.ProductName;
            _CartItem[i].GrandTotal = EKartCartItem.GrandTotal;
            _CartItem[i].UnitPrice = EKartCartItem.UnitPrice;
            _CartItem[i].Quantity = EKartCartItem.Quantity;


        }
        return _CartItem;
    }

    public List<EKartCartItem> DeleteCartItem(int id)
    {
        var result = _CartItem.Where(p => p.Id == id).FirstOrDefault();
        if (result != null)
        {
            _CartItem.Remove(result);
        }
        return _CartItem;
    }

}