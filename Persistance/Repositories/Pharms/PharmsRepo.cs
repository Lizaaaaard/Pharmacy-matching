
using AutoMapper;
using Domain.Entities;

namespace Persistance.Repositories
{
    public class PharmsRepo : IPharmsRepo
    {
        /*private static MapperConfiguration pharmConfig = new MapperConfiguration(cfg => cfg
            .CreateMap<PharmacyDto, Pharmacy>()
            .ForMember(ph => ph.Id, act => act.MapFrom(pharm => pharm.pharmId))
            .ForMember(ph => ph.Name, act => act.MapFrom(pharm => pharm.pharmacyName))
            .ForMember(ph => ph.Address, act => act.MapFrom(pharm => pharm.address))
            .ForMember(ph => ph.Description, act => act.MapFrom(pharm => pharm.workingHours))
            .ForMember(ph => ph.PhoneNumber, act => act.MapFrom(pharm => pharm.phoneNumber))
        );
        
        private Mapper pharmMapper = new Mapper(pharmConfig);*/
        private AppDbContext _ctx;
        public PharmsRepo(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPharmacy(Pharmacy pharmacy)
        {
            _ctx.Pharmacies.Add(pharmacy);
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            return _ctx.Pharmacies.ToList();
        }

        public Pharmacy GetPharmacy(int id)
        {
            return _ctx.Pharmacies.FirstOrDefault(p => p.Id == id);
        }
        
        public void UpdatePharmacy(Pharmacy pharm)
        {
            _ctx.Pharmacies.Update(pharm);
        }

        public void RemovePharmacy(int id)
        {
            _ctx.Remove(GetPharmacy(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }
    }
}
