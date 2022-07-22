using TestProj.Models;

namespace TestProj.Interfaces.Repositories;

public interface IUserRepository
{
    List<UserModel> GetAllUsers();
    UserModel GetUserById(int id);
    void AddUser(string name, string email);
    void UpdateUser(int id, string name, string email, string group, string cars_garage);
    void DeleteUser(int id, bool deleted);
}