using TestProj.Interfaces.Repositories;
using TestProj.Interfaces.Services;
using TestProj.Models;

namespace TestProj.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserModel> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public UserModel GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public void AddUser(string name, string email)
    {
        _userRepository.AddUser(name, email);
    }

    public void UpdateUser(int id, string name, string email, string group, string cars_garage)
    {
        _userRepository.UpdateUser(id, name, email, group, cars_garage);
    }

    public void DeleteUser(int id, bool deleted)
    {
        _userRepository.DeleteUser(id, deleted);
    }
}