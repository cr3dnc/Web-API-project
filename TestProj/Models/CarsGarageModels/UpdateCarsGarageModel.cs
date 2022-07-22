using TestProj.Extensions.Models;

namespace TestProj.Models;

public class UpdateCarsGarageModel : BaseModel<int>
{
    public string Name { get; set; }
}