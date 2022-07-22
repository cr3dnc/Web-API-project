using TestProj.Extensions.Models;

namespace TestProj.Models;

public class UpdateGroupModel : BaseModel<int>
{
    public string Name { get; set; }
}