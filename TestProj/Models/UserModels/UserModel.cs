using TestProj.Extensions.Models;

namespace TestProj.Models;

public class UserModel : BaseModel<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int GroupId { get; set; }
    public int CarsGarageId { get; set; }
    public bool Deleted { get; set; }
}