﻿using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance;
using Persistance.Repositories;

namespace API.Controllers
{
    [Route("PharmacyMatching")]
    [ApiController]
    public class PharmController : ControllerBase
    {
        private readonly IRepository _repository;
        private AppDbContext context;

        public PharmController(IRepository repository)
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
    }
}
