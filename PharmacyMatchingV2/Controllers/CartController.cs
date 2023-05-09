using Application.Servicies;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repositories;

namespace API.Controllers;

[Route("PharmacyMatching")]
[ApiController]
public class CartController: ControllerBase
{
    private readonly CartService _cartService;
    private readonly IPharmsRepo _pharmsRepo;

    public CartController(CartService cartService, IPharmsRepo pharmsRepo)
    {
        _cartService = cartService;
        _pharmsRepo = pharmsRepo;
    }

    [HttpGet("availablePharmacies")]
    public List<Tuple<Pharmacy, List<MedcToPharm>>> processCart([FromBody] List<CartMedicineDto> cartMedc)
    {
        List<Tuple<int, List<MedcToPharm>>> pharmacyIdListWithMedc = _cartService.processCart(cartMedc);
        return pharmacyIdListWithMedc.Select(pharm => Tuple.Create(_pharmsRepo.GetPharmacy(pharm.Item1), pharm.Item2)).ToList();
    }
}