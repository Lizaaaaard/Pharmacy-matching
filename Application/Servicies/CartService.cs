using Domain.Entities;
using Persistance.Repositories;

namespace Application.Servicies;

public class CartService
{
    private readonly IMedcToPharmRepo _medcToPharmRepo;
    private List<MedcToPharm> medcToPharms;

    public CartService(IMedcToPharmRepo medcToPharmRepo)
    {
        _medcToPharmRepo = medcToPharmRepo;
    }

    public List<Tuple<int, List<MedcToPharm>>> processCart(List<CartMedicineDto> cartMedc)
    {
        medcToPharms = _medcToPharmRepo.GetAllMedsToPharm();
        List<Tuple<int, List<CartMedicineDto>>> resultList = filterAvailablePharmacies(cartMedc);
        if (resultList.Count == 0)
        {
            foreach (CartMedicineDto cartMedicineDto in cartMedc)
            {
                List<CartMedicineDto> cartMedcExceptOne = cartMedc
                    .Except(new List<CartMedicineDto> { cartMedicineDto })
                    .ToList();
                List<Tuple<int, List<CartMedicineDto>>> tupleList = filterAvailablePharmacies(cartMedcExceptOne);
                resultList.AddRange(tupleList);
            }
        }

        return mapToReturnType(resultList);
    }

    public List<Tuple<int, List<CartMedicineDto>>> filterAvailablePharmacies(List<CartMedicineDto> cartMedc)
    {
        return getAvailablePharms(cartMedc)
            .Select(pharmId => Tuple.Create(pharmId, cartMedc))
            .ToList();
    }

    public List<int> getAvailablePharms(List<CartMedicineDto> medc)
    {
        List<int> medcIdList = medc.Select(m => m.medcId).ToList();
        List<int> doseIdList = medc.Select(m => m.doseId).ToList();
        List<MedcToPharm> filteredMedcToPharms = medcToPharms
            .Where(medcToPharm => medcIdList.Contains(medcToPharm.MedcId) && doseIdList.Contains(medcToPharm.DoseId))
            .Where(medcToPharm => medcToPharm.Amount > 0)
            .ToList();
        return filteredMedcToPharms
            .GroupBy(medcToPharm => medcToPharm.PharmId)
            .Select(group => new {PharmId = group.Key, count = group.Count() })
            .Where(medcToPharm => medcToPharm.count==medc.Count)
            .Select(medcToPharm => medcToPharm.PharmId)
            .Distinct()
            .ToList();
    }

    public List<Tuple<int, List<MedcToPharm>>> mapToReturnType(List<Tuple<int, List<CartMedicineDto>>> result)
    {
        return result.Select(r =>
        {
            List<int> medcIdList = r.Item2.Select(m => m.medcId).ToList();
            List<int> doseIdList = r.Item2.Select(m => m.doseId).ToList();
            List<MedcToPharm> medcToPharm = medcToPharms
                .Where(medcToPharm =>
                    medcIdList.Contains(medcToPharm.MedcId) && 
                    doseIdList.Contains(medcToPharm.DoseId) && 
                    medcToPharm.PharmId == r.Item1)
                .ToList();
            return Tuple.Create(r.Item1, medcToPharm);
        }).ToList();
    }
}