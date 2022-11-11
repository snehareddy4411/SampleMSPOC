using EAdminApi.Models;

public class EKartProductRepository : IEKartProductRepository
{
    private List<EKartProducts> _Products;
    public EKartProductRepository()
    {
        _Products = new List<EKartProducts>();
        _Products.Add(new EKartProducts
        {
            Id = 1,
            ProductName = "Kiara Guest Chair",
            ImageUrl = "https://secure.img1-fg.wfcdn.com/im/43738380/resize-h600-w600%5Ecompr-r85/1215/121583674/Jamari+Upholstered+Accent+Chair.jpg",
            ProductType = "Chair",
            Price = 12000,
            Description = "A Hybrid between a Chair, Lounge Chair is not as heavy as lightweight as a chair either. Its slightly reclined back lets you lean back in style."

        });
        _Products.Add(new EKartProducts
        {
            Id = 2,
            ProductName = "Topaz Guest Chair",
            ImageUrl = "https://cdn.stocksnap.io/img-thumbs/280h/interior-chair_E3PW2UR6AE.jpg",
            ProductType = "Chair",
            Price = 15000,
            Description = "Lounge Chair is not as heavy or as lightweight as a chair either. Its slightly reclined back lets you lean back in style."

        });
        _Products.Add(new EKartProducts
        {
            Id = 3,
            ProductName = "Luxurious Sofa",
            ImageUrl = "https://image.shutterstock.com/image-photo/modern-sofa-260nw-426909265.jpg",
            ProductType = "Sofa",
            Price = 11999,
            Description = "Mintwud was conceptualized for compact homes which demand intelligent designs for small spaces, befitting modern lifestyles"

        });
        _Products.Add(new EKartProducts
        {
            Id = 4,
            ProductName = "Meaden Sofa",
            ImageUrl = "https://assets.architecturaldigest.in/photos/60083c12b3d78db39997d3b8/master/w_1600%2Cc_limit/sofa-design-budget-sofa-sofa-price-shopping_1.jpg",
            ProductType = "Sofa",
            Price = 12000,
            Description = "Mintwud was conceptualized for compact homes which demand intelligent designs for small spaces, befitting modern lifestyles"
        });
    }

    public List<EKartProducts> GetProducts()
    {
        return _Products;
    }
    public List<EKartProducts> CreateProduct(EKartProducts EKartProducts)
    {
        int NoOfRecords = _Products.Count();
        EKartProducts.Id = 1;
        if (NoOfRecords > 0)
        {
            EKartProducts.Id = _Products.Max(p => p.Id) + 1;
        }
        _Products.Add(EKartProducts);
        return _Products;

    }
    public EKartProducts GetProductbyId(int id){
        EKartProducts product = new EKartProducts();
        var result = _Products.Where(p => p.Id == id).FirstOrDefault();
        if (result != null)
            return result;
        else
            return product;
    }

    public List<EKartProducts> UpdateProduct(EKartProducts EKartProducts)
    {
        int i = _Products.FindIndex(p => p.Id == EKartProducts.Id);
        if (i >= 0)
        {
            _Products[i].ProductName = EKartProducts.ProductName;
            _Products[i].ProductType = EKartProducts.ProductType;
            _Products[i].Price = EKartProducts.Price;
            _Products[i].ImageUrl = EKartProducts.ImageUrl;
            _Products[i].Description = EKartProducts.Description;


        }
        return _Products;
    }
    public List<EKartProducts> DeleteProduct(int id)
    {
        var result = _Products.Where(p => p.Id == id).FirstOrDefault();
        if (result != null)
        {
            _Products.Remove(result);
        }
        return _Products;
    }



}