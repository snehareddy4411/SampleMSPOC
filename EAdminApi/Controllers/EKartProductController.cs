using EAdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace EAdminApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EKartProductController : ControllerBase
{
    private  IEKartProductRepository _iEKartProductRepository;

    public EKartProductController(IEKartProductRepository eKartProductRepository)
    {
        _iEKartProductRepository = eKartProductRepository;
    }

    [HttpGet]
    public List<EKartProducts> GetAllProductsList()
    {
        return _iEKartProductRepository.GetProducts();
    }

    [HttpGet("GetAllProducts")]

    public string GetAllProducts(){
        return JsonSerializer.Serialize(_iEKartProductRepository.GetProducts());
    }
    [HttpGet("{id:int}")]
    public EKartProducts GetProductsById(int id)
    {
        return _iEKartProductRepository.GetProductbyId(id);
    }

    [Authorize]
    [HttpPost]
    public List<EKartProducts> CreateNewEKartProducts(EKartProducts EKartProducts)
    {
        return _iEKartProductRepository.CreateProduct(EKartProducts);
    }
    
    [Authorize]
    [HttpPut]
    public List<EKartProducts> UpdateEKartProducts(EKartProducts EKartProducts)
    {
        return _iEKartProductRepository.UpdateProduct(EKartProducts);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public List<EKartProducts> DeleteEKartProducts(int id)
    {
        return _iEKartProductRepository.DeleteProduct(id);
    }
    
}