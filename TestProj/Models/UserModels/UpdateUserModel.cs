using TestProj.Extensions.Models;

namespace TestProj.Models;

public class UpdateUserModel : BaseModel<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Group { get; set; }
    public string CarsGarage { get; set; }
}