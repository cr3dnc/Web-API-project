using Microsoft.EntityFrameworkCore;
using TestProj.Domain.Entities;

namespace TestProj.Domain;

public class MyWebApiContext : DbContext
{
    public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options)
    {
    }

    public DbSet<User> user_tbl { get; set; }
    public DbSet<Group> group_tbl { get; set; }
    public DbSet<CarsGarage> cars_garage_tbl { get; set; }
}