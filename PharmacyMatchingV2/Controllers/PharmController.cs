using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance;
using Persistance.Repositories;

namespace API.Controllers
{
    [Route("PharmacyMatching")]
    [ApiController]
    public class PharmController : ControllerBase
    {
        private readonly IPharmsRepo _repository;
        private AppDbContext context;

        public PharmController(IPharmsRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("pharmacies")]
        public ActionResult<List<Pharmacy>> GetAllPharmacies()
        {
            return _repository.GetAllPharmacies();
        }

        [HttpGet("pharmacies/{pharmId}")]
        public ActionResult<Pharmacy> GetPharmacy(int pharmId)
        {
            return _repository.GetPharmacy(pharmId);
        }

        [HttpPost("pharmacies")]
        public void AddPharmacy(Pharmacy pharmacy)
        {
            var pharm = new Pharmacy()
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name,
                Description = pharmacy.Description,
                Address = pharmacy.Address,
                PhoneNumber = pharmacy.PhoneNumber
            };
            
            _repository.AddPharmacy(pharm);
        }
    }
}
