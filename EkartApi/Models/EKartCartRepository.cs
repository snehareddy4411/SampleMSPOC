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
            ImageUrl = "https://secure.img1-fg.wfcdn.com/im/43738380/resize-h600-w600%5Ecompr-r85/1215/121583674/Jamari+Upholstered+Accent+Chair.jpg",
            UnitPrice = 12000,
            Quantity = 2,
            SubTotal = 24000
        });
    }

    public List<EKartCartItem> GetCartItems()
    {
        return _CartItem;
    }

    public EKartCartItem GetCartItembyId(int id){
        EKartCartItem cartItem = new EKartCartItem();
        var result = _CartItem.Where(p => p.Id == id).FirstOrDefault();
        if (result != null)
            return result;
        else
            return cartItem;
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
            _CartItem[i].ImageUrl = EKartCartItem.ImageUrl;
            _CartItem[i].SubTotal = EKartCartItem.SubTotal;
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