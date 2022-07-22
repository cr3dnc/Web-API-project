using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using TestProj.Extensions.AppSettings;
using TestProj.Interfaces.Repositories;
using TestProj.Models;

namespace TestProj.Repositories;

public class CarsGarageRepository : ICarsGarageRepository
{
    private readonly ConnectionOptions _connectionrOptions;

    public CarsGarageRepository(IOptions<ConnectionOptions> options)
    {
        _connectionrOptions = options.Value;
    }

    public List<CarsGarageModel> GetAllCarsGarages()
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            return db.Query<CarsGarageModel>("SELECT * FROM cars_garage_tbl WHERE deleted = false").ToList();
        }
    }

    public CarsGarageModel GetCarsGarageById(int id)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            return db.Query<CarsGarageModel>("SELECT * FROM cars_garage_tbl WHERE id = @id AND deleted = false",
                    new { id = id })
                .FirstOrDefault();
        }
    }

    public void AddCarsGarage(string name)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("INSERT INTO cars_garage_tbl(name, deleted) VALUES(@name, false)", new { name = name });
        }
    }

    public void UpdateCarsGarage(int id, string name)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("UPDATE cars_garage_tbl SET name = @name WHERE id = @id", new { id = id, name = name });
        }
    }

    public void DeleteCarsGarage(int id, bool deleted)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionrOptions.MyWebApiConection))
        {
            db.Execute("UPDATE cars_garage_tbl SET deleted = @deleted WHERE id = @id",
                new { id = id, deleted = deleted });
        }
    }
}