using Domain.Entities;

namespace Persistance.Repositories;

public interface IMedcToPharmRepo
{
    List<MedcToPharm> GetAllMedsToPharm();
    MedcToPharm GetMedInPharm(int medcInPharm);
}