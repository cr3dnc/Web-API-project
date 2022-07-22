using TestProj.Interfaces.Repositories;
using TestProj.Interfaces.Services;
using TestProj.Models;

namespace TestProj.Services;

public class CarsGarageService : ICarsGarageService
{
    private readonly ICarsGarageRepository _carsGarageRepository;

    public CarsGarageService(ICarsGarageRepository carsGarageRepository)
    {
        _carsGarageRepository = carsGarageRepository;
    }

    public List<CarsGarageModel> GetAllCarsGarages()
    {
        return _carsGarageRepository.GetAllCarsGarages();
    }

    public CarsGarageModel GetCarsGarageById(int id)
    {
        return _carsGarageRepository.GetCarsGarageById(id);
    }

    public void AddCarsGarage(string name)
    {
        _carsGarageRepository.AddCarsGarage(name);
    }

    public void UpdateCarsGarage(int id, string name)
    {
        _carsGarageRepository.UpdateCarsGarage(id, name);
    }

    public void DeleteCarsGarage(int id, bool deleted)
    {
        _carsGarageRepository.DeleteCarsGarage(id, deleted);
    }
}