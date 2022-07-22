namespace TestProj.Extensions.Models;

public class BaseEntity<T> where T : struct
{
    public T id { get; set; }
}