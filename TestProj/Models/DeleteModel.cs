using TestProj.Extensions.Models;

namespace TestProj.Models;

public class DeleteModel : BaseModel<int>
{
    public bool Deleted { get; set; }
}