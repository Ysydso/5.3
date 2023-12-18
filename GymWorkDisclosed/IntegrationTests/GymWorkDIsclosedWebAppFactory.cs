using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
namespace IntegrationTests;

public class GymWorkDisclosedWebAppFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    private const string environment = "Testing";
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment(environment);
    }
}