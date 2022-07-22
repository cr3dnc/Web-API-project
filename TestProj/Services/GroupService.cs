using TestProj.Interfaces.Repositories;
using TestProj.Interfaces.Services;
using TestProj.Models;

namespace TestProj.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public List<GroupModel> GetAllGroups()
    {
        return _groupRepository.GetAllGroups();
    }

    public GroupModel GetGroupById(int id)
    {
        return _groupRepository.GetGroupById(id);
    }

    public void AddGroup(string name)
    {
        _groupRepository.AddGroup(name);
    }

    public void UpdateGroup(int id, string name)
    {
        _groupRepository.UpdateGroup(id, name);
    }

    public void DeleteGroup(int id, bool deleted)
    {
        _groupRepository.DeleteGroup(id, deleted);
    }
}