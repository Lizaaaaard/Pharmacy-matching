using AutoMapper;
using Domain.Entities;

namespace Persistance.Repositories.Medc;

public class MedcRepo : IMedcRepo
{
    private static MapperConfiguration doseConfig = new MapperConfiguration(cfg => cfg.CreateMap<MedicineDose, DoseDto>()
        .ForMember(dose => dose.Id, act => act.MapFrom(medc => medc.dId))
        .ForMember(dose => dose.Package, act => act.MapFrom(medc => medc.Package))
        .ForMember(dose => dose.MinPrice, act => act.MapFrom(medc => medc.minPrice))
        .ForMember(dose => dose.MaxPrice, act => act.MapFrom(medc => medc.maxPrice))
        .ForMember(dose => dose.Availability, act => act.MapFrom(medc => medc.Availability))
    );
    private static MapperConfiguration medicineConfig = new MapperConfiguration(cfg => cfg.CreateMap<Tuple<MedicineDose, List<DoseDto>>, MedicineDto>()
        .ForMember(medicine => medicine.Id, act => act.MapFrom(t => t.Item1.medId))
        .ForMember(medicine => medicine.Title, act => act.MapFrom(t => t.Item1.Title))
        .ForMember(medicine => medicine.Producer, act => act.MapFrom(t => new ProducerDto(t.Item1.Company, t.Item1.Country)))
        .ForMember(medicine => medicine.Body, act => act.MapFrom(t => t.Item1.Body))
        .ForMember(medicine => medicine.Doses, act => act.MapFrom(t => t.Item2))
        .ForMember(medicine => medicine.NeedPrescription, act => act.MapFrom(t => t.Item1.needPrescription))
    );
    private Mapper doseMapper = new Mapper(doseConfig);
    private Mapper medicineMapper = new Mapper(medicineConfig);
    private AppDbContext _ctx;
    
    public MedcRepo(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    void IMedcRepo.AddMedicine(Medicine medicine)
    {
        _ctx.Medicines.Add(medicine);
    }

    Medicine IMedcRepo.GetMedicine(int id)
    {
        return _ctx.Medicines.FirstOrDefault(p => p.Id == id);
    }

    public List<MedicineDto> GetAllMedicines()
    {
        var medicines = from medc in _ctx.Medicines
            join mtp in _ctx.MedcToPharms on medc.Id equals mtp.MedcId
            where mtp.Amount > 0
            join d in _ctx.Doses on mtp.DoseId equals d.Id
            select new
            {
                medc,
                mtp,
                d
            }
            into t1
            group t1 by new
            {
                t1.medc.Id,
                t1.medc.Name,
                t1.medc.ProducerCompanyName,
                t1.medc.ProducerCountry,
                t1.medc.Description,
                DoseId = t1.d.Id,
                t1.d.Package,
                t1.medc.IsPrescription
                
            } 
            into pg
            select new MedicineDose(){
                medId = pg.Key.Id,
                Title = pg.Key.Name,
                Company = pg.Key.ProducerCompanyName,
                Country = pg.Key.ProducerCountry,
                Body = pg.Key.Description,
                dId = pg.Key.DoseId,
                Package = pg.Key.Package,
                minPrice = pg.Min( p => p.mtp.Price),
                maxPrice = pg.Max(p => p.mtp.Price),
                Availability = pg.Count(),
                needPrescription = pg.Key.IsPrescription
            };

        var medcList = medicines.AsEnumerable().ToList();
        var medcIdList = medcList.DistinctBy(m => m.medId).ToList();
        var medicineDtoList = new List<MedicineDto>();
        foreach (var id in medcIdList.Select(m => m.medId))
        {
            var medcDataList = medcList.Where(m => m.medId.Equals(id)).ToList();
            var medicineData = medcDataList.FirstOrDefault();
            var doses = new List<DoseDto> ();
            foreach (var medc in medcDataList)
            {
                doses.Add(doseMapper.Map<MedicineDose, DoseDto>(medc));
            }

            var medicineDto = medicineMapper.Map<Tuple<MedicineDose, List<DoseDto>>, MedicineDto>(Tuple.Create(medicineData, doses));
            medicineDtoList.Add(medicineDto);
        }
        return medicineDtoList;
    }

    void IMedcRepo.RemoveMedicine(int id)
    {
        _ctx.Remove(_ctx.Medicines.FirstOrDefault(p => p.Id == id));
    }

    public async Task<bool> SaveChangesAsync()
    {
        if (await _ctx.SaveChangesAsync() > 0)
            return true;
        else
            return false;
    }
}