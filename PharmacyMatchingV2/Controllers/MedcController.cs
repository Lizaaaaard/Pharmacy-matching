using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repositories.Medc;

namespace API.Controllers
{
    [Route("PharmacyMatching")]
    [ApiController]
    public class MedcController : ControllerBase
    {
        private readonly IMedcRepo _repository;
        // private AppDbContext context;

        public MedcController(IMedcRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet("medicines")]
        public ActionResult<List<MedicineDto>> GetAllMedicines()
        {
            return _repository.GetAllMedicines();
        }

        [HttpGet("medicinesByPage")]
        public ActionResult<List<MedicineDto>> GetMedicines(int page, int limit)
        {
            return _repository.GetMedicines(page, limit);
        }


        [HttpGet("medicines/count")]
        public ActionResult<int> GetTotalCount()
        {
            return _repository.GetAllMedicines().Count;
        }

        
        [HttpGet("medicines/{medcId}")]
        public ActionResult<Medicine> GetMedicine(int medcId)
        {
            return _repository.GetMedicine(medcId);
        }

        [HttpPost("medicines")]
        public void AddMedicine(Medicine medicine)
        {
            var medc = new Medicine()
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Description = medicine.Description,
                IsPrescription = medicine.IsPrescription,
                ProducerCountry = medicine.ProducerCountry,
                ProducerCompanyName = medicine.ProducerCompanyName
            };

            _repository.AddMedicine(medc);
        }
    }
}
