
using AutoMapper;
using Domain.Entities;

namespace Persistance.Repositories
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;
        public Repository(AppDbContext ctx)
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

        void IRepository.AddMedicine(Medicine medicine)
        {
            _ctx.Medicines.Add(medicine);
        }

        Medicine IRepository.GetMedicine(int id)
        {
            return _ctx.Medicines.FirstOrDefault(p => p.Id == id);
        }

        public List<MedicineDto> GetAllMedicines()
        {
            // var medicines = _ctx.Medicines.ToList();
            // var medToPharms = _ctx.MedcToPharms.ToList();
            // var doses = _ctx.Doses.ToList();
            // var config = new MapperConfiguration(cfg => cfg
            //     .CreateMap<Tuple<List<Medicine>, List<MedcToPharm>, List<Dose>>, List<MedicineDto>>()
            //     .ForMember(dest => dest.Title,
            //         act => act.MapFrom(src => src.Item1.Name))
            //     .ForMember(dest => dest.Producer,
            //         act => act.MapFrom(src =>
            //             new ProducerDto(src.Item1.ProducerCompanyName, src.Item1.ProducerCountry)))
            //     .ForMember(dest => dest.Body,
            //         act => act.MapFrom(src => src.Item1.Description))
            //     .ForMember(dest => dest.Doses,
            //         act => act.MapFrom(src => ))
            //     .ForMember(dest => dest.NeedPrescription,
            //         act => act.MapFrom(src => src.Item1.IsPrescription))
            // );
            // var mapper = new Mapper(config);
            // List<MedicineDto> medicineDtos =
            //     mapper.Map<Tuple<List<Medicine>, List<MedcToPharm>, List<Dose>>>((medicines, medToPharms, doses));
            // return medicineDtos;
            throw new Exception();
        }

        void IRepository.RemoveMedicine(int id)
        {
            _ctx.Remove(GetPharmacy(id));
        }


    }
}
