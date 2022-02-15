using Demo.Core.Interfaces;
using Demo.Core.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddTransient<GetCustomersQuery>();

builder.Services.AddCustomerService();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


internal static class Helpers
{
    internal static void AddCustomerService(this IServiceCollection services)
    {
        services.AddTransient<Demo.Tenant1.Core.CustomerService>();
        services.AddTransient<Demo.Tenant2.Core.CustomerService>();

        services.AddScoped<ICustomerService>(provider =>
        {
            var context = provider.GetRequiredService<IHttpContextAccessor>();

            string tenantId = context.HttpContext.Request.Headers["tenantId"].FirstOrDefault();
            switch (tenantId)
            {
                case "tenant1":
                    return provider.GetRequiredService<Demo.Tenant1.Core.CustomerService>();
                case "tenant2":
                    return provider.GetRequiredService<Demo.Tenant2.Core.CustomerService>();
                default:
                    throw new InvalidOperationException("Invalid tenant id");
            }
        });
    }
}