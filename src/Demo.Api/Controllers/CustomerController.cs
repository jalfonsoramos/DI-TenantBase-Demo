using Demo.Core.Entities;
using Demo.Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private readonly GetCustomersQuery _query;

    public CustomerController(ILogger<CustomerController> logger, GetCustomersQuery query)
    {
        _logger = logger;
        _query = query;
    }

    [HttpGet("")]
    public ActionResult<Customer> Get()
    {
        return Ok(_query.Handle());
    }
}
