using TestProj.Models;

namespace TestProj.Interfaces.Services;

public interface IUserService
{
    List<UserModel> GetAllUsers();
    UserModel GetUserById(int id);
    void AddUser(string name, string email);
    void UpdateUser(int id, string name, string email, string group, string cars_garage);
    void DeleteUser(int id, bool deleted);
}