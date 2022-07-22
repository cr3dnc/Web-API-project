using TestProj.Extensions.Models;

namespace TestProj.Domain.Entities;

public class CarsGarage : BaseEntity<int>
{
    public string name { get; set; }
    public bool deleted { get; set; }
}