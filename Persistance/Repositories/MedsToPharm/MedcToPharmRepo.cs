using Domain.Entities;

namespace Persistance.Repositories;

public class MedcToPharmRepo : IMedcToPharmRepo
{
    private AppDbContext _ctx;
    
    public MedcToPharmRepo(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public List<MedcToPharm> GetAllMedsToPharm()
    {
        /*return _ctx.MedcToPharms.ToList();*/
        return _ctx.MedcToPharms.Select(m => new MedcToPharm() { 
            Id = m.Id,
            PharmId = m.PharmId,
            MedcId = m.MedcId,
            DoseId = m.DoseId,
            Price = m.Price,
            Amount = m.Amount }).ToList();
    }
}