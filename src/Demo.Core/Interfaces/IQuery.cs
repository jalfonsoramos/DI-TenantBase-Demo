using Demo.Core.Entities;

namespace Demo.Core.Interfaces;

public interface IQuery<T> where T : Customer
{
    T Get();
}
