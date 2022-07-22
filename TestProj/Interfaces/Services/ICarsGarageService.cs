using TestProj.Models;

namespace TestProj.Interfaces.Services;

public interface ICarsGarageService
{
    List<CarsGarageModel> GetAllCarsGarages();
    CarsGarageModel GetCarsGarageById(int id);
    void AddCarsGarage(string name);
    void UpdateCarsGarage(int id, string name);
    void DeleteCarsGarage(int id, bool deleted);
}