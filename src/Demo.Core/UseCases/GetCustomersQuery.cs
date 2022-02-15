using Demo.Core.Entities;
using Demo.Core.Interfaces;

namespace Demo.Core.UseCases;

public class GetCustomersQuery
{
    private readonly ICustomerService service;

    public GetCustomersQuery(ICustomerService service)
    {
        this.service = service;
    }

    public List<Customer> Handle()
    {
        var result = service.GetAll();
        return result;
    }
}