using Demo.Core.Interfaces;

namespace Demo.Api;

public interface ICustomerServiceFactory
{
    ICustomerService GetCustomerService(string tenantId);
}

public class CustomerServiceFactory : ICustomerServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CustomerServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICustomerService GetCustomerService(string tenantId)
    {
        switch (tenantId)
        {
            case "tenant1":
                return _serviceProvider.GetService<Demo.Tenant1.Core.CustomerService>();
            case "tenant2":
                return _serviceProvider.GetService<Demo.Tenant2.Core.CustomerService>();
            default:
                throw new InvalidOperationException("Invalid tenant id");
        }
    }
}