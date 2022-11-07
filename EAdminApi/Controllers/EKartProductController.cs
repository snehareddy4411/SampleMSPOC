using EAdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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


    [HttpPost]
    public List<EKartProducts> CreateNewEKartProducts(EKartProducts EKartProducts)
    {
        return _iEKartProductRepository.CreateProduct(EKartProducts);
    }
    
    [HttpPut]
    public List<EKartProducts> UpdateEKartProducts(EKartProducts EKartProducts)
    {
        return _iEKartProductRepository.UpdateProduct(EKartProducts);
    }
    [HttpDelete("{id:int}")]
    public List<EKartProducts> DeleteEKartProducts(int id)
    {
        return _iEKartProductRepository.DeleteProduct(id);
    }
    
}