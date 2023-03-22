
using Domain.Entities;

namespace Persistance.Repositories
{
    public interface IRepository
    {
        Pharmacy GetPharmacy(int id);
        List<Pharmacy> GetAllPharmacies();

        void RemovePharmacy(int id);
        void AddPharmacy(Pharmacy pharmacy);

        void UpdatePharmacy(Pharmacy pharm);

        Medicine GetMedicine(int id);
        List<MedicineDto> GetAllMedicines();
        void AddMedicine(Medicine medicine);
        void RemoveMedicine(int id);
        
        Task<bool> SaveChangesAsync();
    }
}
