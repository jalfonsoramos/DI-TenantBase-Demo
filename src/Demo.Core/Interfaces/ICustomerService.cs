using Demo.Core.Entities;

namespace Demo.Core.Interfaces;

public interface ICustomerService
{
    List<Customer> GetAll();
}