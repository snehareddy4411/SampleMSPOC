using EkartApi.Models;

public interface IEKartProductRepository
{
    List<EKartProducts> GetProducts();
    List<EKartProducts> CreateProduct(EKartProducts product);
    List<EKartProducts> UpdateProduct(EKartProducts product);
    List<EKartProducts> DeleteProduct(int id);
}