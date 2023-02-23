using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance;
using Persistance.Repositories;

namespace API.Controllers
{
    [Route("PharmacyMatching")]
    [ApiController]
    public class MedcController : ControllerBase
    {
        private readonly IRepository _repository;
        private AppDbContext context;

        public MedcController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("medicines"), Authorize]
        public ActionResult<List<Medicines>> GetAllMedicines()
        {
            return _repository.GetAllMedicines();
        }

        [HttpGet("medicines/{medcId}")]
        public ActionResult<Medicines> GetMedicine(int medcId)
        {
            return _repository.GetMedicine(medcId);
        }
    }
}
