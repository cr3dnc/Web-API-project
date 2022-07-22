using TestProj.Models;

namespace TestProj.Interfaces.Repositories;

public interface ICarsGarageRepository
{
    List<CarsGarageModel> GetAllCarsGarages();
    CarsGarageModel GetCarsGarageById(int id);
    void AddCarsGarage(string name);
    void UpdateCarsGarage(int id, string name);
    void DeleteCarsGarage(int id, bool deleted);
}