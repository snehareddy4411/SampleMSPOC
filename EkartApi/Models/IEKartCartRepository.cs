using EkartApi.Models;

public interface IEKartCartRepository
{
    List<EKartCartItem> GetCartItems();
    List<EKartCartItem> CreateCartItem(EKartCartItem cartItem);
    List<EKartCartItem> UpdateCartItem(EKartCartItem cartItem);
    List<EKartCartItem> DeleteCartItem(int id);

    EKartCartItem GetCartItembyId(int id);
}