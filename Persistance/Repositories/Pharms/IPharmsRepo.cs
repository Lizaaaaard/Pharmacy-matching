
using Domain.Entities;

namespace Persistance.Repositories
{
    public interface IPharmsRepo
    {
        Pharmacy GetPharmacy(int id);
        List<Pharmacy> GetAllPharmacies();

        void RemovePharmacy(int id);
        void AddPharmacy(Pharmacy pharmacy);

        void UpdatePharmacy(Pharmacy pharm);
    }
}
