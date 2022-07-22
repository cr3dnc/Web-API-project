using TestProj.Models;

namespace TestProj.Interfaces.Services;

public interface IGroupService
{
    List<GroupModel> GetAllGroups();
    GroupModel GetGroupById(int id);
    void AddGroup(string name);
    void UpdateGroup(int id, string name);
    void DeleteGroup(int id, bool deleted);
}