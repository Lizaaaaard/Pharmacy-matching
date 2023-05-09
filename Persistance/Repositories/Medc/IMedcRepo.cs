using Domain.Entities;

namespace Persistance.Repositories.Medc;

public interface IMedcRepo
{
    Medicine GetMedicine(int id);
    List<MedicineDto> GetAllMedicines();
    List<MedicineDto> GetMedicines(int page, int limit);
    void AddMedicine(Medicine medicine);
    void RemoveMedicine(int id);
        
    Task<bool> SaveChangesAsync();
}