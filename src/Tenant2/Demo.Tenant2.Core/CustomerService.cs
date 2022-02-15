using Demo.Core.Entities;
using Demo.Core.Interfaces;

namespace Demo.Tenant2.Core;
public class CustomerService : ICustomerService
{
    private static Customer[] customers = new Customer[]{
        new Customer(Guid.NewGuid(), "James", "Bond", new DateTime(1970, 5, 28)),
        new Customer(Guid.NewGuid(), "Jean", "Gray", new DateTime(1983, 3, 5))
    };

    public List<Customer> GetAll()
    {
        return customers.ToList<Customer>();
    }
}
