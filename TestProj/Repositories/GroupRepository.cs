using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using TestProj.Extensions.AppSettings;
using TestProj.Interfaces.Repositories;
using TestProj.Models;

namespace TestProj.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly ConnectionOptions _connectionrOptions;

    public GroupRepository(IOptions<ConnectionOptions> options)
    {
        _connectionrOptions = options.Value;
    }

    public List<GroupModel> GetAllGroups()
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            return db.Query<GroupModel>("SELECT * FROM group_tbl WHERE deleted = false").ToList();
        }
    }

    public GroupModel GetGroupById(int id)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            return db.Query<GroupModel>("SELECT * FROM group_tbl WHERE id = @id AND deleted = false", new { id = id })
                .FirstOrDefault();
        }
    }

    public void AddGroup(string name)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("INSERT INTO group_tbl(name, deleted) VALUES(@name, false)", new { name = name });
        }
    }

    public void UpdateGroup(int id, string name)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("UPDATE group_tbl SET name = @name WHERE id = @id", new { id = id, name = name });
        }
    }

    public void DeleteGroup(int id, bool deleted)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("UPDATE group_tbl SET deleted = @deleted WHERE id = @id",
                new { id = id, deleted = deleted });
        }
    }
}