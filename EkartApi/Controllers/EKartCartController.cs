using EkartApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EkartApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EKartCartController : ControllerBase
{
    private  IEKartCartRepository _IEkartCartRepository;

    public EKartCartController(IEKartCartRepository eKartCartRepository)
    {
        _IEkartCartRepository = eKartCartRepository;
    }

    [HttpGet]
    public List<EKartCartItem> GetAllCartItemsList()
    {
        return _IEkartCartRepository.GetCartItems();
    }

    [HttpGet("GetAllCartItems")]

    public string GetAllProducts(){
        return JsonSerializer.Serialize(_IEkartCartRepository.GetCartItems());
    }
    [HttpGet("{id:int}")]
    public EKartCartItem GetEKartCartItemById(int id)
    {
        return _IEkartCartRepository.GetCartItembyId(id);
    }
    [HttpPost]
    public List<EKartCartItem> CreateNewEKartCartItem(EKartCartItem EKartCartItem)
    {
        return _IEkartCartRepository.CreateCartItem(EKartCartItem);
    }
    
    [HttpPut]
    public List<EKartCartItem> UpdateEKartCartItem(EKartCartItem EKartCartItem)
    {
        return _IEkartCartRepository.UpdateCartItem(EKartCartItem);
    }
    [HttpDelete("{id:int}")]
    public List<EKartCartItem> DeleteEKartCartItem(int id)
    {
        return _IEkartCartRepository.DeleteCartItem(id);
    }

    [HttpGet("CartLength")]
    public int CartLength()
    {
        return _IEkartCartRepository.CartLength();
    }
    
}