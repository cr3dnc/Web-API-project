using TestProj.Extensions.Models;

namespace TestProj.Domain.Entities;

public class User : BaseEntity<int>
{
    public string name { get; set; }
    public string email { get; set; }
    public Group? group_ { get; set; }
    public CarsGarage? car_ { get; set; }
    public bool deleted { get; set; }
}