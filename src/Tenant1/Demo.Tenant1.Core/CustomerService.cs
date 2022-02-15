using Demo.Core.Entities;
using Demo.Core.Interfaces;

namespace Demo.Tenant1.Core;
public class CustomerService : ICustomerService
{
    private static Customer[] customers = new Customer[]{
        new Customer(Guid.NewGuid(), "Alfonso", "Ramos", new DateTime(1984, 12, 12)),
        new Customer(Guid.NewGuid(), "John", "Smith", new DateTime(1982, 6, 1))
    };

    public List<Customer> GetAll()
    {
        return customers.ToList<Customer>();
    }
}