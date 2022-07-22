using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using TestProj.Extensions.AppSettings;
using TestProj.Interfaces.Repositories;
using TestProj.Models;

namespace TestProj.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ConnectionOptions _connectionrOptions;

    public UserRepository(IOptions<ConnectionOptions> options)
    {
        _connectionrOptions = options.Value;
    }

    public List<UserModel> GetAllUsers()
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            return db.Query<UserModel>("SELECT * FROM user_tbl WHERE deleted = false").ToList();
        }
    }

    public UserModel GetUserById(int id)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            return db.Query<UserModel>("SELECT * FROM user_tbl WHERE id = @id AND deleted = false", new { id = id })
                .FirstOrDefault();
        }
    }

    public void AddUser(string name, string email)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("INSERT INTO user_tbl(name, email, deleted) VALUES(@name, @email, false)",
                new { name = name, email = email });
        }
    }

    public void UpdateUser(int id, string name, string email, string group, string cars_garage)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute(
                "UPDATE user_tbl SET name = @name, email = @email, group = @group, cars_garage = @cars_garage WHERE id = @id",
                new { id = id, name = name, email = email, group = group, cars_garage = cars_garage });
        }
    }

    public void DeleteUser(int id, bool deleted)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("UPDATE user_tbl SET deleted = @deleted WHERE id = @id",
                new { id = id, deleted = deleted });
        }
    }
}